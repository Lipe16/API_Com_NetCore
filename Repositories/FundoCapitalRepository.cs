using System;
using System.Collections.Generic;
using System.Linq;
using netCore.api.Models;

namespace netCore.api.Repositories
{
    public class FundoCapitalRepository : IFundoCapitalRepository
    {
        private readonly List<FundoCapital> _storage;

        public FundoCapitalRepository(){
            _storage = new List<FundoCapital>();
        }

        public void Adicionar(FundoCapital fundo)
        {
            _storage.Add(fundo);
        }

        public void Alterar(FundoCapital fundo)
        {
            var index = _storage.FindIndex(0,1, x => x.id == fundo.id);

            Console.WriteLine(index);

            if(index != -1)
                _storage[index] = fundo;
        }

        public IEnumerable<FundoCapital> listar()
        {
            return _storage;
        }

        public FundoCapital ObterPorId(Guid id)
        {
            var storage = _storage.FirstOrDefault(x => x.id == id);
            return storage ;
        }

        public void RemoverFundoCapital(FundoCapital fundo)
        {
            _storage.Remove(fundo);
        }
    }
}