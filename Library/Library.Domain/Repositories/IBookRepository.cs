using Library.Data.Models;
using Library.Domain.Data;

namespace Library.Domain.Repositories
{
	public interface IBookRepository
	{
		List<BookDto> GetAllBooks();
		void CreateBook(BookDto bookDto);
		void UpdateBook(BookDto bookDto);
		void DeleteBook(BookDto bookDto);
		BookDto? GetBookByIsbn(long bookIsbn);
		bool IsUniqueIsbn(long bookIsbn);
	}
}
