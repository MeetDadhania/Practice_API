using FluentValidation;
using Model.RequestBody;

namespace Practice_API.Validation
{
    public class EmployeeValidation : AbstractValidator<EmployeeRequest>
    {
        public EmployeeValidation()
        {
            //validate name field for Employee Name
            RuleFor(employee => employee.Name).NotEmpty().NotEmpty().WithMessage("Pls Enter the Name....");

            //validate name field for Employee Email
            RuleFor(employee => employee.Email).NotEmpty().NotNull().EmailAddress().WithMessage("Pls Enter the valid Email Address....");

            //validate name field for Employee PhoneNumber
            RuleFor(employee => employee.PhoneNumber).NotNull().NotEmpty().WithMessage("Please add a phone number");
        }
    }
}
