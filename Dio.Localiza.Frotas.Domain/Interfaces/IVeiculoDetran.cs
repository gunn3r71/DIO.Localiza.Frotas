using System;
using System.Threading.Tasks;

namespace Dio.Localiza.Frotas.Domain.Interfaces
{
    public interface IVeiculoDetran
    {
        public Task AgendarVistoria(Guid veiculoId);
    }
}