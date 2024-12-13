using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore;
using static System.Reflection.Metadata.BlobBuilder;


namespace BookStore
{
    public class SearchBook
    {


        // لیست کتاب‌ها
        public List<Book> Books { get; set; }



        // سازنده کلاس SearchBook
        public SearchBook(List<Book> books)
        {
            Books = books ?? new List<Book>();
        }
        // اضافه کردن دسته بندی به لیست دسته بندی موجود
        public static List<Category> InitCategoryData(List<Category> cates)
        {
            if (cates == null)
                cates = new List<Category>();
            var categories = new List<Category>
            {
                new Category("Fiction"),
                new Category("NonFiction"),
                new Category("Mystery"),
                new Category("Biography"),
                new Category("Science"),
                new Category("Fantasy"),
                new Category("History"),
                new Category("Romance"),
                new Category("Adventure"),
                new Category("Self-Help")
            };
            cates.AddRange(categories);
            return cates;
        }

        // اضافه کردن کتاب به لیست کتاب موجود
        public static List<Book> InitBookData(List<Book> _books, List<Category> cates)
        {
            if (_books == null)
                _books = new List<Book>();
            var books = new List<Book>
            {
                new Book("The Great Gatsby", "F. Scott Fitzgerald", 10.99m, cates[new Random().Next(0,cates.Count-1)]),
                new Book("Becoming", "Michelle Obama", 20.99m,cates[new Random().Next(0,cates.Count-1)]),
                new Book("1984", "George Orwell", 8.99m, cates[new Random().Next(0,cates.Count-1)]),
                new Book("Brief History of Time", "Stephen Hawking", 15.99m, cates[new Random().Next(0,cates.Count-1)]),
                new Book("Harry Potter", "J.K. Rowling", 25.99m, cates[new Random().Next(0,cates.Count-1)]),
                new Book("The Silent Patient", "Alex Michaelides", 12.99m,cates[new Random().Next(0,cates.Count-1)]),
                new Book("Educated", "Tara Westover", 18.99m, cates[new Random().Next(0,cates.Count-1)]),
                new Book("Dune", "Frank Herbert", 22.99m, cates[new Random().Next(0,cates.Count-1)]),
                new Book("The Catcher in the Rye", "J.D. Salinger", 9.99m,cates[new Random().Next(0,cates.Count-1)]),
                new Book("Sapiens", "Yuval Noah Harari", 19.99m, cates[new Random().Next(0,cates.Count-1)])
            };

            _books.AddRange(books);
            return _books;
        }
        public List<Book> Search(out bool StatusFind)
        {

            Console.WriteLine("What book are you looking for?");
            string searchBook = Console.ReadLine();
            //برای نمایش پیغام not Found
             StatusFind = false;
            List<Book> _books = new List<Book>();

            if (!string.IsNullOrEmpty(searchBook))
            {
                foreach (var item in Books ?? new List<Book>())
                {
                    //برسی وجود کتاب براساس متن کاربر
                    if (item.Title.Contains(searchBook) )
                    {
                        StatusFind = true;
                        _books.Add(item);
                    }
                }
            }

            return _books;



        }

        //نمایش پیام به کاربر
        public static void SendMesaage(string Title,ConsoleColor Color)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(" ╔══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine($"                            {Title}                                   ");
            Console.WriteLine(" ╚══════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }
    }
}