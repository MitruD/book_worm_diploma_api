using book_worm_api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace book_worm_api.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Book>().HasData(

                 new Book
                 {
                     Id = 1,
                     Name = "The Great Gatsby",
                     Description = "A story of the fabulously wealthy Jay Gatsby and his love for the beautiful Daisy Buchanan.",
                     ImageURL = "/images/great_gatsby.jpg",
                     Price = 12.99,
                     Genre = "Fiction",
                 },

                 new Book
                 {
                     Id = 2,
                     Name = "To Kill a Mockingbird",
                     Description = "A novel set in the American South during the 1930s that deals with issues of racial injustice.",
                     ImageURL = "/images/to_kill_a_mockingbird.jpg",
                     Price = 10.99,
                     Genre = "Fiction",
                 },

                 new Book
                 {
                     Id = 3,
                     Name = "1984",
                     Description = "A dystopian novel that explores the dangers of a totalitarian government.",
                     ImageURL = "/images/1984.jpg",
                     Price = 14.99,
                     Genre = "Fiction",
                 },

                 new Book
                 {
                     Id = 4,
                     Name = "The Da Vinci Code",
                     Description = "A gripping mystery that involves a conspiracy related to religious symbolism.",
                     ImageURL = "/images/da_vinci_code.jpg",
                     Price = 15.99,
                     Genre = "Mystery",
                 },

                 new Book
                 {
                     Id = 5,
                     Name = "Gone Girl",
                     Description = "A psychological thriller about a husband and wife whose marriage takes a dark turn.",
                     ImageURL = "/images/gone_girl.jpg",
                     Price = 13.99,
                     Genre = "Mystery",
                 },

                 new Book
                 {
                     Id = 6,
                     Name = "The Girl with the Dragon Tattoo",
                     Description = "A gripping mystery involving a journalist and a computer hacker investigating a wealthy family's dark secrets.",
                     ImageURL = "/images/girl_with_dragon_tattoo.jpg",
                     Price = 16.99,
                     Genre = "Mystery",
                 },

                 new Book
                 {
                     Id = 7,
                     Name = "Pride and Prejudice",
                     Description = "A classic romance novel that explores themes of love and social expectations.",
                     ImageURL = "/images/pride_and_prejudice.jpg",
                     Price = 11.99,
                     Genre = "Romance",
                 },

                 new Book
                 {
                     Id = 8,
                     Name = "The Notebook",
                     Description = "A heartwarming love story about a young couple and the challenges they face.",
                     ImageURL = "/images/the_notebook.jpg",
                     Price = 14.99,
                     Genre = "Romance",
                 },

                 new Book
                 {
                     Id = 9,
                     Name = "Outlander",
                     Description = "A historical romance novel that involves time travel and adventure.",
                     ImageURL = "/images/outlander.jpg",
                     Price = 17.99,
                     Genre = "Romance",
                 },

                 new Book
                 {
                     Id = 10,
                     Name = "Dune",
                     Description = "An epic science fiction novel set in a distant future amidst a sprawling interstellar empire.",
                     ImageURL = "/images/dune.jpg",
                     Price = 18.99,
                     Genre = "Science Fiction",
                 },

                 new Book
                 {
                     Id = 11,
                     Name = "Ender's Game",
                     Description = "A military science fiction novel that follows a child prodigy's training in space warfare.",
                     ImageURL = "/images/enders_game.jpg",
                     Price = 12.99,
                     Genre = "Science Fiction",
                 },

                 new Book
                 {
                     Id = 12,
                     Name = "The Hitchhiker's Guide to the Galaxy",
                     Description = "A comedic science fiction series that follows an unwitting human's adventures in space.",
                     ImageURL = "/images/hitchhikers_guide.jpg",
                     Price = 15.99,
                     Genre = "Science Fiction",
                 },

                 new Book
                 {
                     Id = 13,
                     Name = "The Hobbit",
                     Description = "A classic fantasy novel that follows the journey of Bilbo Baggins.",
                     ImageURL = "/images/the_hobbit.jpg",
                     Price = 16.99,
                     Genre = "Fantasy",
                 },

                 new Book
                 {
                     Id = 14,
                     Name = "Harry Potter and the Sorcerer's Stone",
                     Description = "The first book in the Harry Potter series, introducing the world of magic and wizardry.",
                     ImageURL = "/images/harry_potter.jpg",
                     Price = 19.99,
                     Genre = "Fantasy",
                 },

                 new Book
                 {
                     Id = 15,
                     Name = "The Name of the Wind",
                     Description = "An epic fantasy novel that tells the life story of the protagonist Kvothe.",
                     ImageURL = "/images/name_of_the_wind.jpg",
                     Price = 14.99,
                     Genre = "Fantasy",
                 },

                 new Book
                 {
                     Id = 16,
                     Name = "Sapiens: A Brief History of Humankind",
                     Description = "A thought-provoking exploration of the history and impact of Homo sapiens.",
                     ImageURL = "/images/sapiens.jpg",
                     Price = 21.99,
                     Genre = "Non-Fiction",
                 },

                 new Book
                 {
                     Id = 17,
                     Name = "Educated",
                     Description = "A memoir that recounts the author's journey from growing up in a strict household to pursuing education.",
                     ImageURL = "/images/educated.jpg",
                     Price = 16.99,
                     Genre = "Non-Fiction",
                 },

                 new Book
                 {
                     Id = 18,
                     Name = "The Immortal Life of Henrietta Lacks",
                     Description = "A biography that explores the life and impact of Henrietta Lacks and the HeLa cell line.",
                     ImageURL = "/images/henrietta_lacks.jpg",
                     Price = 18.99,
                     Genre = "Non-Fiction",
                 }

                );
        }
    }
}
