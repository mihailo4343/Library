using Library.Data.Models;
using Library.Domain.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Validations
{
	internal class BookValidator : AbstractValidator<BookDto>
	{
		public BookValidator()
		{
			RuleFor(book => book.Isbn)
				.NotEmpty()
				.Must(IsValidIsbn)
				.WithMessage("ISBN must have exactly 13 digits")
				.OverridePropertyName("$.Isbn"); 

			RuleFor(book => book.Title)
				.NotEmpty()
				.WithMessage("Title is required.");

			RuleFor(book => book.Author)
				.NotEmpty()
				.WithMessage("Author is required.");

			RuleFor(book => book.Publisher)
				.MaximumLength(100).When(x => !string.IsNullOrEmpty(x.Publisher))
				.WithMessage("Publisher must have a maximum length of 100 characters.");

			RuleFor(book => book.PublicationDate)
				.Must(IsValidPublicationDate)
				.WithMessage("Invalid publication date.")
				.When(book => book.PublicationDate.HasValue);

			RuleFor(book => book.Genre)
				.MaximumLength(50).When(x => !string.IsNullOrEmpty(x.Genre))
				.WithMessage("Genre must have a maximum length of 50 characters.");

			RuleFor(book => book.PageCount)
				.Must(IsValidPageCount)
				.WithMessage("Invalid page count.")
				.When(book => book.PageCount.HasValue);

			RuleFor(book => book.Description)
				.MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Description))
				.WithMessage("Description must have a maximum length of 500 characters.");
		}

		private bool IsValidIsbn(long isbn)
		{
			var isbnString = isbn.ToString();
			return isbnString.Length == 13;
		}
		private bool IsValidPublicationDate(DateTime? publicationDate)
		{
			return publicationDate <= DateTime.Now.Date;
		}

		private bool IsValidPageCount(int? pageCount)
		{
			return pageCount.HasValue && pageCount.Value > 0;
		}

	}
}
