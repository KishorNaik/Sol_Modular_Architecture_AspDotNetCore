using FluentValidation;
using Module.Command.Posts.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Command.Posts.Business.ValidationRule
{
    public class CreatePostValidationRule : AbstractValidator<CreatePostRequestDTO>
    {
        public CreatePostValidationRule()
        {
            base.RuleFor((model) => model.UserIdentity).NotEmpty();
            base.RuleFor((model) => model.Post).NotEmpty();
        }
    }
}