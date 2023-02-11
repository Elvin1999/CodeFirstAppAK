using CodeFirstApp.DataAccess;
using CodeFirstApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CodeFirstApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LibraryContext _context = new LibraryContext();
        public MainWindow()
        {
            InitializeComponent();
            _context.Database.CreateIfNotExists();
            Get();
            GetTest();
        }

        private async void GetTest()
        {
            var authors = await _context.Authors.Where(a => a.Id == 1).ToListAsync();
            authorsGrid.ItemsSource = authors;
            booksGrid.ItemsSource = authors[0].Books;
        }

        private async void Get()
        {
            if (_context.Categories.Count() == 0)
            {
                await AddCategoriesAsync();
            }
            var categories = await _context.Categories.ToListAsync();
            categoriesGrid.ItemsSource = categories;

            if (_context.Authors.Count() == 0)
            {
                await AddAuthorsAsync();
            }
            var authors = await _context.Authors.ToListAsync();
            authorsGrid.ItemsSource = authors;

            if (_context.Books.Count() == 0)
            {
                await AddBooksAsync();
            }

            var books = await _context.Books.ToListAsync(); 
            booksGrid.ItemsSource = books;

        }

        private async Task AddBooksAsync()
        {
            _context.Books.Add(new Book
            {
                AuthorId=1,
                CategoryId=1,
                Pages=100,
                Name="My Best Book"
            });

            await _context.SaveChangesAsync();
        }

        private async Task AddAuthorsAsync()
        {
            _context.Authors.Add(new Author
            {
                Firstname="Linus",
                Lastname="Torvalds",
                Age=35
            });

            _context.Authors.Add(new Author
            {
                Firstname="Leyla",
                Lastname="Mammadova",
                Age=20
            });

            _context.Authors.Add(new Author
            {
                Firstname="Axmed",
                Lastname="Axmedlinsky",
                Age=43
            });

            await _context.SaveChangesAsync();
        }

        private async Task AddCategoriesAsync()
        {
            _context.Categories.Add(new Category
            {
                 Name="Adventure"
            });

            _context.Categories.Add(new Category
            {
                Name="Sci-Fi"
            });

            _context.Categories.Add(new Category
            {
                Name="Programming"
            });

            await _context.SaveChangesAsync();
        }
    }
}
