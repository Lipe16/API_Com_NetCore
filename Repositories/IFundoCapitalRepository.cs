using System;
using System.Collections.Generic;
using netCore.api.Models;

namespace netCore.api.Repositories
{
    public interface IFundoCapitalRepository{

        void Adicionar(FundoCapital fundo);

        void Alterar(FundoCapital fundo);

        IEnumerable<FundoCapital> listar();

        FundoCapital ObterPorId(Guid id);

        void RemoverFundoCapital(FundoCapital fundo);
    }
}