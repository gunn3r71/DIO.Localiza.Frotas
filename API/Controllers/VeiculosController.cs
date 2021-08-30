using System;
using System.Security.Cryptography.X509Certificates;
using Dio.Localiza.Frotas.Domain.Entities;
using Dio.Localiza.Frotas.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dio.Localiza.Frotas.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoRepository _veiculoRepository = null;

        public VeiculosController(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        /// <summary>
        /// Obtem veículo através do Id
        /// </summary>
        /// <param name="id">Id do veículo desejado</param>
        /// <returns>200 - Veículo encontrado</returns>
        /// <returns>404 - Veículo não encontrado</returns>
        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var veiculo = _veiculoRepository.GetById(id);

            if (veiculo == null) return NotFound();

            return Ok(veiculo);
        }

        /// <summary>
        /// Traz todos veículos cadastrados
        /// </summary>
        /// <returns>Lista de veículos</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_veiculoRepository.GetAll());
        }

        /// <summary>
        /// Insere um veículo na frota
        /// </summary>
        /// <param name="veiculo">Veiculo a ser inserido</param>
        /// <returns>201 - veículo criado com sucesso</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Veiculo veiculo)
        {
            _veiculoRepository.Add(veiculo);

            return CreatedAtAction(nameof(GetById), new {Id = veiculo.Id}, veiculo);
        }

        /// <summary>
        /// Atualiza um veículo na frota
        /// </summary>
        /// <param name="id">Id do veículo a ser atualizado</param>
        /// <param name="veiculo">Veículo a ser atualizado</param>
        /// <returns>204 - veículo atualizado com sucesso</returns>
        /// <returns>404 - Veículo não foi encontrado</returns>
        [HttpPut("{id:guid}")]
        public IActionResult Put(Guid id, [FromBody] Veiculo veiculo)
        {
            var veiculoSearch = _veiculoRepository.GetById(id);

            if (veiculoSearch == null) return NotFound(id);

            _veiculoRepository.Update(veiculo);
            return NoContent();
        }

        /// <summary>
        /// Deleta um veículo na frota
        /// </summary>
        /// <param name="id">Id do veículo a ser deletado</param>
        /// <returns>204 - veículo deletado com sucesso</returns>
        /// <returns>404 - veículo não foi encontrado</returns>
        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var veiculo = _veiculoRepository.GetById(id);

            if (veiculo == null) return NotFound(id);

            _veiculoRepository.Delete(veiculo);

            return NoContent();
        }
    }
}
