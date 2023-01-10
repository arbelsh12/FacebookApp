using System;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookAppLogic
{
    public sealed class LoggedInUserSingelton
    {
        private static LoggedInUserSingelton s_Instance = null;
<<<<<<< HEAD
        private readonly MockData r_MockData = null;
        private List<iEvent> m_Events = null;
        private User m_User = null;
=======
        private static object s_LockObj = new Object();
        private readonly List<iEvent> r_Events = null;        
        private readonly MockData r_MockData;
        public User User { get; set; }
>>>>>>> 3ca91680a0025b00854093465be40b27174e8e86

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
                    lock(s_LockObj)
                    {
                        if(s_Instance == null)
                        {
                            s_Instance = new LoggedInUserSingelton();
                        }
                    }
                }

                return s_Instance;
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
                if (m_Events == null)
                {
                    if (User.Events.Count > 0)
                    {
                        m_Events = new List<iEvent>();

                        foreach (FacebookWrapper.ObjectModel.Event userEvent in User.Events)
                        {
                            m_Events.Add(new Event(userEvent));
                        }
                    }
                    else if (MockData.Events.Count > 0)
                    {
                        m_Events = MockData.Events;
                    }
                }

                return m_Events;
            }

            private set { }
        }
    }
}
