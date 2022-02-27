using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Module.Command.User.DTO.Request
{
    [DataContract]
    public class CreateUserRequestDTO
    {
        [DataMember(EmitDefaultValue = false)]
        public string? FirstName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string? LastName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string? Email { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string? Password { get; set; }
    }
}