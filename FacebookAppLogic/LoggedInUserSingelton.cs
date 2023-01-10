using System;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookAppLogic
{
    public sealed class LoggedInUserSingelton
    {
        private static LoggedInUserSingelton s_Instance = null;
        private readonly MockData r_MockData = null;
        private readonly List<iEvent> r_Events = null;
        private User m_User = null;

        private LoggedInUserSingelton()
        {
            r_MockData = new MockData();
        }

        public static LoggedInUserSingelton Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = new LoggedInUserSingelton();
                }

                return s_Instance;
            }
        }

        public User User
        {
            get
            {
                return m_User;
            }

            set
            {
                m_User = value;
            }
        }

        public MockData MockData
        {
            get
            {
                return r_MockData;
            }
        }

        public List<iEvent> Events
        {
            get
            {
                List<iEvent> events = null;

                if (r_Events == null)
                {
                    if (User.Events.Count > 0)
                    {
                        events = new List<iEvent>();

                        foreach (FacebookWrapper.ObjectModel.Event userEvent in User.Events)
                        {
                            events.Add(new Event(userEvent));
                        }
                    }
                    else if (MockData.Events.Count > 0)
                    {
                        events = MockData.Events;
                    }
                }
                else
                {
                    events = r_Events;
                }

                return events;
            }
        }
    }
}
