using Gestpro_JoseAngelAguilar.domain.API;
using Gestpro_JoseAngelAguilar.persistance.manages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestpro_JoseAngelAguilar.domain
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiObject
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        [JsonProperty("date")]
        public DateInfo Date { get; set; }

        // Agrega más propiedades si las necesitas (ej: "locations", "type", etc.)
    }
}
