using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dio.Localiza.Frotas.Domain.Entities;
using Dio.Localiza.Frotas.Domain.Interfaces;
using Dio.Localiza.Frotas.Infrastructure.Context;

namespace Dio.Localiza.Frotas.Infrastructure.Repositories
{
    public class EfVeiculoRepository : IVeiculoRepository
    {
        private readonly AppDbContext _context = null;

        public EfVeiculoRepository(AppDbContext context)
        {
            _context = context;
        }

        public Veiculo GetById(Guid id)
        {
            return _context.Veiculos.Find(id);
        }

        public IEnumerable<Veiculo> GetAll()
        {
            return _context.Veiculos.ToList();
        }

        public void Add(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            SaveChanges();
        }

        public void Delete(Veiculo veiculo)
        {
            _context.Remove(veiculo);
            SaveChanges();
        }

        public void Update(Veiculo veiculo)
        {
            var search = GetById(veiculo.Id);
            if (search == null) throw new Exception("Not found");

            search.AnoFabricacao = veiculo.AnoFabricacao;
            search.Marca = veiculo.Marca;
            search.Placa = veiculo.Placa;

            _context.Veiculos.Update(search);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}