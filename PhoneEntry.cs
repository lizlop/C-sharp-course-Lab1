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
        public string Phone { get; private set; }
        public bool SetPhone(string value)
        {
            if (Regex.Match(value, phonePattern).Success)
            {
                Phone = value;
                return true;
            }
            else return false;
        }
        public string Country { get; set; }
        public DateTime Birthday { get; set; }
        public bool SetBirthday(string value)
        {
            if (value == "" || value == "-")
            {
                Birthday = DateTime.MinValue;
                return true;
            }
            DateTime date = new DateTime();
            if (DateTime.TryParse(value, out date))
            {
                Birthday = date;
                return true;
            }
            else return false;
        }
        public string GetBirthday() 
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
                "\nPhone: " + Phone +
                "\nCountry: " + Country +
                "\nBirthday: " + GetBirthday() +
                "\nCompany: " + Company +
                "\nPosition: " + Position +
                "\nNotes: " + Notes;
        }

        public string ToStringShort()
        {
            return "\nPage " + PageNumber +
                "\n" + FirstName + " " + LastName +
                "\n" + Phone;
        }
    }
}
