using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookAppLogic
{
    public class MockEvent
    {
        private DateTime m_StartTime;
        private long m_AttendingCount;
        private long m_InterestedCount;
        private long m_DeclinedCount;
        private long m_MaybeCount;
        
        public MockEvent(DateTime i_StartTime, long i_AttendingCount, long i_InterestedCount, long i_DeclinedCount, long i_MaybeCount)
        {
            m_StartTime = i_StartTime;
            m_AttendingCount = i_AttendingCount;
            m_InterestedCount = i_InterestedCount;
            m_DeclinedCount = i_DeclinedCount;
            m_MaybeCount = i_MaybeCount;
        }

        public DateTime StartTime
        {
            get { return m_StartTime; }
        }

        public long AttendingCount { get { return m_AttendingCount; } }

        public long InterestedCount { get { return m_InterestedCount; } }

        public long DeclinedCount { get { return m_DeclinedCount; } }

        public long MaybeCount { get { return m_MaybeCount; } }
    }
}
