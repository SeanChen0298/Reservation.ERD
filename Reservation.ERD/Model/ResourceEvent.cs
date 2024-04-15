namespace Reservation.ERD.Model
{
    public class ResourceEvent
    {
        public Guid ResourceEventId { get; set; }
        public Guid ResourceId { get; set; }
        public Guid EventId { get; set; }
        public ICollection<ResourceEventAttendee> ResourceEventAttendees { get; set; }

    }
}
