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

        private List<MockUser> createMockFriends()
        {
            List<MockUser> mockFriends = new List<MockUser>()
            {
                new MockUser("Rachel", "Green", "Rachel@mock.com", FacebookWrapper.ObjectModel.User.eGender.female, "Brooklyn, NY",  "5/5/70",
                "https://pyxis.nymag.com/v1/imgs/47c/71a/130bf1e557e534b3f2be3351afc2ecf952-17-rachel-green-jewish.rsquare.w700.jpg"),
                 new MockUser("Monica", "Geller", "Monica@mock.com", FacebookWrapper.ObjectModel.User.eGender.female, "Brooklyn, NY",  "14/9/72",
                "https://home.adelphi.edu/~ni21572/Monica.jpg"),
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