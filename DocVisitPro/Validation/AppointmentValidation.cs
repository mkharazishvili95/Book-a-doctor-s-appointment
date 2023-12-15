using DocVisitPro.Models;
using FluentValidation;

namespace DocVisitPro.Validation
{
    public class AppointmentValidation : AbstractValidator<Appointment>
    {
        public AppointmentValidation() 
        {
            RuleFor(appointment => appointment.Firstname).NotEmpty().WithMessage("Enter your firstname!")
            .Must(name => !string.IsNullOrWhiteSpace(name)).WithMessage("Firstname should not be empty or contain only whitespace.");

            RuleFor(appointment => appointment.Lastname).NotEmpty().WithMessage("Enter your lastname!")
                .Must(lastname => !string.IsNullOrWhiteSpace(lastname)).WithMessage("Lastname should not be empty or contain only whitespace.");

            RuleFor(appointment => appointment.Doctor).NotEmpty().WithMessage("Enter Doctor's name!")
            .Must(doctor => !string.IsNullOrWhiteSpace(doctor)).WithMessage("Doctor's name should not be empty or contain only whitespace.");

            RuleFor(appointment => appointment.AppointmentDateTime)
                .NotEmpty().WithMessage("Please enter appointment time!")
                .Must(time =>
                {
                    if (time != null && time.TimeOfDay >= TimeSpan.FromHours(10) && time.TimeOfDay <= TimeSpan.FromHours(19))
                    {
                        return true;
                    }
                    return false;
                }).WithMessage("You can book appointments between 10:00 and 19:00.");
        }
    }
}
