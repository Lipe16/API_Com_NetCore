using System;
using Microsoft.AspNetCore.Mvc;
using netCore.api.Models;
using netCore.api.Repositories;

namespace netCore.api.Controllers
{
    public class FundoCapitalController: Controller{
    
        private readonly IFundoCapitalRepository _repository;

        public FundoCapitalController(IFundoCapitalRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("v1/fundocapital")]
        public IActionResult listarFundos(){    
            return Ok(_repository.listar());
        }

        [HttpPost("v1/fundocapital")]
        public IActionResult adicionarFundo([FromBody] FundoCapital fundoCapital){
            _repository.Adicionar(fundoCapital);
            return Ok();
        }

        [HttpPut("v1/fundocapital/{id}")]
        public IActionResult editarFundo(Guid id, [FromBody] FundoCapital fundoCapital){
            var fundoAntigo = _repository.ObterPorId(id);
            if(fundoAntigo == null ){
                return NotFound();
            }
            fundoAntigo.nome = fundoCapital.nome;
            fundoAntigo.valorAtual = fundoCapital.valorAtual;
            fundoAntigo.valorNecessario = fundoCapital.valorNecessario;
            fundoAntigo.dataResgate = fundoCapital.dataResgate;
            _repository.Alterar(fundoAntigo);

            return Ok();
        }

        [HttpDelete("v1/fundocapital/{id}")]
        public IActionResult removerFundo(Guid id){
            var fundoAntigo = _repository.ObterPorId(id);
            if(fundoAntigo == null ){
                return NotFound();
            }
            _repository.RemoverFundoCapital(fundoAntigo);
            return Ok();
        }

        [HttpGet("v1/fundocapital/{id}")]
        public IActionResult listarPorId(Guid id){
            var fundoAntigo = _repository.ObterPorId(id);
            if(fundoAntigo == null ){
                return NotFound();
            }

            return Ok(fundoAntigo);
        }

    }
}