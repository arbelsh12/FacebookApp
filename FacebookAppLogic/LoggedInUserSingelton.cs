using System;
using FacebookWrapper.ObjectModel;

namespace FacebookAppLogic
{
    public sealed class LoggedInUserSingelton
    {
        private static LoggedInUserSingelton s_Instance = null;
        private static object s_LockObj = new Object();
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
    }
}
