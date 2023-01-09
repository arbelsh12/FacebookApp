using System;
using FacebookWrapper.ObjectModel;

namespace FacebookAppLogic
{
    public sealed class LoggedInUserSingelton
    {
        private static LoggedInUserSingelton s_Instance = null;
        private static object s_LockObj = new Object();
        private readonly MockData r_MockData = null;
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
    }
}
