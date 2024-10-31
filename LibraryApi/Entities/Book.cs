using System.ComponentModel.DataAnnotations;
namespace LibraryApi.Entities
{
    public class Book
    {
       
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Author {  get; set; } 

        public int Year {  get; set; }  

        public string ImageUrl {  get; set; }

        public Book(string title, string author, int year, string imageUrl)
        {
          
            Title = title;
            Author = author;
            Year = year;
            ImageUrl = imageUrl;

        }

        public Book(string title)
        {
            Title = title;
        }

     
    }
   
}
