using FluentValidation;
using TalentTrek.Api.Dto;

namespace TalentTrek.Api.Validators
{
    class CandidateRegistrationValidator : AbstractValidator<CandidateRegistrationRequest>
    {
        public CandidateRegistrationValidator()
        {
            RuleFor(candidate => candidate.FirstName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("First name is required");

            RuleFor(candidate => candidate.LastName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Last name is required");

            RuleFor(candidate => candidate.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Invalid email address");

            RuleFor(candidate => candidate.Password)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Password is required")
            .MinimumLength(8)
            .WithMessage("Password should contain at least 8 characters")
            .MaximumLength(30)
            .WithMessage("Password should not be more than 30 characters");

            RuleFor(candidate => candidate.ConfirmPassword)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Confirm Password is required")
            .Equal(candidate => candidate.Password)
            .WithMessage("Passwords do not match");
        }
    }
}