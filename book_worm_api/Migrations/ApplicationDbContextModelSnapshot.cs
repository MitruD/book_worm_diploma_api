﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using book_worm_api.Data;

#nullable disable

namespace book_worm_api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("book_worm_api.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("book_worm_api.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Books", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "F. Scott Fitzgerald",
                            Description = "A story of the fabulously wealthy Jay Gatsby and his love for the beautiful Daisy Buchanan.",
                            Genre = "Fiction",
                            ImageURL = "\\images\\great_gatsby.jpg",
                            Name = "The Great Gatsby",
                            Price = 12.99
                        },
                        new
                        {
                            Id = 2,
                            Author = "Harper Lee",
                            Description = "A novel set in the American South during the 1930s that deals with issues of racial injustice.",
                            Genre = "Fiction",
                            ImageURL = "\\images\\to_kill_a_mockingbird.jpg",
                            Name = "To Kill a Mockingbird",
                            Price = 10.99
                        },
                        new
                        {
                            Id = 3,
                            Author = "George Orwell",
                            Description = "A dystopian novel that explores the dangers of a totalitarian government.",
                            Genre = "Fiction",
                            ImageURL = "\\images\\1984.jpg",
                            Name = "1984",
                            Price = 14.99
                        },
                        new
                        {
                            Id = 4,
                            Author = "Dan Brown",
                            Description = "A gripping mystery that involves a conspiracy related to religious symbolism.",
                            Genre = "Mystery",
                            ImageURL = "\\images\\da_vinci_code.jpg",
                            Name = "The Da Vinci Code",
                            Price = 15.99
                        },
                        new
                        {
                            Id = 5,
                            Author = "Gillian Flynn",
                            Description = "A psychological thriller about a husband and wife whose marriage takes a dark turn.",
                            Genre = "Mystery",
                            ImageURL = "\\images\\gone_girl.jpg",
                            Name = "Gone Girl",
                            Price = 13.99
                        },
                        new
                        {
                            Id = 6,
                            Author = "Stieg Larsson",
                            Description = "A gripping mystery involving a journalist and a computer hacker investigating a wealthy family's dark secrets.",
                            Genre = "Mystery",
                            ImageURL = "\\images\\girl_with_dragon_tattoo.jpg",
                            Name = "The Girl with the Dragon Tattoo",
                            Price = 16.989999999999998
                        },
                        new
                        {
                            Id = 7,
                            Author = "Jane Austen",
                            Description = "A classic romance novel that explores themes of love and social expectations.",
                            Genre = "Romance",
                            ImageURL = "\\images\\pride_and_prejudice.jpg",
                            Name = "Pride and Prejudice",
                            Price = 11.99
                        },
                        new
                        {
                            Id = 8,
                            Author = "Nicholas Sparks",
                            Description = "A heartwarming love story about a young couple and the challenges they face.",
                            Genre = "Romance",
                            ImageURL = "\\images\\the_notebook.jpg",
                            Name = "The Notebook",
                            Price = 14.99
                        },
                        new
                        {
                            Id = 9,
                            Author = "Diana Gabaldon",
                            Description = "A historical romance novel that involves time travel and adventure.",
                            Genre = "Romance",
                            ImageURL = "\\images\\outlander.jpg",
                            Name = "Outlander",
                            Price = 17.989999999999998
                        },
                        new
                        {
                            Id = 10,
                            Author = "Frank Herbert",
                            Description = "An epic science fiction novel set in a distant future amidst a sprawling interstellar empire.",
                            Genre = "Science Fiction",
                            ImageURL = "\\images\\dune.jpg",
                            Name = "Dune",
                            Price = 18.989999999999998
                        },
                        new
                        {
                            Id = 11,
                            Author = "Orson Scott Card",
                            Description = "A military science fiction novel that follows a child prodigy's training in space warfare.",
                            Genre = "Science Fiction",
                            ImageURL = "\\images\\enders_game.jpg",
                            Name = "Ender's Game",
                            Price = 12.99
                        },
                        new
                        {
                            Id = 12,
                            Author = "Douglas Adams",
                            Description = "A comedic science fiction series that follows an unwitting human's adventures in space.",
                            Genre = "Science Fiction",
                            ImageURL = "\\images\\hitchhikers_guide.jpg",
                            Name = "The Hitchhiker's Guide to the Galaxy",
                            Price = 15.99
                        },
                        new
                        {
                            Id = 13,
                            Author = "J.R.R. Tolkien",
                            Description = "A classic fantasy novel that follows the journey of Bilbo Baggins.",
                            Genre = "Fantasy",
                            ImageURL = "\\images\\the_hobbit.jpg",
                            Name = "The Hobbit",
                            Price = 16.989999999999998
                        },
                        new
                        {
                            Id = 14,
                            Author = "J.K. Rowling",
                            Description = "The first book in the Harry Potter series, introducing the world of magic and wizardry.",
                            Genre = "Fantasy",
                            ImageURL = "\\images\\harry_potter.jpg",
                            Name = "Harry Potter and the Sorcerer's Stone",
                            Price = 19.989999999999998
                        },
                        new
                        {
                            Id = 15,
                            Author = "Patrick Rothfuss",
                            Description = "An epic fantasy novel that tells the life story of the protagonist Kvothe.",
                            Genre = "Fantasy",
                            ImageURL = "\\images\\name_of_the_wind.jpg",
                            Name = "The Name of the Wind",
                            Price = 14.99
                        },
                        new
                        {
                            Id = 16,
                            Author = "Yuval Noah Harari",
                            Description = "A thought-provoking exploration of the history and impact of Homo sapiens.",
                            Genre = "Non-Fiction",
                            ImageURL = "\\images\\sapiens.jpg",
                            Name = "Sapiens: A Brief History of Humankind",
                            Price = 21.989999999999998
                        },
                        new
                        {
                            Id = 17,
                            Author = "Tara Westover",
                            Description = "A memoir that recounts the author's journey from growing up in a strict household to pursuing education.",
                            Genre = "Non-Fiction",
                            ImageURL = "\\images\\educated.jpg",
                            Name = "Educated",
                            Price = 16.989999999999998
                        },
                        new
                        {
                            Id = 18,
                            Author = "Rebecca Skloot",
                            Description = "A biography that explores the life and impact of Henrietta Lacks and the HeLa cell line.",
                            Genre = "Non-Fiction",
                            ImageURL = "\\images\\henrietta_lacks.jpg",
                            Name = "The Immortal Life of Henrietta Lacks",
                            Price = 18.989999999999998
                        });
                });

            modelBuilder.Entity("book_worm_api.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingCartId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("CartItems", (string)null);
                });

            modelBuilder.Entity("book_worm_api.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ShoppingCarts", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("book_worm_api.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("book_worm_api.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("book_worm_api.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("book_worm_api.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("book_worm_api.Models.CartItem", b =>
                {
                    b.HasOne("book_worm_api.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("book_worm_api.Models.ShoppingCart", null)
                        .WithMany("CartItems")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("book_worm_api.Models.ShoppingCart", b =>
                {
                    b.Navigation("CartItems");
                });
#pragma warning restore 612, 618
        }
    }
}
