 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookAppLogic
{
    public class MockData
    {
        public List<MockEvent> r_Events;
        public List<MockUser> r_Friends;

        public MockData()
        {
            r_Events = createMockEvents();
            r_Friends = createMockFriends();
        }

        private List<MockEvent> createMockEvents()
        {
            List<MockUser> mockFriends = new List<MockUser>();
            
            return mockFriends;
        }

        private List<MockEvent> createMockFriends()
        {
            List<MockEvent> mockEvents = new List<MockEvent> ();
            
            return mockEvents;
        }
    }
}
