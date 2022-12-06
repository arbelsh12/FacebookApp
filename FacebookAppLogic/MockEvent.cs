using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookAppLogic
{
    public class MockEvent
    {
        private readonly string r_Name;
        private readonly DateTime r_StartTime;
        private readonly long r_AttendingCount;
        private readonly long r_InterestedCount;
        private readonly long r_DeclinedCount;
        private readonly long r_MaybeCount;
        
        public MockEvent(string i_Name, DateTime i_StartTime, long i_AttendingCount, long i_InterestedCount, long i_DeclinedCount, long i_MaybeCount)
        {
            r_Name = i_Name;
            r_StartTime = i_StartTime;
            r_AttendingCount = i_AttendingCount;
            r_InterestedCount = i_InterestedCount;
            r_DeclinedCount = i_DeclinedCount;
            r_MaybeCount = i_MaybeCount;
        }

        public string Name
        {
            get { return r_Name; }
        }

        public DateTime StartTime
        {
            get { return r_StartTime; }
        }

        public long AttendingCount { get { return r_AttendingCount; } }

        public long InterestedCount { get { return r_InterestedCount; } }

        public long DeclinedCount { get { return r_DeclinedCount; } }

        public long MaybeCount { get { return r_MaybeCount; } }
    }
}
