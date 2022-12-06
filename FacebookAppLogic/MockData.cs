using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookAppLogic
{
    public class MockData
    {
        private readonly List<MockEvent> r_Events;
        private readonly List<MockUser> r_Friends;

        public MockData()
        {
            r_Events = createMockEvents();
            r_Friends = createMockFriends();
        }

        private List<MockEvent> createMockEvents()
        {
            List<MockEvent> mockEvents = new List<MockEvent>();
            MockEvent event1 = new MockEvent("Justin Timberlake Concert", new DateTime(2023, 5, 12), 100, 250, 122, 5);
            MockEvent event2 = new MockEvent("Jazz Festival", new DateTime(2022, 12, 12), 200, 60, 16, 65);
            MockEvent event3 = new MockEvent("Norah Jones Concert", new DateTime(2022, 12, 7), 400, 50, 15, 66);
            MockEvent event4 = new MockEvent("Cooking Class", new DateTime(2024, 1, 1), 230, 234, 12, 85);
            MockEvent event5 = new MockEvent("Ted Talk", new DateTime(2022, 12, 5), 149, 24, 129, 7);

            mockEvents.Add(event1);
            mockEvents.Add(event2);
            mockEvents.Add(event3);
            mockEvents.Add(event4);
            mockEvents.Add(event5);

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

            r_Friends.Add(freind1);
            r_Friends.Add(freind2);
            r_Friends.Add(freind3);
            r_Friends.Add(freind4);
            r_Friends.Add(freind5);
            r_Friends.Add(freind6);

            return mockFriends;
        }

        public List<MockUser> Friends
        {
            get { return r_Friends; }
        }

        public List<MockEvent> Events
        {
            get { return r_Events; }
        }
    }
}