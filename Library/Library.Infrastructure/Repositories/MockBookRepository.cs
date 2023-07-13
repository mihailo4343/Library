using Library.Data.Models;
using Library.Domain.Repositories;
using Library.Infrastructure.Models;

namespace Library.API.Infrastructure.Repositories
{
	public class MockBookRepository : IBookRepository
	{
		private List<BookInfo> _books;

		public MockBookRepository()
		{
			_books = new List<BookInfo>
			{
				new BookInfo
				{
					Isbn = 9780316769174,
					Author = "J.D. Salinger",
					Title = "The Catcher in the Rye",
					Publisher = "Little, Brown and Company",
					PublicationDate = DateTime.Parse("7/16/1951"),
					Genre = "Fiction",
					PageCount = 224,
					Description = "A coming-of-age novel that explores teenage angst and rebellion."
				},
				new BookInfo
				{
					Isbn = 9780156907392,
					Author = "Virginia Woolf",
					Title = "To the Lighthouse",
					Publisher = "Harcourt Brace & Company",
					PublicationDate = DateTime.Parse("5/5/1927"),
					Genre = "Fiction",
					PageCount = 209,
					Description = "An experimental novel that delves into the complexities of human relationships."
				},
				new BookInfo
				{
					Isbn = 9780618640157,
					Author = "J.R.R. Tolkien",
					Title = "The Lord of the Rings",
					Publisher = "Houghton Mifflin",
					PublicationDate = DateTime.Parse("7/29/1954"),
					Genre = "Fantasy",
					PageCount = 1178,
					Description = "An epic high-fantasy trilogy set in the world of Middle-earth."
				},
				new BookInfo
				{
					Isbn = 9780747532743,
					Author = "J.K. Rowling",
					Title = "Harry Potter and the Philosopher's Stone",
					Publisher = "Bloomsbury",
					PublicationDate = DateTime.Parse("6/26/1997"),
					Genre = "Fantasy",
					PageCount = 223,
					Description = "The first book in the beloved Harry Potter series about a young wizard's journey."
				},
				new BookInfo
				{
					Isbn = 9780140268867,
					Author = "Homer",
					Title = "The Odyssey",
					Publisher = "Penguin Classics",
					PublicationDate = null, 
			        Genre = "Classic",
					PageCount = 416,
					Description = "An ancient Greek epic poem that follows the hero Odysseus on his journey home."
				},
				new BookInfo
				{
					Isbn = 9780062315007,
					Author = "Paulo Coelho",
					Title = "The Alchemist",
					Publisher = "HarperOne",
					PublicationDate = null,
			        Genre = "Fiction",
					PageCount = 208,
					Description = "A philosophical novel about a young Andalusian shepherd pursuing his dreams."
				},
				new BookInfo
				{
					Isbn = 9780064405379,
					Author = "C.S. Lewis",
					Title = "The Chronicles of Narnia",
					Publisher = "HarperCollins",
					PublicationDate = DateTime.Parse("10/16/1950"),
					Genre = "Fantasy",
					PageCount = 767,
					Description = "A series of seven fantasy novels set in the magical world of Narnia."
				},
				new BookInfo
				{
					Isbn = 9780142437247,
					Author = "Herman Melville",
					Title = "Moby-Dick",
					Publisher = "Penguin Classics",
					PublicationDate = DateTime.Parse("10/18/1851"),
					Genre = "Fiction",
					PageCount = 720,
					Description = "An adventure novel that tells the story of Captain Ahab's obsessive quest for a white whale."
				},
				new BookInfo
				{
					Isbn = 9780439023528,
					Author = "Suzanne Collins",
					Title = "The Hunger Games",
					Publisher = "Scholastic",
					PublicationDate = DateTime.Parse("9/14/2008"),
					Genre = "Science Fiction",
					PageCount = 374,
					Description = "The first book in a dystopian trilogy where teenagers are forced to participate in a brutal televised competition."
				},
				new BookInfo
				{
					Isbn = 9780141439570,
					Author = "Oscar Wilde",
					Title = "The Picture of Dorian Gray",
					Publisher = "Penguin Classics",
					PublicationDate = DateTime.Parse("4/20/1891"),
					Genre = "Fiction",
					PageCount = 254,
					Description = "A philosophical novel that explores the nature of beauty, morality, and the pursuit of pleasure."
				}
			};

		}

		public void CreateBook(BookDto bookDto)
		{
			var newBook = new BookInfo
			{
				Isbn = bookDto.Isbn,
				Author = bookDto.Author,
				Description = bookDto.Description,
				Genre = bookDto.Genre,
				PageCount = bookDto.PageCount,
				PublicationDate = bookDto.PublicationDate,
				Publisher = bookDto.Publisher,
				Title = bookDto.Title
			};
			_books.Add(newBook);
		}

		public void DeleteBook(BookDto bookDto)
		{
			var existingBook = _books.FirstOrDefault(b => b.Isbn == bookDto.Isbn);
			if (existingBook != null)
			{
				_books.Remove(existingBook);
			}
		}

		public List<BookDto> GetAllBooks()
		{
			return _books.Select(info => new BookDto
			{
				Isbn = info.Isbn,
				Author = info.Author,
				Description = info.Description,
				Genre = info.Genre,
				PageCount = info.PageCount,
				PublicationDate = info.PublicationDate,
				Publisher = info.Publisher,
				Title = info.Title
			}).ToList();
		}

		public bool IsUniqueIsbn(long isbn)
		{
			return !_books.Any(b => b.Isbn == isbn);
		}

		public BookDto? GetBookByIsbn(long isbn)
		{
			var bookInfo = _books.FirstOrDefault(b => b.Isbn == isbn);
			if (bookInfo != null)
			{
				return new BookDto
				{
					Isbn = bookInfo.Isbn,
					Author = bookInfo.Author,
					Description = bookInfo.Description,
					Genre = bookInfo.Genre,
					PageCount = bookInfo.PageCount,
					PublicationDate = bookInfo.PublicationDate,
					Publisher = bookInfo.Publisher,
					Title = bookInfo.Title
				};
			}
			return null;
		}

		public void UpdateBook(BookDto bookDto)
		{
			var existingBook = _books.FirstOrDefault(b => b.Isbn == bookDto.Isbn);
			if (existingBook != null)
			{
				existingBook.Title = bookDto.Title;
				existingBook.Author = bookDto.Author;
				existingBook.Description = bookDto.Description;
				existingBook.Genre = bookDto.Genre;
				existingBook.PageCount = bookDto.PageCount;
				existingBook.PublicationDate = bookDto.PublicationDate;
				existingBook.Publisher = bookDto.Publisher;
			}
		}
	}
}
