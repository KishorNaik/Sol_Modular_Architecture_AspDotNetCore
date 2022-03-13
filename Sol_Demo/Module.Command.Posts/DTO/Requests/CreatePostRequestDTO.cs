using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Module.Command.Posts.DTO.Requests
{
    [DataContract]
    public class CreatePostRequestDTO
    {
        [DataMember(EmitDefaultValue = false)]
        public string? Post { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string? UserIdentity { get; set; }
    }
}