using System.Linq;

namespace MidTermProject2022
{


    public class Validator
    {

        public static bool getContinue()
        {
            bool result = true;
            bool run = true;

            while (run)
            {
                Console.WriteLine();
                Console.Write("Would you like to check out a book? (y/n): ");
                string choice = Console.ReadLine().ToLower().Trim();
                choice = choice.Trim();
                if (choice == "y" || choice == "yes")
                {
                    result = true;
                    run = false;
                    break;
                }
                else if (choice == "n" || choice == "no")
                {
                    Console.WriteLine();
                    Console.WriteLine("Thank you for visiting our library, have a nice day!");
                    result = false;
                    //keepAsk3 = false;
                    break;
                }
                else
                {
                    Console.WriteLine("I do not understand your input. Please try again.");
                }
            }
            return result;
        }

    }



    public class Book
    {

        public string title { get; private set; }
        public string author { get; private set; }
        public DateTime checkOutDate;
        public DateTime dueDate;
        public bool checkedOut;

        public Book(string newTitle, string newAuthor)
        {
            title = newTitle;
            author = newAuthor;
        }

    }


    class Program
    {

        public static void Main(string[] args)
        {

            var book = new List<Book>()
            {
                new Book("Alice's Adventures In Wonderland", "Carroll, Lewis"),
                new Book("At the Back of the North Wind", "MacDonald, George"),
                new Book("Do Androids Dream of Electric Sheep?", "Dick, Philip K."),
                new Book("Dune", "Herbert, Frank"),
                new Book("Foundation", "Asimov, Isaac"),
                new Book("The Golden Key", "MacDonald, George"),
                new Book("I, Robot", "Asimov, Isaac"),
                new Book("Johnny Mnemonic", "Gibson, William"),
                new Book("Neuromancer", "Gibson, William"),
                new Book("The Princess and the Goblin", "MacDonald, George"),
                new Book("A Scanner Darkly", "Dick, Philip K."),
                new Book("The White Company", "Doyle, Sir Arthur Conan")
            };

            var booksOut = new List<Book>();


            // Creating a DateTime variable outside of IF and WHILE statements to
            // let the object exist until the program ends
            // DateTime checkout;
            TimeSpan fourteenDays = new TimeSpan(14, 0, 0, 0);
            TimeSpan noduedate = new TimeSpan(0, 0, 0, 0);


            int userAns1 = 0;
            bool trueAns1 = false;
            bool keepAsk1 = true;
            bool keepAsk2 = true;
            bool keepAsk3 = true;
            var checkedOutBooks = new List<string>();
            var byAuthor = book.OrderBy(x => x.author)
                               .GroupBy(a => a.author)
                               .ToList();


            Console.WriteLine("Hello, User, Welcome to the library.");


            while (keepAsk1)
            {


                while (keepAsk2)
                {


                MainScreen:

                    Console.WriteLine(" For a list of books, please input 1. \n For a list of authors, please input 2. \n " +
                        "To see a list of books to return enter 3. \n If you want to exit this program enter 4: ");
                    string userAnswer1 = Console.ReadLine().ToLower();
                    trueAns1 = int.TryParse(userAnswer1, out userAns1); 
                    Console.WriteLine();

                    if (userAns1 == 1)
                    {
                        foreach (var titleSearch in book)
                        {
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                string titleFormat = String.Format("{0, 41}", titleSearch.title);
                                Console.WriteLine(titleFormat);
                                Console.ResetColor();
                            }
                        }
                        Console.WriteLine();
                        keepAsk1 = false;
                        keepAsk2 = Validator.getContinue();
                        Console.WriteLine();

                        bool anyBooksToCheckOut = (book.Count == 0);


                        // Running IF STATEMENT that asks whether the user wanted to check out a book. if the book
                        // is not checked out, the code will mark the book as checked out and remove it from the list.
                        while (keepAsk2 == true)
                        {
                            if (anyBooksToCheckOut)
                            {
                                Console.WriteLine("There are NO books to check out!");
                                goto MainScreen;
                            }
                            else
                            {
                                CheckoutBookOut(book, booksOut, keepAsk2, fourteenDays);
                                keepAsk2 = false;
                                goto MainScreen;
                            }
                        }

                    }
                    else if (userAns1 == 2)
                    {
                        // Print books grouped by author
                        foreach (var authorSearch in byAuthor)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            string authorFormat = String.Format("{0, 41}", $"{authorSearch.Key}");
                            Console.WriteLine(authorFormat);
                            Console.ResetColor();
                        }

                        Console.WriteLine();
                        keepAsk1 = false;

                        while (keepAsk3)
                        {
                            Console.WriteLine("You may select an author by name, or press enter to return to the previous screen: ");
                            string authorName = Console.ReadLine().ToLower().Trim();
                            authorName = authorName.Trim();

                            if (string.IsNullOrWhiteSpace(authorName))
                            {
                                goto MainScreen;
                            }
                            else if (book.Any(x => x.author.Contains(authorName, StringComparison.CurrentCultureIgnoreCase) && !x.checkedOut))
                            {
                                foreach (var bookSearch in book)
                                {
                                    if (bookSearch.author.Contains(authorName, StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        string authorFormat = String.Format("{0, 41}", $"{bookSearch.title}");
                                        Console.WriteLine(authorFormat);
                                        Console.ResetColor();
                                    }
                                }

                                Console.WriteLine();
                                keepAsk1 = false;
                                keepAsk2 = Validator.getContinue();
                                Console.WriteLine();

                                CheckoutBookOut(book, booksOut, keepAsk2, fourteenDays);
                            }
                            else
                            {
                                Console.WriteLine("All books for this author are checked out.");
                                keepAsk3 = true;
                            }

                        }

                    }
                    else if (userAns1 == 3)
                    {
                        ReturnBook(booksOut, book, noduedate);
                        goto MainScreen;
                    }
                    else if (userAns1 == 4)
                    {
                        Console.WriteLine("Thank you for visiting our library, have a nice day!");
                        keepAsk1 = false;
                        keepAsk2 = false;
                    }

                }
            }
        }







