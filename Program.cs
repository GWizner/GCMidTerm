using System.Linq;
namespace MidTermProject2022
{
    public class Validator
    {

        public static bool getContinue()
        {
            bool result = true;
            while (true)
            {
                Console.WriteLine();
                Console.Write("Would you like to check out a book? (y/n): ");
                string choice = Console.ReadLine().ToLower().Trim();
                choice = choice.Trim();
                if (choice == "y" || choice == "yes")
                {
                    result = true;
                    break;
                }
                else if (choice == "n" || choice == "no")
                {

                    result = false;
                    break;
                }
                else
                {
                    Console.WriteLine("I do not understand your input. Please try again.");
                }
            }
            return result;
        }
        /*public static double getUserRad()
        {
            double userRad = 0;
            while (true)
            {
                while (true)
                {
                    try
                    {
                        Console.Write("Please enter a radius: ");
                        userRad = double.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Please try a number greater or less than 0.");
                        Console.WriteLine();
                    }

                }

                if (userRad == 0)
                {
                    Console.WriteLine("Please try a number greater or less than 0.");
                    Console.WriteLine();
                }
                else if (userRad != 0)
                {
                    break;
                }
            }
            return userRad;
        }*/
    }


    public class Book
    {

        public string title;
        public string author;
        //public bool status;
        //public string dueDate;

        public Book(string newTitle, string newAuthor/*, string newStatus, string newDueDate*/)
        {
            title = newTitle;
            author = newAuthor;
            //status = newStatus;
            //dueDate = newDueDate;
        }
        public static void Main(string[] args)
        {
            var book = new List<Book>() {new Book("Alice's Adventures In Wonderland", "Carroll, Lewis"),
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
                new Book("The White Company", "Doyle, Sir Arthur Conan")};



            string asimov = "Asimov";
            string carroll = "Carroll";
            string dick = "Dick";
            string doyle = "Doyle";
            string gibson = "Gibson";
            string herbert = "Herbert";
            string macDonald = "MacDonald";

            int userAns1 = 0;
            bool trueAns1 = false;
            bool keepAsk1 = true;
            bool keepAsk2 = true;
            bool keepAsk3 = true;
            var byAuthor = book.OrderBy(x => x.author)
                               .GroupBy(a => a.author)
                               .ToList();
            string y = "y";
            string yes = "yes";

            Console.WriteLine("Hello, User, Welcome to the library.");
            while (keepAsk1)
            {
                while (keepAsk2)
                {
                    MainScreen:

                    Console.WriteLine("For a list of books, please input 1. For a list of authors, please input 2: ");
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
                                        string asimovFormat = String.Format("{0, 41}", $"{bookSearch.title}");
                                        Console.WriteLine(asimovFormat);
                                        Console.ResetColor();
                                    }
                                }
                                   
                                Console.WriteLine();
                                keepAsk1 = false;
                                keepAsk2 = Validator.getContinue();
                                Console.WriteLine();
                                keepAsk3 = false;
                                
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
                                keepAsk3 = false;
                            
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
                                keepAsk3 = false;

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
                                keepAsk3 = false;

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
                                keepAsk3 = false;

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
                                keepAsk3 = false;

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
                                keepAsk3 = false;

                            }
                            else
                                Console.WriteLine("I do not recognize your input. Please try one of the available options.");
                                Console.WriteLine();
                                keepAsk3 = true;
                        }
                        keepAsk2 = Validator.getContinue();
                        Console.WriteLine();
                           
                        
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