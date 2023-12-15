using DocVisitPro.Data;
using DocVisitPro.Models;
using DocVisitPro.Validation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
public class AppointmentController : Controller
{
    private readonly AppointmentContext _context;

    public AppointmentController(AppointmentContext context)
    {
        _context = context;
    }

    // This action handles GET requests to /BookAppointment
    [HttpGet("BookAppointment")]
    public IActionResult BookAppointment()
    {
        // Add logic to display a form for booking an appointment
        return View(); // Return a view for booking an appointment
    }

    // This action handles POST requests to /BookAppointment
    [HttpPost("BookAppointment")]
    public IActionResult Create(Appointment newAppointment)
    {
        var appointmentValidation = new AppointmentValidation();
        var validationResults = appointmentValidation.Validate(newAppointment);

        if (!validationResults.IsValid)
        {
            foreach (var error in validationResults.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            // Return the view with validation errors
            return View("BookAppointment", newAppointment);
        }
        else
        {
            _context.Appointments.Add(newAppointment);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }


    public IActionResult Index()
    {
        var appointments = _context.Appointments.ToList();
        return View(appointments);
    }
}

