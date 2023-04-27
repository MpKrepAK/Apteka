using DAL.Context;
using DAL.Interfaces;
using ML.Models;

namespace DAL.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    public readonly AptecaContext _Context;
    public AppointmentRepository(AptecaContext context)
    {
        _Context = context;
    }

    public IEnumerable<Appointment> GetAll()
    {
        return _Context.Appointments.ToList();
    }

    public Appointment GetById(int Id)
    {
        return _Context.Appointments.FirstOrDefault(x => x.Id == Id);
    }
}