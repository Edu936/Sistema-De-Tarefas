using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Respository.Interfaces;

namespace SistemaDeTarefas.Respository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Context _context;

        public UsuarioRepository(Context context)
        {
            _context = context;
        }
        public async Task<UsuarioModel> Buscar(int id)
        {
            UsuarioModel usuario =  await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            return usuario;
        }
        public async Task<List<UsuarioModel>> Listar()
        {
            List<UsuarioModel> usuarios = await _context.Usuarios.ToListAsync();
            return usuarios;
        }
        public async Task<UsuarioModel> Salvar(UsuarioModel model)
        {
            await _context.Usuarios.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<UsuarioModel> Alterar(UsuarioModel model, int id)
        {
            UsuarioModel usuarioModel = await this.Buscar(id);
            if(usuarioModel == null) 
            {
                throw new Exception("Não foi possivel localizar o usuario com esse identificador!");
            }
            usuarioModel.Name = model.Name;
            usuarioModel.Email = model.Email;
            _context.Usuarios.Update(usuarioModel);
            await _context.SaveChangesAsync();
            return usuarioModel;
        }
        public async Task<bool> Excluir(int id)
        {
            UsuarioModel usuarioModel = await this.Buscar(id);
            if (usuarioModel == null)
            {
                throw new Exception("Não foi possivel localizar com esse identificador!");
            }
            _context.Usuarios.Remove(usuarioModel);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
