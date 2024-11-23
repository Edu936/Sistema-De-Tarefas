using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Respository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<bool> Excluir(int id);
        Task<List<UsuarioModel>> Listar();
        Task<UsuarioModel> Buscar(int id);
        Task<UsuarioModel> Salvar(UsuarioModel model);
        Task<UsuarioModel> Alterar(UsuarioModel model, int id);
    }
}
