using SistemaDeTarefas.Enum;

namespace SistemaDeTarefas.Models
{
    public class TarefasModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public StatusTarefa Status { get; set; }
        public int? UsuarioId { get; set; }
        public virtual UsuarioModel? Usuario { get; set; }
    }
}
