using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Module.Query.User.DTO.Request
{
    [DataContract]
    public class AuthUserRequestDTO
    {
        [DataMember(EmitDefaultValue = false)]
        public String? Email { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public String? Password { get; set; }
    }
}