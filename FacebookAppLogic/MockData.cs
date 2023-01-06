using System;
using System.Collections.Generic;

namespace FacebookAppLogic
{
    public class MockData
    {
        private readonly List<MockUser> r_Friends;
        public List<iEvent> m_Events { get; }        

        public MockData()
        {
            m_Events = createMockEvents();
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
                    m_LegacyEvent = new FacebookWrapper.ObjectModel.Event(),
                },
                new MockEvent()
                {
                    m_Name ="Jazz Festival",
                    m_StartTime = new DateTime(2023, 1, 7),
                    m_AttendingCount=200,
                    m_InterestedCount = 60,
                    m_DeclinedCount = 16,
                    m_MaybeCount = 65,
                    m_LegacyEvent = new FacebookWrapper.ObjectModel.Event(),
                },
                new MockEvent()
                {
                    m_Name ="Norah Jones Concert",
                    m_StartTime = new DateTime(2023, 1, 9),
                    m_AttendingCount=400,
                    m_InterestedCount = 50,
                    m_DeclinedCount = 15,
                    m_MaybeCount = 66,
                    m_LegacyEvent = new FacebookWrapper.ObjectModel.Event(),
                },
                new MockEvent()
                {
                    m_Name ="Cooking Class",
                    m_StartTime = new DateTime(2023, 2, 9),
                    m_AttendingCount=230,
                    m_InterestedCount = 234,
                    m_DeclinedCount = 12,
                    m_MaybeCount = 85,
                    m_LegacyEvent = new FacebookWrapper.ObjectModel.Event(),
                },
                new MockEvent()
                {
                    m_Name ="Ted Talk",
                    m_StartTime = new DateTime(2023, 1, 5),
                    m_AttendingCount=149,
                    m_InterestedCount = 24,
                    m_DeclinedCount = 129,
                    m_MaybeCount = 7,
                    m_LegacyEvent = new FacebookWrapper.ObjectModel.Event(),
                },
            };

            return mockEvents;
        }

        private List<MockUser> createMockFriends()
        {
            List<MockUser> mockFriends = new List<MockUser>();

            MockUser freind1 = new MockUser();
            freind1.Name = "Rachel Green";
            freind1.FirstName = "Rachel";
            freind1.LastName = "Green";
            freind1.Email = "Rachel@mock.com";
            freind1.Hometown = "Brooklyn, NY";
            freind1.Gender = FacebookWrapper.ObjectModel.User.eGender.female;
            freind1.BirthDate = "5/5/70";
            freind1.PictureURL = "https://pyxis.nymag.com/v1/imgs/47c/71a/130bf1e557e534b3f2be3351afc2ecf952-17-rachel-green-jewish.rsquare.w700.jpg";

            MockUser freind2 = new MockUser();
            freind2.Name = "Monica Geller";
            freind2.FirstName = "Monica";
            freind2.LastName = "Geller";
            freind2.Email = "Monica@mock.com";
            freind2.Hometown = "Brooklyn, NY";
            freind2.Gender = FacebookWrapper.ObjectModel.User.eGender.female;
            freind2.BirthDate = "14/9/72";
            freind2.PictureURL = "https://home.adelphi.edu/~ni21572/Monica.jpg";

            MockUser freind3 = new MockUser();
            freind3.Name = "Phoebe Bofey";
            freind3.FirstName = "Phoebe";
            freind3.LastName = "Bofey";
            freind3.Email = "Phoebe@mock.com";
            freind3.Hometown = "Brooklyn, NY";
            freind3.Gender = FacebookWrapper.ObjectModel.User.eGender.female;
            freind3.BirthDate = "27/1/69";
            freind3.PictureURL = "https://i.insider.com/55df18389dd7cc0f008b64cc?width=1000&format=jpeg&auto=webp";

            MockUser freind4 = new MockUser();
            freind4.Name = "Ross Geller";
            freind4.FirstName = "Ross";
            freind4.LastName = "Geller";
            freind4.Email = "Ross@mock.com";
            freind4.Hometown = "Brooklyn, NY";
            freind4.Gender = FacebookWrapper.ObjectModel.User.eGender.male;
            freind4.BirthDate = "22/3/69";
            freind4.PictureURL = "https://static.wikia.nocookie.net/friends/images/a/aa/Ross_Unagi.jpeg/revision/latest/scale-to-width-down/250?cb=20200708234621";

            MockUser freind5 = new MockUser();
            freind5.Name = "Chandler Bing";
            freind5.FirstName = "Chandler";
            freind5.LastName = "Bing";
            freind5.Email = "Chandler@mock.com";
            freind5.Hometown = "Brooklyn, NY";
            freind5.Gender = FacebookWrapper.ObjectModel.User.eGender.male;
            freind5.BirthDate = "12/5/71";
            freind5.PictureURL = "https://static.wikia.nocookie.net/friends/images/2/2f/Chandler.png/revision/latest?cb=20200604100931";

            MockUser freind6 = new MockUser();
            freind6.Name = "Joey Tribbiani";
            freind6.FirstName = "Joey";
            freind6.LastName = "Tribbiani";
            freind6.Email = "Joey@mock.com";
            freind6.Hometown = "Brooklyn, NY";
            freind6.Gender = FacebookWrapper.ObjectModel.User.eGender.male;
            freind6.BirthDate = "2/10/72";
            freind6.PictureURL = "https://img2.thejournal.ie/inline/3496837/original/?width=630&version=3496837";

            mockFriends.Add(freind1);
            mockFriends.Add(freind2);
            mockFriends.Add(freind3);
            mockFriends.Add(freind4);
            mockFriends.Add(freind5);
            mockFriends.Add(freind6);

            return mockFriends;
        }

        public List<MockUser> Friends
        {
            get { return r_Friends; }
        }
    }
}