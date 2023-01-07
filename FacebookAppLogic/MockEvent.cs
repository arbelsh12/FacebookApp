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

        public MockEvent(string i_Name, DateTime i_StartTime, long i_AttendingCount, long i_InterestedCount, long i_DeclinedCount, long i_MaybeCount)
        {
            m_Name = i_Name;
            m_StartTime = i_StartTime;
            m_AttendingCount = i_AttendingCount;
            m_InterestedCount = i_InterestedCount;
            m_DeclinedCount = i_DeclinedCount;
            m_MaybeCount = i_MaybeCount;
        }
    }
}
