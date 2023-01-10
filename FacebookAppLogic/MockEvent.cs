using System;

namespace FacebookAppLogic
{
    public class MockEvent : iEvent
    {
        public string m_Name { get; set; }
        public DateTime m_StartTime { get; set; }
        public long m_AttendingCount { get; set; }
        public long m_InterestedCount { get; set; }
        public long m_DeclinedCount { get; set; }
        public long m_MaybeCount { get; set; }

        public MockEvent()
        {

        }
    }
}
