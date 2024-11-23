using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Respository.Interfaces;

namespace SistemaDeTarefas.Respository
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly Context _context;
        public TarefaRepository(Context context)
        {
            _context = context;
        }
        public async Task<TarefasModel> Alterar(TarefasModel model, int id)
        {
            TarefasModel tarefa = await this.Buscar(id);
            if (tarefa == null) 
            {
                throw new Exception("Não foi possivel localizar a tarefa com esse identificador!");
            }
            tarefa.Name = model.Name;
            tarefa.Status = model.Status;
            tarefa.UsuarioId = model.UsuarioId;  
            tarefa.Description = model.Description;
            _context.Update(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }
        public async Task<TarefasModel> Buscar(int id)
        {
            TarefasModel tarefas = await _context.Tarefas
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
            return tarefas;
        }
        public async Task<bool> Excluir(int id)
        {
            TarefasModel tarefas = await this.Buscar(id);
            if (tarefas == null)
            {
                throw new Exception("Não foi possivel localizar a tarefa com esse identificador!");
            }
            _context.Tarefas.Remove(tarefas);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<TarefasModel>> Listar()
        {
            List<TarefasModel> tarefas = await _context.Tarefas
                .Include (x => x.Usuario)
                .ToListAsync();
            return tarefas;
        }
        public async Task<TarefasModel> Salvar(TarefasModel model)
        {
            await _context.Tarefas.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
