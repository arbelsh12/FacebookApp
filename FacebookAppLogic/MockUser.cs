using System;
using static FacebookWrapper.ObjectModel.User;

namespace FacebookAppLogic
{
    public class MockUser
    {
        private readonly string r_Hometown;
        private readonly string r_FirstName;
        private readonly string r_LastName;
        private readonly string r_Name;
        private readonly string r_BirthDate;
        private readonly string r_Email;
        private readonly string r_PictureURL;
        private readonly eGender r_Gender;

        public MockUser(string i_FirstName, string i_LastName, string i_Email, eGender i_Gender, string i_Hometown, string i_BirthDate, string i_Url)
        {
            r_Email = i_Email;
            r_FirstName = i_FirstName;
            r_LastName = i_LastName;
            r_Gender = i_Gender;
            r_Name = i_FirstName + " " + i_LastName;
            r_PictureURL = i_Url;
            r_BirthDate = i_BirthDate;
            r_Hometown = i_Hometown;
        }

        public string PictureURL
        {
            get { return r_PictureURL; }
        }

        public string Hometown
        {
            get { return r_Hometown; }
        }

        public string FirstName
        {
            get { return r_FirstName; }
        }

        public string LastName
        {
            get { return r_LastName; }
        }

        public eGender Gender
        {
            get { return r_Gender; }
        }

        public string Name
        {
            get { return r_Name; }
        }

        public string BirthDate
        {
            get { return r_BirthDate; } 
        }

        public string Email
        {
            get { return r_Email; }
        }
    }
}
