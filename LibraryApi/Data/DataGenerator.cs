using LibraryApi.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryApi.Data
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApiContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApiContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
               
                DbSet<Book> books = context.Set<Book>();
                books.Add(new Book("The Invisible Man", "H.G. Wells", 1897, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQsfxrcUtlaLqSTTpA7N9cWKIopvRNtXngM2A&s"));
                books.Add(new Book("The War of the Worlds", "H.G. Wells", 1898, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQsfxrcUtlaLqSTTpA7N9cWKIopvRNtXngM2A&s"));
                books.Add(new Book("The Time Machine", "H.G. Wells", 1895, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQsfxrcUtlaLqSTTpA7N9cWKIopvRNtXngM2A&s"));
                books.Add(new Book("Brave New World", "Aldous Huxley", 1932, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQsfxrcUtlaLqSTTpA7N9cWKIopvRNtXngM2A&s"));
                books.Add(new Book("1984", "George Orwell", 1949, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQsfxrcUtlaLqSTTpA7N9cWKIopvRNtXngM2A&s"));
                books.Add(new Book("Animal Farm", "George Orwell", 1945, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQsfxrcUtlaLqSTTpA7N9cWKIopvRNtXngM2A&s"));
                books.Add(new Book("Fahrenheit 451", "Ray Bradbury", 1953, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQsfxrcUtlaLqSTTpA7N9cWKIopvRNtXngM2A&s"));
                books.Add(new Book("Dune", "Frank Herbert", 1965, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQsfxrcUtlaLqSTTpA7N9cWKIopvRNtXngM2A&s"));
                books.Add(new Book("Foundation", "Isaac Asimov", 1951, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQsfxrcUtlaLqSTTpA7N9cWKIopvRNtXngM2A&s"));
                books.Add(new Book("The Hitchhiker's Guide to the Galaxy", "Douglas Adams", 1979, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQsfxrcUtlaLqSTTpA7N9cWKIopvRNtXngM2A&s"));
                books.Add(new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQsfxrcUtlaLqSTTpA7N9cWKIopvRNtXngM2A&s"));
                books.Add(new Book("The Catcher in the Rye", "J.D. Salinger", 1951, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQsfxrcUtlaLqSTTpA7N9cWKIopvRNtXngM2A&s"));
                books.Add(new Book("Pride and Prejudice", "Jane Austen", 1813, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQsfxrcUtlaLqSTTpA7N9cWKIopvRNtXngM2A&s"));
                books.Add(new Book("Jane Eyre", "Charlotte Brontë", 1847, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQsfxrcUtlaLqSTTpA7N9cWKIopvRNtXngM2A&s"));
                books.Add(new Book("Wuthering Heights", "Emily Brontë", 1847, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQsfxrcUtlaLqSTTpA7N9cWKIopvRNtXngM2A&s"));
                books.Add(new Book("War and Peace", "Leo Tolstoy", 1869, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQsfxrcUtlaLqSTTpA7N9cWKIopvRNtXngM2A&s"));




                context.AddRange(books);
      
                context.SaveChanges();
            }
           
        }
    }
}



