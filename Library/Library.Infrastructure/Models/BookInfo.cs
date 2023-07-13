using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Models
{
	public class BookInfo
	{
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
