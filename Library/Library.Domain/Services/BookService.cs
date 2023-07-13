using Library.Data.Models;
using Library.Domain.Data;
using Library.Domain.Repositories;
namespace Library.Domain.Services
{
	public class BookService : ServiceBase, IBookService
	{
		public BookService(IBookRepository bookRepository)
			: base(bookRepository) { }

		public FindAllBookResult GetAll()
		{
			FindAllBookResult result = Execute(resultInner =>
			{
				resultInner.Books = GetAllBooks();
			},() => new FindAllBookResult());

			return result;
		}
		public ResultBase Create(BookDto bookDto)
		{
			ResultBase result = Execute(() =>
			{
				CreateBook(bookDto);
			});
			return result;
		}

		public ResultBase Update(BookDto bookDto)
		{
			ResultBase result = Execute(() =>
			{
				UpdateBook(bookDto);
			});
			return result;
		}

		public ResultBase Delete(BookDto bookDto)
		{
			ResultBase result = Execute(() =>
			{
				DeleteBook(bookDto);
			});
			return result;
		}
	}
}
