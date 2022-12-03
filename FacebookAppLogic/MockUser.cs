using System;
using static FacebookWrapper.ObjectModel.User;

namespace FacebookAppLogic
{
    public class MockUser
    {
        private string m_Hometown;
        private string m_FirstName;
        private string m_LastName;
        private string m_Name;
        private string m_BirthDate;
        private string m_Email;
        private string m_PictureURL;
        private eGender m_Gender;

        public MockUser(string i_FirstName, string i_LastName, string i_Email, eGender i_Gender)
        {
            m_Email = i_Email;
            m_FirstName = i_FirstName;
            m_LastName = i_LastName;
            m_Gender = i_Gender;
        }

        public MockUser()
        {

        }

        public string PictureURL
        {
            get { return m_PictureURL; }
            set { m_PictureURL = value; }
        }

        public string Hometown
        {
            get { return m_Hometown; }
            set { m_Hometown = value; }
        }

        public string FirstName
        {
            get { return m_FirstName; }
            set { m_FirstName = value; }
        }

        public string LastName
        {
            get { return m_LastName; }
            set { m_LastName = value; }
        }

        public eGender Gender
        {
            get { return m_Gender; }
            set { m_Gender = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public string BirthDate
        {
            get { return m_BirthDate; } 
            set { m_BirthDate = value; }
        }

        public string Email
        {
            get { return m_Email; }
            set { m_Email = value; }
        }
    }
}
