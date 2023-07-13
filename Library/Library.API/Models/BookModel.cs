using Library.Data.Models;

namespace Library.API.Models
{
	public class BookModel
	{
		public BookModel() { }	
		public BookModel(BookDto dto) 
		{
			Isbn = dto.Isbn;
			Title = dto.Title;
			Author = dto.Author;
			Publisher = dto.Publisher;
			PublicationDate = dto.PublicationDate;
			Genre = dto.Genre;
			PageCount = dto.PageCount;
			Description = dto.Description;
		}

		public long Isbn { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public string? Publisher { get; set; }
		public DateTime? PublicationDate { get; set; }
		public string? Genre { get; set; }
		public int? PageCount { get; set; }
		public string? Description { get; set; }

	}
}
