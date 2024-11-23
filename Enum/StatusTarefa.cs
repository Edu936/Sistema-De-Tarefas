using System.ComponentModel;

namespace SistemaDeTarefas.Enum
{
    public enum StatusTarefa
    {
        [Description("A fazer")]
        AFazer = 1,
        [Description("Em Andanento")]
        EmAndamento = 2,
        [Description("Concluida")]
        Concluido = 3,
    }
}
