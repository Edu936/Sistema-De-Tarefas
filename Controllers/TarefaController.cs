using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Respository.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;
        public TarefaController(ITarefaRepository tarefaRepository) 
        { 
            _tarefaRepository = tarefaRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<TarefasModel>>> Listar()
        {
            List<TarefasModel> tarefas = await _tarefaRepository.Listar();
            return Ok(tarefas);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TarefasModel>> Buscar(int id)
        {
            TarefasModel tarefa = await _tarefaRepository.Buscar(id);
            return Ok(tarefa);
        }
        [HttpPost]
        public async Task<ActionResult<TarefasModel>> Salvar([FromBody] TarefasModel model)
        {
            TarefasModel tarefa = await _tarefaRepository.Salvar(model);
            return Ok(tarefa);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TarefasModel>> Atualizar([FromBody] TarefasModel model, int id)
        {
            TarefasModel tarefa = await _tarefaRepository.Alterar(model, id);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TarefasModel>> Excluir(int id)
        {
            bool result = await _tarefaRepository.Excluir(id);
            return Ok(result);
        }
    }
}
