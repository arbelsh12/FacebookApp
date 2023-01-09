using System;
using System.Collections.Generic;

namespace FacebookAppLogic
{
    public class MockData
    {
        private readonly List<MockUser> r_Friends;
        private readonly List<iEvent> r_Events;      

        public MockData()
        {
            r_Events = createMockEvents();
            r_Friends = createMockFriends();
        }

        private List<iEvent> createMockEvents()
        {
            List<iEvent> mockEvents = new List<iEvent>()
            {
                new MockEvent()
                {
                    m_Name ="Justin Timberlake Concert",
                    m_StartTime = new DateTime(2023, 1, 12),
                    m_AttendingCount=100,
                    m_InterestedCount = 250,
                    m_DeclinedCount = 122,
                    m_MaybeCount = 5,
                },
                new MockEvent()
                {
                    m_Name ="Jazz Festival",
                    m_StartTime = new DateTime(2023, 1, 7),
                    m_AttendingCount=200,
                    m_InterestedCount = 60,
                    m_DeclinedCount = 16,
                    m_MaybeCount = 65,
                },
                new MockEvent()
                {
                    m_Name ="Norah Jones Concert",
                    m_StartTime = new DateTime(2023, 1, 9),
                    m_AttendingCount=400,
                    m_InterestedCount = 50,
                    m_DeclinedCount = 15,
                    m_MaybeCount = 66,
                },
                new MockEvent()
                {
                    m_Name ="Cooking Class",
                    m_StartTime = new DateTime(2023, 2, 9),
                    m_AttendingCount=230,
                    m_InterestedCount = 234,
                    m_DeclinedCount = 12,
                    m_MaybeCount = 85,
                },
                new MockEvent()
                {
                    m_Name ="Ted Talk",
                    m_StartTime = new DateTime(2023, 1, 5),
                    m_AttendingCount=149,
                    m_InterestedCount = 24,
                    m_DeclinedCount = 129,
                    m_MaybeCount = 7,
                },
            };

            return mockEvents;
        }

        private List<MockUser> createMockFriends()
        {
            List<MockUser> mockFriends = new List<MockUser>()
            {
                new MockUser("Rachel", "Green", "Rachel@mock.com", FacebookWrapper.ObjectModel.User.eGender.female, "Brooklyn, NY",  "5/5/70",
                "https://pyxis.nymag.com/v1/imgs/47c/71a/130bf1e557e534b3f2be3351afc2ecf952-17-rachel-green-jewish.rsquare.w700.jpg"),
                 new MockUser("Monica", "Geller", "Monica@mock.com", FacebookWrapper.ObjectModel.User.eGender.female, "Brooklyn, NY",  "14/9/72",
                "https://pyxis.nymag.com/v1/imgs/47c/71a/130bf1e557e534b3f2be3351afc2ecf952-17-rachel-green-jewish.rsquare.w700.jpg"),
                new MockUser("Phoebe", "Bofey", "Phoebe@mock.com", FacebookWrapper.ObjectModel.User.eGender.female, "Brooklyn, NY",  "27/1/69",
                "https://i.insider.com/55df18389dd7cc0f008b64cc?width=1000&format=jpeg&auto=webp"),
                new MockUser("Ross", "Geller", "Ross@mock.com", FacebookWrapper.ObjectModel.User.eGender.male, "Brooklyn, NY",  "22/3/69",
                "https://static.wikia.nocookie.net/friends/images/a/aa/Ross_Unagi.jpeg/revision/latest/scale-to-width-down/250?cb=20200708234621"),
                new MockUser("Chandler", "Bing", "Chandler@mock.com", FacebookWrapper.ObjectModel.User.eGender.male, "Brooklyn, NY",  "12/5/71",
               "https://static.wikia.nocookie.net/friends/images/2/2f/Chandler.png/revision/latest?cb=20200604100931"),
                 new MockUser("Joey", "Tribbiani", "Joey@mock.com", FacebookWrapper.ObjectModel.User.eGender.male, "Brooklyn, NY",  "2/7/72",
              "https://img2.thejournal.ie/inline/3496837/original/?width=630&version=3496837")
            };

            return mockFriends;
        }
    
        public List<MockUser> Friends
        {
            get { return r_Friends; }
        }

        public List<iEvent> Events
        {
            get { return r_Events; }
        }
    }
}