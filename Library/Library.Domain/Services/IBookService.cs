using Library.Data.Models;
using Library.Domain.Data;

namespace Library.Domain.Services
{
	public interface IBookService
	{
		FindAllBookResult GetAll();
		ResultBase Create(BookDto bookDto);
		ResultBase Update(BookDto bookDto);
		ResultBase Delete(BookDto bookDto);
	}
}
