using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Dio.Localiza.Frotas.Domain.Interfaces;
using Microsoft.Extensions.Options;

namespace Dio.Localiza.Frotas.Domain.Facade
{
    public class VeiculoDetranFacade : IVeiculoDetran
    {
        private readonly DetranOptions _detranOptions;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoDetranFacade(IOptionsMonitor<DetranOptions> detranOptions, IHttpClientFactory httpClientFactory, IVeiculoRepository veiculoRepository)
        {
            _detranOptions = detranOptions.CurrentValue;
            _httpClientFactory = httpClientFactory;
            _veiculoRepository = veiculoRepository;
        }

        public async Task AgendarVistoria(Guid veiculoId)
        {
            var veiculo = _veiculoRepository.GetById(veiculoId);

            var requestModel = new VistoriaModel
            {
                Placa = veiculo.Placa,
                AgendadoPara = DateTime.Now.AddDays(_detranOptions.QuantidadeDiasAgendamento)
            };

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_detranOptions.BaseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = JsonSerializer.Serialize(requestModel);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            await client.PostAsync(_detranOptions.VistoriaUrl, stringContent);
        }
    }
}