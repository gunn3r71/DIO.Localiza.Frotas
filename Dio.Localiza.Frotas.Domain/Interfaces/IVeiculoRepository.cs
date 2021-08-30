using System;
using System.Collections.Generic;
using Dio.Localiza.Frotas.Domain.Entities;

namespace Dio.Localiza.Frotas.Domain.Interfaces
{
    public interface IVeiculoRepository
    {
        Veiculo GetById(Guid id);
        IEnumerable<Veiculo> GetAll();
        void Add(Veiculo veiculo);
        void Delete(Veiculo veiculo);
        void Update(Veiculo veiculo);
    }
}