using System;

namespace Dio.Localiza.Frotas.Domain.Facade
{
    public class DetranOptions
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string BaseUrl { get; set; }
        public string VistoriaUrl { get; set; }
        public int QuantidadeDiasAgendamento { get; set; }
    }
}