using System;

namespace FacebookAppLogic
{
    public class Event : iEvent
    {
        private readonly FacebookWrapper.ObjectModel.Event r_LegacyEvent;
        public string Name { get { return r_LegacyEvent.Name; } }
        public DateTime StartTime { get { return r_LegacyEvent.StartTime.Value; } }
        public long AttendingCount { get { return r_LegacyEvent.AttendingCount.Value; } }
        public long InterestedCount { get { return r_LegacyEvent.InterestedCount.Value; } }
        public long DeclinedCount { get { return r_LegacyEvent.DeclinedCount.Value; } }
        public long MaybeCount { get { return r_LegacyEvent.MaybeCount.Value; } }
        
        public Event(FacebookWrapper.ObjectModel.Event userEvent)
        {
            r_LegacyEvent = userEvent;
        }
    }
}
