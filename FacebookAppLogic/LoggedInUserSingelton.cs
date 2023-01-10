using System;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookAppLogic
{
    public sealed class LoggedInUserSingelton
    {
        private static LoggedInUserSingelton s_Instance = null;
        private static object s_LockObj = new Object();
        private readonly List<iEvent> r_Events = null;        
        private readonly MockData r_MockData;
        public User User { get; set; }

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
