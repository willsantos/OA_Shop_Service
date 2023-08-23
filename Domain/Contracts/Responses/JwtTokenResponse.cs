using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Responses
{
    public class JwtTokenResponse
    {
        public string Token { get; set; }
        public DateTime? DataExpiracao { get; set; }
    }
}
