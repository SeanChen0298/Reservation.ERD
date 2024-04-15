namespace Reservation.ERD.Model
{
    public class Event
    {
        public Guid Id { get; set; }
        public DateTime StartAt {  get; set; }
        public DateTime EndAt { get; set; }
        public string Title { get; set; }
        public ICollection<ResourceEvent> ResourceEvents { get; set; }
    }
}
