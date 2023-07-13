using Microsoft.AspNetCore.Mvc;
using Library.API.Models;
using Library.Domain.Services;
using Library.Data.Models;

namespace Library.API.Controllers
{

	[ApiController]
	[Route("api/books")]
	public class BookController : ApiControllerBase
	{
		private readonly IBookService _bookService;

		public BookController(IBookService bookService)
		{
			_bookService = bookService;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookModel>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public IActionResult GetAllBooks() 
		{
			var result = _bookService.GetAll();
			return GetResult(Ok(result.Books.Select(dto => new BookModel(dto))), result);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult CreateBook([FromBody] BookModel model)
		{
			var dto = new BookDto
			{
				Isbn = model.Isbn,
				Author = model.Author,
				Description = model.Description,
				Genre = model.Genre,
				PageCount = model.PageCount,
				PublicationDate = model.PublicationDate,
				Publisher = model.Publisher,
				Title = model.Title
			};
			var result = _bookService.Create(dto);
			return (GetResult(Ok(), result));
		}

		[HttpPatch]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult UpdateBook([FromBody] BookModel model)
		{
			var dto = new BookDto
			{
				Isbn = model.Isbn,
				Author = model.Author,
				Description = model.Description,
				Genre = model.Genre,
				PageCount = model.PageCount,
				PublicationDate = model.PublicationDate,
				Publisher = model.Publisher,
				Title = model.Title
			};
			var result = _bookService.Update(dto);
			return (GetResult(Ok(), result));
		}

		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult DeleteBook([FromBody] BookModel model)
		{
			var dto = new BookDto
			{
				Isbn = model.Isbn,
				Author = model.Author,
				Description = model.Description,
				Genre = model.Genre,
				PageCount = model.PageCount,
				PublicationDate = model.PublicationDate,
				Publisher = model.Publisher,
				Title = model.Title
			};
			var result = _bookService.Delete(dto);
			return (GetResult(Ok(), result));
		}
	}
	
}
