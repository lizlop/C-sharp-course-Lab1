using System;
using System.Text.RegularExpressions;

namespace PhoneBookSpace
{
    public class PhoneEntry
    {
        public int PageNumber { get; private set; }
        static readonly string phonePattern = "^[+]?[0-9-]{9,15}$";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; } 

        private string phone;
        public string GetPhone()
        {
            return phone;
        }
        public bool SetPhone(string value)
        {
            if (Regex.Match(value, phonePattern).Success)
            {
                phone = value;
                return true;
            }
            else return false;
        }
        public string Country { get; set; }

        private DateTime birthday;
        public DateTime Birthday { get; set; }
        public bool SetBirthdayString(string value)
        {
            if (value == "" || value == "-")
            {
                birthday = DateTime.MinValue;
                return true;
            }
            if (DateTime.TryParse(value, out DateTime date))
            {
                birthday = date;
                return true;
            }
            else return false;
        }
        public string GetBirthdayString() 
        {
            return Birthday.Equals(DateTime.MinValue) ? "" : Birthday.ToShortDateString();
        }
        public string Company { get; set; }
        public string Position { get; set; }
        public string Notes { get; set; }

        public PhoneEntry(int p)
        {
            PageNumber = p;
        }

        public override string ToString()
        {
            return "\nPage " + PageNumber +
                "\nLast Name: " + LastName +
                "\nFirst Name: " + FirstName +
                "\nPatronymic: " + Patronymic +
                "\nPhone: " + phone +
                "\nCountry: " + Country +
                "\nBirthday: " + GetBirthdayString() +
                "\nCompany: " + Company +
                "\nPosition: " + Position +
                "\nNotes: " + Notes;
        }

        public string ToStringShort()
        {
            return "\nPage " + PageNumber +
                "\n" + FirstName + " " + LastName +
                "\n" + phone;
        }
    }
}
