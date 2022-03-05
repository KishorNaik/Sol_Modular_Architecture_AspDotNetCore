using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Module.Query.User.DTO.Response
{
    public class JwtResponse
    {
        public string? Token { get; set; }
    }

    [DataContract]
    public class AuthUserResponseDTO
    {
        [DataMember(EmitDefaultValue = false)]
        public String? UserIdentity { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string? EmailId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string? FirstName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string? LastName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public JwtResponse? Jwt { get; set; }
    }

    public class AuthUserHashPasswordResponseDTO : AuthUserResponseDTO
    {
        public string? Hash { get; set; }

        public string? Salt { get; set; }
    }
}