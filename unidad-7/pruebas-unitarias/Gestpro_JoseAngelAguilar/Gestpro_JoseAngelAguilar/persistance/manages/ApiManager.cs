using Gestpro_JoseAngelAguilar.domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Gestpro_JoseAngelAguilar.persistance.manages
{
    /// <summary>
    /// 
    /// </summary>
    internal class ApiManager
    {
        /// <summary>
        /// The API URL
        /// </summary>
        private readonly string _apiURL = "https://calendarific.com/api/v2/holidays?";
        /// <summary>
        /// The API key
        /// </summary>
        private readonly string apiKey = "api_key=SjlBKSoNRHpz4BFwV7U9jniAi6oxe1nR";
        /// <summary>
        /// The country
        /// </summary>
        private const string country = "country=ES";

        /// <summary>
        /// Gets the lista festivos.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Error: {response.StatusCode} - {response.ReasonPhrase}</exception>
        public async Task<List<ApiObject>> getListaFestivos(string year)
        {
            string url = _apiURL + apiKey + "&" + country + "&year=" + year;

            HttpClient cliente = new HttpClient();
            HttpResponseMessage response = await cliente.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }

            // Leer el contenidoJSON
            string festivos = await response.Content.ReadAsStringAsync();

            //Deserializar al objeto raíz que contiene meta y response
            RootCalendarific root = JsonConvert.DeserializeObject<RootCalendarific>(festivos);

            // Devolvemos la lista de festivos que está en root.Response.Holidays
            //  Si root o root.Response vienen nulos por algún motivo, devolvemos una lista vacía
            return root?.Response?.Holidays ?? new List<ApiObject>();
        }
    }
}
