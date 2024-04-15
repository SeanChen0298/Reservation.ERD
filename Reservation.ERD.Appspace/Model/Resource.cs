namespace Reservation.ERD.Appspace.Model
{
    public class Resource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<ResourceEvent> ResourceEvents { get; set; }
    }
}
