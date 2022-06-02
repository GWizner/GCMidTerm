namespace MidTermProject2022
{
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
            var book = new List<Book>() { new Book("Foundation", "Isaac Asimov"), new Book("I, Robot", "Isaac Asimov"),
                new Book("Alice's Adventures In Wonderland", "Lewis Carroll"), new Book("Do Androids Dream of Electric Sheep?", "Philip K. Dick"),
                new Book("A Scanner Darkly", "Philip K. Dick"), new Book("The White Company", "Sir Arthur Conan Doyle"),
                new Book("Johnny Mnemonic", "William Gibson"), new Book("Neuromancer", "William Gibson"), new Book("Dune", "Frank Herbert"),
                new Book("At the Back of the North Wind", "George MacDonald"), new Book("The Golden Key", "George MacDonald"),
                new Book("The Princess and the Goblin", "George MacDonald")};



            string asmimov = "Asimov";
            string carroll = "Carroll";
            string dick = "Dick";
            string doyle = "Doyle";
            string gibson = "Gibson";
            string herbert = "Herbert";
            string macDonald = "MacDonald";

            int userAns = 0;
            string y = "y";
            string yes = "yes";
            bool keepAsk = true;
            bool trueAns = false;

            while (keepAsk)
            {
                Console.WriteLine("Hello, User, Welcome to the library. For a list of books, please input 1. For a list of authors, please input" +
                    "2: ");
                Console.WriteLine();
                string userAnswer = Console.ReadLine().ToLower();
                trueAns = int.TryParse(userAnswer, out userAns);
                if (userAns == 1)
                {
                    foreach (var catSearch in book)
                    {
                        if (catSearch. == )
                        {
                            Console.WriteLine($"{catSearch.title}");
                        }
                    }
                    keepAsk = false;
                }
                if (userAns == 2 || userAnswer == anime)
                {
                    foreach (var catSearch in movie)
                    {
                        if (catSearch.category == anime)
                        {
                            Console.WriteLine($"{catSearch.title}");
                        }
                    }
                    keepAsk = false;
                }
                else if (userAns == 3 || userAnswer == comedy)
                {
                    foreach (var catSearch in movie)
                    {
                        if (catSearch.category == comedy)
                        {
                            Console.WriteLine($"{catSearch.title}");
                        }
                    }
                    keepAsk = false;
                }
                else if (userAns == 4 || userAnswer == drama)
                {
                    foreach (var catSearch in movie)
                    {
                        if (catSearch.category == drama)
                        {
                            Console.WriteLine($"{catSearch.title}");
                        }
                    }
                    keepAsk = false;
                }
                else if (userAns == 5 || userAnswer == fantasy)
                {
                    foreach (var catSearch in movie)
                    {
                        if (catSearch.category == fantasy)
                        {
                            Console.WriteLine($"{catSearch.title}");
                        }
                    }
                    keepAsk = false;
                }
                else if (userAns == 6 || userAnswer == horror)
                {
                    foreach (var catSearch in movie)
                    {
                        if (catSearch.category == horror)
                        {
                            Console.WriteLine($"{catSearch.title}");
                        }
                        keepAsk = false;
                    }
                }
                else if (userAns == 7 || userAnswer == romance)
                {
                    foreach (var catSearch in movie)
                    {
                        if (catSearch.category == romance)
                        {
                            Console.WriteLine($"{catSearch.title}");
                        }
                    }
                    keepAsk = false;
                }
                else if (userAns == 8 || userAnswer == sciFi)
                {
                    foreach (var catSearch in movie)
                    {
                        if (catSearch.category == sciFi)
                        {
                            Console.WriteLine($"{catSearch.title}");
                        }
                    }
                    keepAsk = false;
                }
                else if (trueAns == false)
                {
                    Console.WriteLine("Sorry, we have nothing from that genre. Please try again");
                    Console.WriteLine();
                    keepAsk = true;
                }
                Console.WriteLine("Would you like to see any more (y/n)? ");
                string more = Console.ReadLine().ToLower();
                more.Trim();
                more = more.Trim();

                if (more == y || more == yes)
                {
                    keepAsk = true;
                }
                else
                {
                    keepAsk = false;
                }

            }
        }
    }
}