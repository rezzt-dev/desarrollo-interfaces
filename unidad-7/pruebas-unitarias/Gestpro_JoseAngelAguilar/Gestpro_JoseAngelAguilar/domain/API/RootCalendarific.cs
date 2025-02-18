using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestpro_JoseAngelAguilar.domain.API;

namespace Gestpro_JoseAngelAguilar.domain
{
    /// <summary>
    /// 
    /// </summary>
    internal class RootCalendarific
    {
        /// <summary>
        /// Gets or sets the meta.
        /// </summary>
        /// <value>
        /// The meta.
        /// </value>
        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>
        /// The response.
        /// </value>
        [JsonProperty("response")]
        public ResponseDataApi Response { get; set; }
    }
}
