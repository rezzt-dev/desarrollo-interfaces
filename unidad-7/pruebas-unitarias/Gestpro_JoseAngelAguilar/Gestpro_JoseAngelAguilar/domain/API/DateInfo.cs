using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestpro_JoseAngelAguilar.domain.API
{
    /// <summary>
    /// 
    /// </summary>
    public class DateInfo
    {
        /// <summary>
        /// Gets or sets the iso.
        /// </summary>
        /// <value>
        /// The iso.
        /// </value>
        [JsonProperty("iso")]
        public DateTime Iso { get; set; }
    }
}
