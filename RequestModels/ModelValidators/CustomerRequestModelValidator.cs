using FluentValidation;
using Simple_C__Data_Access_with_Dapper_and_SQL.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Simple_C__Data_Access_with_Dapper_and_SQL.RequestModels.ModelValidators
{
    public class CustomerRequestModelValidator : AbstractValidator<CustomerRequestModel>
    {
        public CustomerRequestModelValidator()
        {
            RuleFor(m => m.Email).Custom((email, context) =>
            {
                if (!(Regex.IsMatch(email, "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$")))
                {
                    context.AddFailure($"Email {email} is invalid");
                }
            });

            RuleFor(m => m.Password)
           .NotEmpty().WithMessage("Password must not be empty")
           .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
           .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
           .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
           .Matches("[0-9]").WithMessage("Password must contain at least one digit")
           .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character");
        }

        protected override void RaiseValidationException(ValidationContext<CustomerRequestModel> context, ValidationResult result)
        {
            throw new ClientException(result.ToString(), ClientErrorCodes.BadRequestModel);
        }
    }
    
}


   

