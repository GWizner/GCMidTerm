using System.Linq;

/*
                                        LIBRARY TERMINAL
Write a console program which allows a user to search a library catalog and reserve books.

        (1) Your solution must include some kind of a book class with a title,
            author, status, and due date if checked out.
                -Status should be On Shelf or Checked Out (or other statuses you can imagine).

        (2) 12 items minimum; All stored in a list. (DONE)

        (3) Allow the user to:
                -Display the entire list of books.  Format it nicely. (DONE)
                -Search for a book by author.
                -Search for a book by title keyword.
                -Select a book from the list to check out.
                    --If it’s already checked out, let them know.
                    --If not, check it out to them and set the due date to 2 weeks from today.
                -Return a book.  (You can decide how that looks/what questions it asks.)

                                        Optional enhancements:
(Moderate) When the user quits, save the current library book list (including
due dates and statuses) to the text file so the next time the program runs, it remembers.
(Julius Caesar) Burn down the library of Alexandria and set human Civilization back by a few hundred years.

*/




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


        //------------------------------------------------------------------------------------------------------
        //Overloaded Method to take in author name the user typed.
        //This method will run code that lets the user choose to checkout a book or not
        //------------------------------------------------------------------------------------------------------
        /*public static bool getContinue(string author)
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
                    //Console.WriteLine();
                    //Console.WriteLine("Thank you for visiting our library, have a nice day!");
                    result = false;
                    break;
                }
                else
                {
                    Console.WriteLine("I do not understand your input. Please try again.");
                }
            }
            return result;
        }*/

    }



    public class Book
    {

        public string title { get; private set; }
        public string author { get; private set; }
        public DateTime checkOut;
        public DateTime dueDate;
        public bool checkedOut;

        public Book(string newTitle, string newAuthor/*, string newStatus, string newDueDate*/)
        {
            title = newTitle;
            author = newAuthor;
            //status = newStatus;
            //dueDate = newDueDate;
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


            string asimov = "Asimov";
            string carroll = "Carroll";
            string dick = "Dick";
            string doyle = "Doyle";
            string gibson = "Gibson";
            string herbert = "Herbert";
            string macDonald = "MacDonald";






            // Creating a DateTime variable outside of IF and WHILE statements to
            // let the object exist until the program ends
            // DateTime checkout;
            TimeSpan fourteenDays = new TimeSpan(14, 0, 0, 0);




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

                    Console.WriteLine("For a list of books, please input 1. For a list of authors, please input 2. If you would like" +
                        " to leave input 3: ");
                    string userAnswer1 = Console.ReadLine().ToLower();
                    trueAns1 = int.TryParse(userAnswer1, out userAns1);
                    Console.WriteLine();

                    if (userAns1 == 1)
                    {
                        foreach (var titleSearch in book)
                        {
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                string titleFormat = String.Format("{0, 41}", $"{titleSearch.title}");
                                Console.WriteLine(titleFormat);
                                Console.ResetColor();
                            }
                        }
                        Console.WriteLine();
                        keepAsk1 = false;
                        keepAsk2 = Validator.getContinue();
                        Console.WriteLine();

                        //------------------------------------------------------------------------------------------------------
                        // Running IF STATEMENT that asks whether the user wanted to check out a book. if the book
                        // is not checked out, the code will mark the book as checked out and remove it from the list.
                        //------------------------------------------------------------------------------------------------------
                        while (keepAsk2 == true)
                        {
                            Console.WriteLine("Please enter the title of the book you would like to check out, or press enter return to the " +
                                "previous screen: ");
                            string userTitle = Console.ReadLine().ToLower();

                            if (String.IsNullOrWhiteSpace(userTitle))
                            {
                                goto MainScreen;
                            }
                            foreach (var current in book)
                            {
                                if (current.title.ToLower() == userTitle.ToLower())
                                {
                                    current.checkedOut = true;
                                    current.checkOut = DateTime.Now;
                                    current.dueDate = current.checkOut.Add(fourteenDays);
                                    checkedOutBooks.Add(userTitle);

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"{current.title} checked out at: {current.checkOut}");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"Due Date is: {current.dueDate}");
                                    Console.ResetColor();
                                    Console.WriteLine();
                                    book.Remove(current);
                                    keepAsk2 = true;
                                    break;
                                }
                                else
                                {
                                    keepAsk2 = false;
                                }
                            }
                        }

                        //------------------------------------------------------------------------------------------------------
                        // Running FOR LOOP to show list of titles by author
                        // so user can see whats remaining
                        //------------------------------------------------------------------------------------------------------
                        foreach (var titleSearch in checkedOutBooks)
                        {
                            for (int currBookNo = 0; currBookNo < book.Count; currBookNo++)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                string titleFormat = String.Format("{0, 41}", $"{titleSearch}");
                                Console.ResetColor();

                                if (currBookNo == 1)
                                {
                                    Console.WriteLine("You have checked out: ");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine(titleSearch);
                                    Console.ResetColor();
                                    Console.WriteLine();
                                }
                            }
                        }

                    }
                    else if (userAns1 == 2)
                    {
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
                            Console.WriteLine("You may select an author by name, or press enter return to the previous screen: ");
                            string authorName = Console.ReadLine().ToLower().Trim();
                            authorName = authorName.Trim();

                            if (string.IsNullOrWhiteSpace(authorName))
                            {
                                goto MainScreen;
                            }
                            else if (authorName.Contains("asimov"))
                            {
                                foreach (var bookSearch in book)
                                {
                                    if (bookSearch.author == "Asimov, Isaac")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        string carrollFormat = String.Format("{0, 41}", $"{bookSearch.title}");
                                        Console.WriteLine(carrollFormat);
                                        Console.ResetColor();
                                    }
                                }

                                Console.WriteLine();
                                keepAsk1 = false;
                                keepAsk2 = Validator.getContinue();
                                Console.WriteLine();
                                //keepAsk3 = false;

                                //------------------------------------------------------------------------------------------------------
                                // Running IF STATEMENT that asks whether the user wanted to check out a book. if the book
                                // if not checked out, the code will mark the book as checked out and remove it from the list.
                                //------------------------------------------------------------------------------------------------------
                                if (keepAsk2 == true)
                                {
                                    Console.WriteLine("Which title above would you like to check out? Enter for None.");
                                    string usertitle = Console.ReadLine().ToLower();

                                    foreach (var current in book)
                                    {
                                        if (current.title.ToLower() == usertitle.ToLower())
                                        {
                                            current.checkedOut = true;
                                            current.checkOut = DateTime.Now;
                                            current.dueDate = current.checkOut.Add(fourteenDays);

                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine($"{current.title} checked out at: {current.checkOut}");
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine($"Due Date is: {current.dueDate}");
                                            Console.ResetColor();
                                            Console.WriteLine();
                                            book.Remove(current);
                                            break;
                                        }
                                    }

                                }

                                //------------------------------------------------------------------------------------------------------
                                // Running FOR LOOP to show list of titles by author
                                // so user can see whats remaining
                                //------------------------------------------------------------------------------------------------------
                                foreach (var bookSearch in book)
                                {
                                    if (bookSearch.author == "Asimov, Isaac")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        string carrollFormat = String.Format("{0, 41}", $"{bookSearch.title}");
                                        Console.WriteLine(carrollFormat);
                                        Console.ResetColor();
                                    }
                                }

                            }
                            else if (authorName.Contains("carroll"))
                            {
                                foreach (var bookSearch in book)
                                {
                                    if (bookSearch.author == "Carroll, Lewis")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        string carrollFormat = String.Format("{0, 41}", $"{bookSearch.title}");
                                        Console.WriteLine(carrollFormat);
                                        Console.ResetColor();
                                    }
                                }

                                Console.WriteLine();
                                keepAsk1 = false;
                                keepAsk2 = Validator.getContinue();
                                Console.WriteLine();
                                //keepAsk3 = false;

                                //------------------------------------------------------------------------------------------------------
                                // Running IF STATEMENT that asks whether the user wanted to check out a book. if the book
                                // if not checked out, the code will mark the book as checked out and remove it from the list.
                                //------------------------------------------------------------------------------------------------------
                                if (keepAsk2 == true)
                                {
                                    Console.WriteLine("Which title above would you like to check out? Enter for None.");
                                    string usertitle = Console.ReadLine().ToLower();

                                    foreach (var current in book)
                                    {
                                        if (current.title.ToLower() == usertitle.ToLower())
                                        {
                                            current.checkedOut = true;
                                            current.checkOut = DateTime.Now;
                                            current.dueDate = current.checkOut.Add(fourteenDays);

                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine($"{current.title} checked out at: {current.checkOut}");
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine($"Due Date is: {current.dueDate}");
                                            Console.ResetColor();
                                            Console.WriteLine();
                                            book.Remove(current);
                                            break;
                                        }
                                    }

                                }

                                //------------------------------------------------------------------------------------------------------
                                // Running FOR LOOP to show list of titles by author
                                // so user can see whats remaining
                                //------------------------------------------------------------------------------------------------------
                                foreach (var bookSearch in book)
                                {
                                    if (bookSearch.author == "Carroll, Lewis")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        string carrollFormat = String.Format("{0, 41}", $"{bookSearch.title}");
                                        Console.WriteLine(carrollFormat);
                                        Console.ResetColor();
                                    }
                                }

                            }
                            else if (authorName.Contains("dick"))//Don't be immature
                            {
                                foreach (var bookSearch in book)
                                {
                                    if (bookSearch.author == "Dick, Philip K.")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        string kDickFormat = String.Format("{0, 41}", $"{bookSearch.title}");
                                        Console.WriteLine(kDickFormat);
                                        Console.ResetColor();
                                    }
                                }

                                Console.WriteLine();
                                keepAsk1 = false;
                                keepAsk2 = Validator.getContinue();
                                Console.WriteLine();
                                //keepAsk3 = false;

                                //------------------------------------------------------------------------------------------------------
                                // Running IF STATEMENT that asks whether the user wanted to check out a book. if the book
                                // if not checked out, the code will mark the book as checked out and remove it from the list.
                                //------------------------------------------------------------------------------------------------------
                                if (keepAsk2 == true)
                                {
                                    Console.WriteLine("Which title above would you like to check out? Enter for None.");
                                    string usertitle = Console.ReadLine().ToLower();

                                    foreach (var current in book)
                                    {
                                        if (current.title.ToLower() == usertitle.ToLower())
                                        {
                                            current.checkedOut = true;
                                            current.checkOut = DateTime.Now;
                                            current.dueDate = current.checkOut.Add(fourteenDays);

                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine($"{current.title} checked out at: {current.checkOut}");
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine($"Due Date is: {current.dueDate}");
                                            Console.ResetColor();
                                            Console.WriteLine();
                                            book.Remove(current);
                                            break;
                                        }
                                    }

                                }

                                //------------------------------------------------------------------------------------------------------
                                // Running FOR LOOP to show list of titles by author
                                // so user can see whats remaining
                                //------------------------------------------------------------------------------------------------------
                                foreach (var bookSearch in book)
                                {
                                    if (bookSearch.author == "Dick, Philip K.")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        string kDickFormat = String.Format("{0, 41}", $"{bookSearch.title}");
                                        Console.WriteLine(kDickFormat);
                                        Console.ResetColor();
                                    }
                                }

                            }
                            else if (authorName.Contains("doyle"))
                            {
                                foreach (var bookSearch in book)
                                {
                                    if (bookSearch.author == "Doyle, Sir Arthur Conan")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        string doyleFormat = String.Format("{0, 41}", $"{bookSearch.title}");
                                        Console.WriteLine(doyleFormat);
                                        Console.ResetColor();
                                    }
                                }

                                Console.WriteLine();
                                keepAsk1 = false;
                                keepAsk2 = Validator.getContinue();
                                Console.WriteLine();
                                //keepAsk3 = false;

                                //------------------------------------------------------------------------------------------------------
                                // Running IF STATEMENT that asks whether the user wanted to check out a book. if the book
                                // if not checked out, the code will mark the book as checked out and remove it from the list.
                                //------------------------------------------------------------------------------------------------------
                                if (keepAsk2 == true)
                                {
                                    Console.WriteLine("Which title above would you like to check out? Enter for None.");
                                    string usertitle = Console.ReadLine().ToLower();

                                    foreach (var current in book)
                                    {
                                        if (current.title.ToLower() == usertitle.ToLower())
                                        {
                                            current.checkedOut = true;
                                            current.checkOut = DateTime.Now;
                                            current.dueDate = current.checkOut.Add(fourteenDays);

                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine($"{current.title} checked out at: {current.checkOut}");
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine($"Due Date is: {current.dueDate}");
                                            Console.ResetColor();
                                            Console.WriteLine();
                                            book.Remove(current);
                                            break;
                                        }
                                    }

                                }

                                //------------------------------------------------------------------------------------------------------
                                // Running FOR LOOP to show list of titles by author
                                // so user can see whats remaining
                                //------------------------------------------------------------------------------------------------------
                                foreach (var bookSearch in book)
                                {
                                    if (bookSearch.author == "Doyle, Sir Arthur Conan")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        string doyleFormat = String.Format("{0, 41}", $"{bookSearch.title}");
                                        Console.WriteLine(doyleFormat);
                                        Console.ResetColor();
                                    }
                                }

                            }
                            else if (authorName.Contains("gibson"))
                            {
                                foreach (var bookSearch in book)
                                {
                                    if (bookSearch.author == "Gibson, William")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        string gibsonFormat = String.Format("{0, 41}", $"{bookSearch.title}");
                                        Console.WriteLine(gibsonFormat);
                                        Console.ResetColor();
                                    }
                                }

                                Console.WriteLine();
                                keepAsk1 = false;
                                keepAsk2 = Validator.getContinue();
                                Console.WriteLine();
                                //keepAsk3 = false;


                                //------------------------------------------------------------------------------------------------------
                                // Running IF STATEMENT that asks whether the user wanted to check out a book. if the book
                                // if not checked out, the code will mark the book as checked out and remove it from the list.
                                //------------------------------------------------------------------------------------------------------
                                if (keepAsk2 == true)
                                {
                                    Console.WriteLine("Which title above would you like to check out? Enter for None.");
                                    string usertitle = Console.ReadLine().ToLower();

                                    foreach (var current in book)
                                    {
                                        if (current.title.ToLower() == usertitle.ToLower())
                                        {
                                            current.checkedOut = true;
                                            current.checkOut = DateTime.Now;
                                            current.dueDate = current.checkOut.Add(fourteenDays);

                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine($"{current.title} checked out at: {current.checkOut}");
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine($"Due Date is: {current.dueDate}");
                                            Console.ResetColor();
                                            Console.WriteLine();
                                            book.Remove(current);
                                            break;
                                        }
                                    }

                                }

                                //------------------------------------------------------------------------------------------------------
                                // Running FOR LOOP to show list of titles by author
                                // so user can see whats remaining
                                //------------------------------------------------------------------------------------------------------
                                foreach (var bookSearch in book)
                                {
                                    if (bookSearch.author == "Gibson, William")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        string gibsonFormat = String.Format("{0, 41}", $"{bookSearch.title}");
                                        Console.WriteLine(gibsonFormat);
                                        Console.ResetColor();
                                    }
                                }

                            }
                            else if (authorName.Contains("herbert"))
                            {
                                foreach (var bookSearch in book)
                                {
                                    if (bookSearch.author == "Herbert, Frank")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        string herbertFormat = String.Format("{0, 41}", $"{bookSearch.title}");
                                        Console.WriteLine(herbertFormat);
                                        Console.ResetColor();
                                    }
                                }

                                Console.WriteLine();
                                keepAsk1 = false;
                                keepAsk2 = Validator.getContinue();
                                Console.WriteLine();
                                //keepAsk3 = false;

                                //------------------------------------------------------------------------------------------------------
                                // Running IF STATEMENT that asks whether the user wanted to check out a book. if the book
                                // is not checked out, the code will mark the book as checked out and remove it from the list.
                                //------------------------------------------------------------------------------------------------------
                                if (keepAsk2 == true)
                                {
                                    Console.WriteLine("Which title above would you like to check out? Enter for None.");
                                    string usertitle = Console.ReadLine().ToLower();

                                    foreach (var current in book)
                                    {
                                        if (current.title.ToLower() == usertitle.ToLower())
                                        {
                                            current.checkedOut = true;
                                            current.checkOut = DateTime.Now;
                                            current.dueDate = current.checkOut.Add(fourteenDays);

                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine($"{current.title} checked out at: {current.checkOut}");
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine($"Due Date is: {current.dueDate}");
                                            Console.ResetColor();
                                            Console.WriteLine();
                                            book.Remove(current);
                                            break;
                                        }
                                    }

                                }

                                //------------------------------------------------------------------------------------------------------
                                // Running FOR LOOP to show list of titles by author
                                // so user can see whats remaining
                                //------------------------------------------------------------------------------------------------------
                                foreach (var bookSearch in book)
                                {
                                    if (bookSearch.author == "Herbert, Frank")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        string herbertFormat = String.Format("{0, 41}", $"{bookSearch.title}");
                                        Console.WriteLine(herbertFormat);
                                        Console.ResetColor();
                                    }
                                }
                            }
                            else if (authorName.Contains("macdonald"))
                            {
                                foreach (var bookSearch in book)
                                {
                                    if (bookSearch.author == "MacDonald, George")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        string macDonaldFormat = String.Format("{0,41}", $"{ bookSearch.title}");
                                        Console.WriteLine(macDonaldFormat);
                                        Console.ResetColor();
                                    }
                                }

                                Console.WriteLine();
                                keepAsk1 = false;
                                keepAsk2 = Validator.getContinue();
                                Console.WriteLine();
                                //keepAsk3 = false;

                                //------------------------------------------------------------------------------------------------------
                                // Running IF STATEMENT that asks whether the user wanted to check out a book. if the book
                                // if not checked out, the code will mark the book as checked out and remove it from the list.
                                //------------------------------------------------------------------------------------------------------
                                if (keepAsk2 == true)
                                {
                                    Console.WriteLine("Which title above would you like to check out? Enter for None.");
                                    string usertitle = Console.ReadLine().ToLower();

                                    foreach (var current in book)
                                    {
                                        if (current.title.ToLower() == usertitle.ToLower())
                                        {
                                            current.checkedOut = true;
                                            current.checkOut = DateTime.Now;
                                            current.dueDate = current.checkOut.Add(fourteenDays);

                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine($"{current.title} checked out at: {current.checkOut}");
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine($"Due Date is: {current.dueDate}");
                                            Console.ResetColor();
                                            Console.WriteLine();
                                            book.Remove(current);
                                            break;
                                        }
                                    }

                                }

                                //------------------------------------------------------------------------------------------------------
                                // Running FOR LOOP to show list of titles by author
                                // so user can see whats remaining
                                //------------------------------------------------------------------------------------------------------
                                foreach (var bookSearch in book)
                                {
                                    if (bookSearch.author == "MacDonald, George")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        string macDonaldFormat = String.Format("{0,41}", $"{ bookSearch.title}");
                                        Console.WriteLine(macDonaldFormat);
                                        Console.ResetColor();
                                    }
                                }
                            }
                            else
                                Console.WriteLine("I do not recognize your input. Please try one of the available options.");
                            Console.WriteLine();
                            keepAsk3 = true;
                        }
                        //keepAsk2 = Validator.getContinue();
                        //Console.WriteLine();


                    }
                    else if (userAns1 == 3)
                    {
                        foreach (var titleSearch in checkedOutBooks)
                        {
                            for (int currBookNo = 0; currBookNo < book.Count; currBookNo++)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                string titleFormat = String.Format("{0, 41}", $"{titleSearch}");
                                Console.ResetColor();

                                if (currBookNo == 1)
                                {
                                    Console.WriteLine("You have checked out: ");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine(titleSearch);
                                    Console.ResetColor();
                                    Console.WriteLine();
                                }
                            }
                        }
                        Console.WriteLine("Thank you for visiting our library, have a nice day!");
                        keepAsk1 = false;
                        keepAsk2 = false;
                    }
                    else
                    {
                        Console.WriteLine("I do not recognize your input. Please try one of the available options.");
                        Console.WriteLine();
                        keepAsk1 = true;
                    }
                }
            }
        }
    }
}
