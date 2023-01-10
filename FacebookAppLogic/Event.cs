using System;

namespace FacebookAppLogic
{
    public class Event : iEvent
    {
        private readonly FacebookWrapper.ObjectModel.Event r_LegacyEvent;
        public string m_Name { get { return r_LegacyEvent.Name; } }
        public DateTime m_StartTime { get { return r_LegacyEvent.StartTime.Value; } }
        public long m_AttendingCount { get { return r_LegacyEvent.AttendingCount.Value; } }
        public long m_InterestedCount { get { return r_LegacyEvent.InterestedCount.Value; } }
        public long m_DeclinedCount { get { return r_LegacyEvent.DeclinedCount.Value; } }
        public long m_MaybeCount { get { return r_LegacyEvent.MaybeCount.Value; } }
        
        public Event(FacebookWrapper.ObjectModel.Event userEvent)
        {
            r_LegacyEvent = userEvent;
        }
    }
}
