using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GameStation.Libs
{
    class Endereco
    {
        [JsonProperty("complemento")]
        public string Complemento { get; private set; }

        [JsonProperty("bairro")]
        public string Bairro { get; private set; }

        [JsonProperty("cidade")]
        public string Cidade { get; private set; }

        [JsonProperty("logradouro")]
        public string Logradouro { get; private set; }

        [JsonProperty("estado_info")]
        public EstadoInfo EstadoInfo { get; private set; }

        [JsonProperty("cep")]
        public string Cep { get; private set; }

        [JsonProperty("cidade_info")]
        public CidadeInfo CidadeInfo { get; private set; }

        [JsonProperty("estado")]
        public string Estado { get; private set; }
    }

    class EstadoInfo
    {
        [JsonProperty("area_km2")]
        public string AreaKM2 { get; private set; }

        [JsonProperty("codigo_ibge")]
        public string CodigoIbge { get; private set; }

        [JsonProperty("nome")]
        public string Nome { get; private set; }
    }

    class CidadeInfo
    {
        [JsonProperty("area_km2")]
        public string AreaKM2 { get; private set; }

        [JsonProperty("codigo_ibge")]
        public string CodigoIbge { get; private set; }
    }
}
