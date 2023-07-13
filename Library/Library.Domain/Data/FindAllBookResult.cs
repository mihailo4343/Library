using Library.Data.Models;

namespace Library.Domain.Data
{
	public class FindAllBookResult: ResultBase
	{
		public IEnumerable<BookDto> Books { get; set; }
	}
}
