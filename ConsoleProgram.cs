using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBookSpace;

namespace Lab1
{
    class ConsoleProgram
    {
        static PhoneBook book = new PhoneBook();
        static void Main(string[] args)
        {
            bool isEnd = false;
            Console.WriteLine("Welcome to your Phone Book app!");
            while (!isEnd)
            {
                Console.WriteLine("\nChoose an action\n1. Create a new record\n2. Edit the record\n3. Delete the record\n4. Look through the records\n5. Look through the records in short format\n6. Show the entry\n7. Quit\n");
                Console.Write("Print the number of the action: ");
                switch(Console.ReadLine())
                {
                    case "1": 
                        AddEntry();
                        break;
                    case "2":
                        ChangeEntry();
                        break;
                    case "3":
                        DeleteEntry();
                        break;
                    case "4":
                        IterateEntries();
                        break;
                    case "5":
                        IterateEntriesShort();
                        break;
                    case "6":
                        FindEntry();
                        break;
                    case "7":
                        isEnd = true;
                        Console.WriteLine("Have a good day!~~");
                        Console.ReadKey(true);
                        break;
                    default:
                        Console.WriteLine("Hmmm.. Sorry, I don't know such command, try again =)\n");
                        Console.ReadKey(true);
                        break;
                }
            }
        }
        private static bool IsEmpty()
        {
            if (book.PageCount() == 0)
            {
                Console.WriteLine("Phone Book is empty");
                Console.ReadKey(true);
                return true;
            }
            return false;
        }
        private static void FindEntry()
        {
            if (IsEmpty()) return;
            bool success = false;
            int page = 0;
            do
            {
                Console.Write("Number of the page: ");
                try
                {
                    page = Convert.ToInt32(Console.ReadLine());
                    if (book.GetEntryByPage(page) == null)
                    {
                        success = false;
                        Console.WriteLine("There is not such page in Phone Book. Try again.");
                    }
                    else success = true;
                }
                catch (Exception ex)
                {
                    success = false;
                    Console.WriteLine("Page number is not correct. Try again.");
                }
            } while (!success);
            Console.WriteLine(book.GetEntryByPage(page).ToString());
            Console.ReadKey(true);
        }

        private static void IterateEntriesShort()
        {
            if (IsEmpty()) return;
            foreach (PhoneEntry entry in book)
            {
                Console.WriteLine(entry.ToStringShort());
                Console.ReadKey(true);
            }
        }

        private static void IterateEntries()
        {
            if (IsEmpty()) return;
            foreach (PhoneEntry entry in book)
            {
                Console.WriteLine(entry.ToString());
                Console.ReadKey(true);
            }
        }

        private static void DeleteEntry()
        {
            if (IsEmpty()) return;
            bool success = false;
            int page = 0;
            Console.Write("Number of the page: ");
            try
            {
                page = Convert.ToInt32(Console.ReadLine());
                if (book.DeleteEntry(page) < 0)
                {
                    success = false;
                    Console.WriteLine("There is not such page in Phone Book. Try again.");
                }
                else success = true;
            }
            catch (Exception ex)
            {
                success = false;
                Console.WriteLine("Page number is not correct. Try again.");
            }
        }

        private static void ChangeEntry()
        {
            if (IsEmpty()) return;
            bool success = false;
            int page = 0;
            do
            {
                Console.Write("Number of the page: ");
                try
                {
                    page = Convert.ToInt32(Console.ReadLine());
                    if (book.GetEntryByPage(page) == null)
                    {
                        success = false;
                        Console.WriteLine("There is not such page in Phone Book. Try again.");
                    }
                    else success = true;
                }
                catch (Exception ex)
                {
                    success = false;
                    Console.WriteLine("Page number is not correct. Try again.");
                }
            } while (!success);
            PhoneEntry entry = book.GetEntryByPage(page);

            Console.Write("Last Name:\n" + entry.LastName);
            entry.LastName = EditString(entry.LastName);
            Console.Write("First Name:\n" + entry.FirstName);
            entry.FirstName = EditString(entry.FirstName);
            Console.Write("Patronymic:\n" + entry.Patronymic);
            entry.Patronymic = EditString(entry.Patronymic);
            do
            {
                Console.Write("Phone:\n" + entry.GetPhone());
                success = entry.SetPhone(EditString(entry.GetPhone()));
                if (!success) Console.WriteLine("Phone isn't correct. Try again.");
            } while (!success);
            Console.Write("Country:\n" + entry.Country);
            entry.Country = EditString(entry.Country);
            do
            {
                Console.Write("Birthday:\n" + entry.GetBirthdayString());
                success = entry.SetBirthdayString(EditString(entry.GetBirthdayString()));
                if (!success) Console.WriteLine("Phone isn't correct. Try again.");
            } while (!success);
            Console.Write("Company:\n" + entry.Company);
            entry.Company = EditString(entry.Company);
            Console.Write("Position:\n" + entry.Position);
            entry.Position = EditString(entry.Position);
            Console.Write("Notes:\n" + entry.Notes);
            entry.Notes = EditString(entry.Notes);

            Console.ReadKey(true);
        }

        private static string EditString(string str) 
        {
            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey()).Key != ConsoleKey.Enter)
            {
                if (Char.IsLetter(keyInfo.KeyChar) || Char.IsDigit(keyInfo.KeyChar) || keyInfo.KeyChar == '+' || keyInfo.KeyChar == '-' || keyInfo.KeyChar == '.')
                {
                    str += keyInfo.KeyChar;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && str.Length != 0)
                {
                    Console.Write(" \b");
                    str = str.Substring(0, str.Length - 1);
                }
                else Console.Write("\b \b");
            }
            Console.WriteLine();
            return str;
        }
        private static void AddEntry()
        {
            PhoneEntry entry = book.GetEntryByPage(book.AddEntry());
            Console.Write("Page " + entry.PageNumber + "\nLast Name: ");
            entry.LastName = Console.ReadLine();
            Console.Write("First Name: ");
            entry.FirstName = Console.ReadLine();
            Console.Write("Patronymic: ");
            entry.Patronymic = Console.ReadLine();
            bool success;
            do
            {
                Console.Write("Phone: ");
                success = entry.SetPhone(Console.ReadLine());
                if (!success) Console.WriteLine("Phone isn't correct. Try again.");
            } while (!success);
            Console.Write("Country: ");
            entry.Country = Console.ReadLine();
            do
            {
                Console.Write("Birthday: ");
                success = entry.SetBirthdayString(Console.ReadLine());
                if (!success) Console.WriteLine("Phone isn't correct. Try again.");
            } while (!success);
            Console.Write("Company: ");
            entry.Company = Console.ReadLine();
            Console.Write("Position: ");
            entry.Position = Console.ReadLine();
            Console.Write("Notes: ");
            entry.Notes = Console.ReadLine();
            Console.ReadKey(true);
        }
    }
}