        public static void CheckoutBookOut(List<Book> book, List<Book> bookOut, bool keepAsk2, TimeSpan fourteenDays)
        {
            //------------------------------------------------------------------------------------------------------
            // Running IF STATEMENT that asks whether the user wanted to check out a book. if the book
            // if not checked out, the code will mark the book as checked out and remove it from the list.
            //------------------------------------------------------------------------------------------------------

            bool foundBook = false;

            if (keepAsk2 == true)
            {

                Console.WriteLine("Which title above would you like to check out? Enter for None.");
                string usertitle = Console.ReadLine().ToLower();
                foreach (var current in book)
                {
                    if (current.title.Contains(usertitle, StringComparison.CurrentCultureIgnoreCase))
                    {
                        foundBook = true;
                        current.checkedOut = true;
                        current.checkOutDate = DateTime.Now;
                        current.dueDate = current.checkOutDate.Add(fourteenDays);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{current.title} checked out at: {current.checkOutDate}");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Due Date is: { current.dueDate}");
                        Console.ResetColor();
                        Console.WriteLine();
                        book.Remove(current);
                        bookOut.Add(current);
                        break;
                    }

                }

            }
            else if (foundBook == false)
            {
                Console.WriteLine("Invalid entry. The program will run again.");
            }

        }



        public static void ReturnBook(List<Book> returnList, List<Book> library, TimeSpan notDue)
        {

            bool returnListhasBooks = (returnList.Count > 0);


            if (returnListhasBooks)
            {
                Console.WriteLine("Books to Return: \n");
                foreach (var book in returnList)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{book.title} \t\t {book.author} \t\t\t\t\t {book.dueDate}");
                    Console.ResetColor();
                }

                bool runAgain = true;
                bool foundBook = false;
                while (runAgain)
                {
                    if (returnListhasBooks)
                    {
                        Console.WriteLine("\nWhich title above would you like to return? Enter for None.");
                        string usertitle = Console.ReadLine().ToLower();
                        if (String.IsNullOrWhiteSpace(usertitle))
                        {
                            runAgain = false;
                            break;
                        }
                        foreach (var current in returnList)
                        {
                            if (current.title.Contains(usertitle, StringComparison.CurrentCultureIgnoreCase))
                            {
                                foundBook = true;
                                current.checkedOut = false;
                                current.dueDate = current.checkOutDate.Add(notDue);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{current.title} \t\t {current.author} \t\t\t\t\t {current.dueDate}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.ResetColor();
                                Console.WriteLine();

                                returnList.Remove(current);
                                library.Add(current);

                                break;
                            }
                        }

                        if (foundBook == false)
                        {
                            Console.WriteLine("\nInvalid entry.");
                            runAgain = true;
                        }
                    }
                    else if (returnListhasBooks == false)
                        break;

                }
            }
            else
                Console.WriteLine("No Books to Return");

        }
    }
}

