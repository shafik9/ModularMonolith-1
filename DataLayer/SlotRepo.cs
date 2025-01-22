using CSharpFunctionalExtensions;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer;

public class SlotRepo(DoctorAvailabilityContext doctorAvailabilityContext)
{
    public async Task<List<DbSlot>> GetAllSlots()
        => await doctorAvailabilityContext.Slots.ToListAsync();
    
    
    public async Task<List<DbSlot>> GetAvailableSlots()
        => await doctorAvailabilityContext.Slots
            .Where(a=>!a.IsReserved).ToListAsync();

    public async Task<Result<DbSlot>> AddSlot(DbSlot dbSlot)
    {
        doctorAvailabilityContext.Slots.Add(dbSlot);
        await doctorAvailabilityContext.SaveChangesAsync();
        return Result.Success(dbSlot);
    }
}


