using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Respository.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> Listar()
        {
            List<UsuarioModel> usuarios = await _usuarioRepository.Listar();
            return Ok(usuarios);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> Buscar(int id)
        {
            UsuarioModel usuario = await _usuarioRepository.Buscar(id);
            return Ok(usuario);
        }
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Salvar([FromBody] UsuarioModel model)
        {
            UsuarioModel usuario = await _usuarioRepository.Salvar(model);
            return Ok(usuario);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Alterar([FromBody] UsuarioModel model, int id)
        {
            UsuarioModel usuario = await _usuarioRepository.Alterar(model, id);
            return Ok(usuario);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Excluit(int id)
        {
            bool result = await _usuarioRepository.Excluir(id);
            return Ok();
        }
    }
}
