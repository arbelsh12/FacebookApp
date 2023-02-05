using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FacebookWrapper.ObjectModel;

namespace FacebookAppLogic
{
    public class MockFriends : IEnumerable<MockUser>
    {
        private const int k_AllGenders = 3;
        private readonly List<MockUser> r_Friends;
        public Func<MockUser, bool> filterStrategyMethod { get; set; }

        public MockFriends()
        {
            r_Friends = createMockFriends();
            setFilterStrategyMethod(k_AllGenders);
        }

        private List<MockUser> createMockFriends()
        {
            List<MockUser> mockFriends = new List<MockUser>()
            {
                new MockUser("Rachel", "Green", "Rachel@mock.com", User.eGender.female, "Brooklyn, NY",  "5/5/70",
                "https://pyxis.nymag.com/v1/imgs/47c/71a/130bf1e557e534b3f2be3351afc2ecf952-17-rachel-green-jewish.rsquare.w700.jpg"),
                 new MockUser("Monica", "Geller", "Monica@mock.com", FacebookWrapper.ObjectModel.User.eGender.female, "Brooklyn, NY",  "14/9/72",
                "https://home.adelphi.edu/~ni21572/Monica.jpg"),
                new MockUser("Phoebe", "Bofey", "Phoebe@mock.com", User.eGender.female, "Brooklyn, NY",  "27/1/69",
                "https://i.insider.com/55df18389dd7cc0f008b64cc?width=1000&format=jpeg&auto=webp"),
                new MockUser("Ross", "Geller", "Ross@mock.com", User.eGender.male, "Brooklyn, NY",  "22/3/69",
                "https://static.wikia.nocookie.net/friends/images/a/aa/Ross_Unagi.jpeg/revision/latest/scale-to-width-down/250?cb=20200708234621"),
                new MockUser("Chandler", "Bing", "Chandler@mock.com", User.eGender.male, "Brooklyn, NY",  "12/5/71",
               "https://static.wikia.nocookie.net/friends/images/2/2f/Chandler.png/revision/latest?cb=20200604100931"),
                 new MockUser("Joey", "Tribbiani", "Joey@mock.com", User.eGender.male, "Brooklyn, NY",  "2/7/72",
              "https://img2.thejournal.ie/inline/3496837/original/?width=630&version=3496837")
            };

            return mockFriends;
        }

        public void SetFilterMethod(Func<MockUser, bool> i_filterMethod)
        {
            filterStrategyMethod = i_filterMethod;
        }

        public void UpdateGenderFilter(int i_Gender = k_AllGenders)
        {
            setFilterStrategyMethod(i_Gender);
        }

        private void setFilterStrategyMethod(int i_Gender)
        {
            switch (i_Gender)
            {
                case (int)User.eGender.female:
                    filterStrategyMethod = mockUser => mockUser.Gender == User.eGender.female;
                    break;
                case (int)User.eGender.male:
                    filterStrategyMethod = mockUser => mockUser.Gender == User.eGender.male;
                    break;
                default:
                    filterStrategyMethod = mockUser => mockUser.Gender == User.eGender.female || mockUser.Gender == User.eGender.male;
                    break;
            }
        }

        public List<MockUser> Friends
        {
            get { return r_Friends; }
        }

        public int AllGenders
        {
            get { return k_AllGenders; }
        }

        public IEnumerator<MockUser> GetEnumerator()
        {
            foreach (MockUser friend in Friends)
            {
                if (filterStrategyMethod(friend))
                {
                    yield return friend;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}