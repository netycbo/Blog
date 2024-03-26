using FluentValidation;
using Blog_AppServices.API.Domain.Post;

namespace Blog_AppServices.API.Validators
{
    public class AddNewUserValidator : AbstractValidator<AddNewUserRequest>
    {
        public AddNewUserValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid");
            RuleFor(x => x.Name).Length(3, 30).WithMessage("Name should be between 3 and 30 characters");
            RuleFor(x => x.NickName).Length(3, 30).WithMessage("NickName should be between 3 and 30 characters");
        }
    }
}
