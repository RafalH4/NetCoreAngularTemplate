using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.UserDirectory.Dto
{
    public class ActivateUser
    {
        public string Email { get; set; }
        public string ActivateKey  { get; set; }
    }
}
