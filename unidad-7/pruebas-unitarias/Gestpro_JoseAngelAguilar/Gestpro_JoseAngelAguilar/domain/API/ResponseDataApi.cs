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
    public class ResponseDataApi
    {
        /// <summary>
        /// Gets or sets the holidays.
        /// </summary>
        /// <value>
        /// The holidays.
        /// </value>
        [JsonProperty("holidays")]
        public List<ApiObject> Holidays { get; set; }
    }
}
