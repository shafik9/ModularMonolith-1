namespace DataLayer.Entities;

public class DbSlot
{
    public Guid Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Guid DoctorId { get; set; }
    public string? DoctorName { get; set; }
    public bool IsReserved { get; set; }
    public decimal Cost { get; set; }
}