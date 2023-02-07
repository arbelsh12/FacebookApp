using System;
using System.Collections.Generic;

namespace FacebookAppLogic
{
    public class MockData
    {
        private readonly List<iEvent> r_Events;      

        public MockData()
        {
            r_Events = createMockEvents();
        }

        private List<iEvent> createMockEvents()
        {
            List<iEvent> mockEvents = new List<iEvent>()
            {
                new MockEvent()
                {
                    Name ="Justin Timberlake Concert",
                    StartTime = new DateTime(2023, 2, 12),
                    AttendingCount=100,
                    InterestedCount = 250,
                    DeclinedCount = 122,
                    MaybeCount = 5,
                },
                new MockEvent()
                {
                    Name ="Jazz Festival",
                    StartTime = new DateTime(2023, 3, 7),
                    AttendingCount=200,
                    InterestedCount = 60,
                    DeclinedCount = 16,
                    MaybeCount = 65,
                },
                new MockEvent()
                {
                    Name ="Norah Jones Concert",
                    StartTime = new DateTime(2023, 2, 27),
                    AttendingCount=400,
                    InterestedCount = 50,
                    DeclinedCount = 15,
                    MaybeCount = 66,
                },
                new MockEvent()
                {
                    Name ="Cooking Class",
                    StartTime = new DateTime(2023, 2, 20),
                    AttendingCount=230,
                    InterestedCount = 234,
                    DeclinedCount = 12,
                    MaybeCount = 85,
                },
                new MockEvent()
                {
                    Name ="Ted Talk",
                    StartTime = new DateTime(2023, 2, 5),
                    AttendingCount=149,
                    InterestedCount = 24,
                    DeclinedCount = 129,
                    MaybeCount = 7,
                },
            };

            return mockEvents;
        }

        public List<iEvent> Events
        {
            get { return r_Events; }
        }
    }
}