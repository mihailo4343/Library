using Library.Domain.Validations;

namespace Library.Data.Models
{
    public class BookDto
    {
		public long Isbn { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public string? Publisher { get; set; }
		public DateTime? PublicationDate { get; set; }
		public string? Genre { get; set; }
		public int? PageCount { get; set; }
		public string? Description { get; set; }

		public void Validate()
		{ 
			var validator = new BookValidator();
			var result = validator.Validate(this);
			if (!result.IsValid) 
			{
				throw new Exception($"Validation failed: {result.Errors}");
			}
		}

	}
}
