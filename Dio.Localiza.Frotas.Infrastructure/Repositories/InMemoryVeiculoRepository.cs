using System;
using System.Collections.Generic;
using System.Linq;
using Dio.Localiza.Frotas.Domain.Entities;
using Dio.Localiza.Frotas.Domain.Interfaces;

namespace Dio.Localiza.Frotas.Infrastructure.Repositories
{
    public class InMemoryVeiculoRepository : IVeiculoRepository
    {
        private IList<Veiculo> _veiculos = new List<Veiculo>();
        public Veiculo GetById(Guid id)
        {
            return _veiculos.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Veiculo> GetAll()
        {
            return _veiculos.ToList();
        }

        public void Add(Veiculo veiculo)
        {
            _veiculos.Add(veiculo);
        }

        public void Delete(Veiculo veiculo)
        {
            _veiculos.Remove(veiculo);
        }

        public void Update(Veiculo veiculo)
        {
            _veiculos.Remove(GetById(veiculo.Id));
            _veiculos.Add(veiculo);
        }
    }
}