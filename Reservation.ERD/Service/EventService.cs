using Reservation.ERD.Model;

namespace Reservation.ERD.Service
{
    public class EventService
    {
        public bool CheckOverlap(Event eventA, Event eventB)
        {
            DateTime startA = eventA.StartAt;
            DateTime endA = eventA.EndAt;
            DateTime startB = eventB.StartAt;
            DateTime endB = eventB.EndAt;

            // Check for simple overlap
            if (startA < endB && endA > startB)
            {
                return true;
            }

            // Check for complete inclusion
            if (startA <= startB && endA >= endB)
            {
                return true;
            }
            if (startB <= startA && endB >= endA)
            {
                return true;
            }

            // Check for partial overlap
            if (startA < startB && startB < endA)
            {
                return true;
            }
            if (startA < endB && endB < endA)
            {
                return true;
            }

            return false;
        }

    }
}
