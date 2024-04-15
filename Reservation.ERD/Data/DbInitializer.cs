using Reservation.ERD.Model;

namespace Reservation.ERD.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ReservationContext context)
        {
            // Look for any resources.
            if (context.Resources.Any())
            {
                return;   // DB has been seeded
            }

            var resources = new Resource[]
            {
            new Resource { Id = Guid.NewGuid(), Name = "Resource 1", Email = "resource1@example.com" },
            new Resource { Id = Guid.NewGuid(), Name = "Resource 2", Email = "resource2@example.com" },
                // Add more resources as needed
            };

            context.Resources.AddRange(resources);
            context.SaveChanges();

            // You can similarly seed events, resource events, and attendees here.
            // Ensure that you generate unique GUIDs for each entity.

            var events = new Event[]
            {
            new Event { Id = Guid.NewGuid(), StartAt = DateTime.Parse("2024-04-15 09:00:00"), EndAt = DateTime.Parse("2024-04-15 10:00:00"), Title = "Event 1" },
            new Event { Id = Guid.NewGuid(), StartAt = DateTime.Parse("2024-04-15 10:30:00"), EndAt = DateTime.Parse("2024-04-15 11:30:00"), Title = "Event 2" },
                // Add more events as needed
            };

            context.Events.AddRange(events);
            context.SaveChanges();

            var resourceEvents = new ResourceEvent[]
            {
            new ResourceEvent { ResourceEventId = Guid.NewGuid(), ResourceId = resources[0].Id, EventId = events[0].Id },
            new ResourceEvent { ResourceEventId = Guid.NewGuid(), ResourceId = resources[1].Id, EventId = events[1].Id },
                // Add more resource events as needed
            };

            context.ResourceEvents.AddRange(resourceEvents);
            context.SaveChanges();

            var resourceEventAttendees = new ResourceEventAttendee[]
            {
            new ResourceEventAttendee { ResourceEventAttendeeId = Guid.NewGuid(), ResourceEventId = resourceEvents[0].ResourceEventId, Name = "Attendee 1", Email = "attendee1@example.com" },
            new ResourceEventAttendee { ResourceEventAttendeeId = Guid.NewGuid(), ResourceEventId = resourceEvents[1].ResourceEventId, Name = "Attendee 2", Email = "attendee2@example.com" },
                // Add more attendees as needed
            };

            context.ResourceEventAttendees.AddRange(resourceEventAttendees);
            context.SaveChanges();
        }
    }

}
