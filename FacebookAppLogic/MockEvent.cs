using System;

namespace FacebookAppLogic
{
    public class MockEvent : iEvent
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public long AttendingCount { get; set; }
        public long InterestedCount { get; set; }
        public long DeclinedCount { get; set; }
        public long MaybeCount { get; set; }

        public MockEvent()
        {

        }
    }
}
