using FluentValidation;
using Module.Query.User.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Query.User.Business.ValidationRule
{
    public class AuthUserValidationRule : AbstractValidator<AuthUserRequestDTO>
    {
        public AuthUserValidationRule()
        {
            base.RuleFor((model) => model.Email).EmailAddress();
            base.RuleFor((model) => model.Password).NotEmpty();
        }
    }
}