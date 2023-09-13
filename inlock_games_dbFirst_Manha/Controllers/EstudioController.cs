using inlock_games_dbFirst_Manha.Domains;
using inlock_games_dbFirst_Manha.Interfaces;
using inlock_games_dbFirst_Manha.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace inlock_games_dbFirst_Manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        //****************************************************** LISTAR TODOS ****************************************
        /// <summary>
        /// Metodo para listar os Estudios
        /// </summary>
        /// <returns> Lista com todos os Estudios cadastrados </returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_estudioRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        //****************************************************** LISTAR TODOS COM JOGOS ****************************************
        /// <summary>
        /// Metodo para listar os estudios com todos os jogos que a pertencem 
        /// </summary>
        /// <returns> Lista de Estudios com a lista Jogos </returns>

        [HttpGet("ListarComJogos")]
        public IActionResult GetWithGames()
        {
            try
            {
                return Ok(_estudioRepository.ListarComJogos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
        //****************************************************** BUSCAR PELO ID ****************************************
        /// <summary>
        /// Metodo para buscar um Estudio pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns> objeto procurado pelo ID </returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_estudioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        //****************************************************** DELETAR PELO ID ****************************************
        /// <summary>
        /// Método para deletar um objeto pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Deleta o objeto da lista </returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _estudioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
        //****************************************************** CADASTRAR ****************************************
        /// <summary>
        /// Cadastra um novo objeto
        /// </summary>
        /// <param name="estudio"></param>
        /// <returns> Objeto cadastrado </returns>
        [HttpPost]
        public IActionResult Post(Estudio estudio)
        {
            try
            {

                _estudioRepository.Cadastrar(estudio);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
        //****************************************************** ATUALIZAR PELO ID****************************************
        [HttpPut("{id}")]
        public IActionResult Put (Guid id, Estudio estudio) 
        {
            try
            {
                _estudioRepository.Atualizar(id, estudio);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
