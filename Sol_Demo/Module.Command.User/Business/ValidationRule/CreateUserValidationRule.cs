using FluentValidation;
using Module.Command.User.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Command.User.Business.ValidationRule
{
    public class CreateUserValidationRule : AbstractValidator<CreateUserRequestDTO>
    {
        public CreateUserValidationRule()
        {
            base.RuleFor((model) => model.FirstName).NotEmpty();
            base.RuleFor((model) => model.LastName).NotEmpty();
            base.RuleFor((model) => model.Email).EmailAddress();
            base.RuleFor((model) => model.Password).NotEmpty();
        }
    }
}