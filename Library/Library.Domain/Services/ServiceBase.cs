using Library.Data.Models;
using Library.Domain.Repositories;
using Library.Domain.Validations;
using FluentValidation;
using FluentValidation.Results;

namespace Library.Domain.Services
{
	public class ServiceBase
	{
		protected readonly IBookRepository BookRepository;

		public ServiceBase(IBookRepository bookRepository)
		{
			BookRepository = bookRepository;
		}

		protected static ResultBase Execute(Action action)
		{
			return Execute(_ =>
			{
				action();
			}, () => new ResultBase());
		}

		protected static TResult Execute<TResult>(Action<TResult> action, Func<TResult> createResult)
			where TResult : ResultBase
		{
			TResult result = createResult();

			try 
			{
				action(result);
			}
			catch (Exception ex) 
			{
				HandleException(ex, result);
			}
			return result;
		}

		private static void HandleException(Exception ex, ResultBase result)
		{
			result.Success = false;
			result.ErrorCode = ResultErrorCode.General;
			result.ErrorMessage = ex.Message;
		}

		protected IEnumerable<BookDto> GetAllBooks()
		{
			return BookRepository.GetAllBooks();
		}

		protected void CreateBook(BookDto bookDto)
		{
			var bookValidator = new BookValidator();
			ValidationResult validationResult = bookValidator.Validate(bookDto);
			if(!validationResult.IsValid)
			{
				throw new ValidationException(validationResult.Errors);
			}
			if (!BookRepository.IsUniqueIsbn(bookDto.Isbn))
			{
				var isbnError = new ValidationFailure("Isbn", "ISBN already exists");
				validationResult.Errors.Add(isbnError);
				throw new ValidationException(validationResult.Errors);
			}

			BookRepository.CreateBook(bookDto);
		}
		protected void UpdateBook(BookDto bookDto)
		{
			var bookValidator = new BookValidator();
			var existingBook = BookRepository.GetBookByIsbn(bookDto.Isbn);
			if (existingBook == null)
			{
				throw new FileNotFoundException("Book not found");
			}
			ValidationResult validationResult = bookValidator.Validate(bookDto);
			if (!validationResult.IsValid)
			{
				throw new ValidationException(validationResult.Errors);
			}

			BookRepository.UpdateBook(bookDto);
		}

		protected void DeleteBook(BookDto bookDto)
		{
			var existingBook = BookRepository.GetBookByIsbn(bookDto.Isbn);
			if (existingBook == null)
			{
				throw new FileNotFoundException("Book not found");
			}
			BookRepository.DeleteBook(bookDto);
		}

	}
}
