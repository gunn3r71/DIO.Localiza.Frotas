using System;

namespace Dio.Localiza.Frotas.Domain.Entities
{
    public class Veiculo
    {
        //public Veiculo(string placa, string marca, string anoFabricacao)
        //{
        //    this.Id = Guid.NewGuid();
        //    this.Placa = placa;
        //    this.Marca = marca;
        //    this.AnoFabricacao = anoFabricacao;
        //}

        public Guid Id { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string AnoFabricacao { get; set; }
    }
}