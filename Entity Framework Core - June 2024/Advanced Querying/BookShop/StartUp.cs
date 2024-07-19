using System.Globalization;
using BookShop.Models.Enums;

namespace BookShop
{
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
            Console.WriteLine(GetBooksReleasedBefore(db, "30-12-1989"));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            if (!Enum.TryParse(command, true, out AgeRestriction ageRestriction))
            {
                return string.Empty;
            }

            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(t => t);

            return string.Join(Environment.NewLine, books);
        }//2
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books.Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .Select(b => new { b.Title, b.BookId })
                .OrderBy(b => b.BookId);

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }//3
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books.Where(b => b.Price > 40).Select(b => new { b.Title, b.Price }).OrderByDescending(x=>x.Price);

            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - ${b.Price:f2}"));
        }//4
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .Select(b => new { b.Title, b.BookId })
                .OrderBy(b => b.BookId);

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }//5
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var genres = input.ToLower().Split().ToArray();

            var books = context.BooksCategories.Where(bc => genres.Contains((bc.Category.Name).ToLower()))
                .Select(bc => bc.Book.Title).OrderBy(x => x);

            return string.Join(Environment.NewLine, books.Select(b => b));

        }//6
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dt = DateTime.ParseExact(date, "dd-MM-yyyy",
                CultureInfo.InvariantCulture);


            var books = context.Books.Where(b => b.ReleaseDate < dt).Select(b => new
            {
                b.Title,
                b.EditionType,
                b.Price,
                b.ReleaseDate
            }).OrderByDescending(x=>x.ReleaseDate).ToList();


            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}"));
        }//7
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors.Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}").OrderBy(x=>x);

            return string.Join(Environment.NewLine, authors.Select(b => b));
        }//8
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books.Where(a => a.Title.ToLower().Contains(input.ToLower()))
                .Select(a => a.Title).OrderBy(x=>x);

            return string.Join(Environment.NewLine, books.Select(b => b));
        }//9
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books.Where(a => a.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(a => $"{a.Title} ({a.Author.FirstName} {a.Author.LastName})");

            return string.Join(Environment.NewLine, books.Select(b => b));
        }//10
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books.Where(b => b.Title.Length > lengthCheck).Count();
        }//11
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    TotalCopies = a.Books.Sum(b => b.Copies)
                }).OrderByDescending(b => b.TotalCopies);

            return string.Join(Environment.NewLine, authors.Select(b => $"{b.FirstName} {b.LastName} - {b.TotalCopies}"));
        }//12
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var category = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Price = c.CategoryBooks.Sum(b => b.Book.Price*b.Book.Copies)
                }).OrderByDescending(c => c.Price).ThenBy(c => c.Name);

            return string.Join(Environment.NewLine, category.Select(b => $"{b.Name} ${b.Price:f2}"));
        }//13
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories.Select(c => new
            {
                c.Name,
                Books = c.CategoryBooks
                        .OrderByDescending(b => b.Book.ReleaseDate)
                        .Take(3)
                        .Select(b => new { b.Book.Title, Year=b.Book.ReleaseDate.Value.Year })
            }).ToArray()
                .OrderBy(c => c.Name).ToArray();

            var result = new StringBuilder();

            foreach (var c in categories)
            {
                result.AppendLine($"--{c.Name}");
                foreach (var b in c.Books)
                {
                    result.AppendLine($"{b.Title} ({b.Year})");
                }
            }

            return result.ToString().TrimEnd();
        }//14
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var b in books)
            {
                b.Price += 5;
            }

            context.SaveChanges();
        }//15
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books.Where(b => b.Copies < 4200).ToList();

            context.RemoveRange(books);
            context.SaveChanges();

            return books.Count();
        }//16

    }
}


