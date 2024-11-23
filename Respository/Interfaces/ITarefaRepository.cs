using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Respository.Interfaces
{
    public interface ITarefaRepository
    {
        Task<bool> Excluir(int id);
        Task<List<TarefasModel>> Listar();
        Task<TarefasModel> Buscar(int id);
        Task<TarefasModel> Salvar(TarefasModel model);
        Task<TarefasModel> Alterar(TarefasModel model, int id);
    }
}
