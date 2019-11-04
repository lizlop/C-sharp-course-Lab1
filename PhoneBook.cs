using System.Collections;
using System.Collections.Generic;

namespace PhoneBookSpace
{
    public class PhoneBook
    {
        private Dictionary<int, PhoneEntry> phoneBook;
        public int LastPage { get; private set; }

        public PhoneBook()
        {
            phoneBook = new Dictionary<int, PhoneEntry>();
            LastPage = 0;
        }

        public int PageCount()
        {
            return phoneBook.Count;
        }
        public PhoneEntry GetEntryByPage(int page)
        {
            return phoneBook.ContainsKey(page) ? phoneBook[page] : null;
        }
        public int AddEntry() 
        {
            phoneBook.Add(++LastPage, new PhoneEntry(LastPage));
            return LastPage;
        }
        public int DeleteEntry(int page)
        {
            if (!phoneBook.ContainsKey(page)) return -1;
            if (phoneBook.Remove(page)) return 0;
            else return -2;
        }
        public IEnumerator GetEnumerator()
        {
            foreach (KeyValuePair<int, PhoneEntry> entry in phoneBook)
            {
                yield return entry.Value;
            }
        }
    }
}
