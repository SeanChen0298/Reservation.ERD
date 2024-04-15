namespace Reservation.ERD.Model
{
    public class ResourceEventAttendee
    {
        public Guid ResourceEventAttendeeId {  get; set; }
        public Guid ResourceEventId {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
