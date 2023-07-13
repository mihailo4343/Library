namespace Library.Domain
{
	public class ResultBase
	{
		public bool Success { get; set; } = true;
		public string ErrorMessage { get; set; }
		public string Stack { get; set; }
		public ResultErrorCode ErrorCode { get; set; } = ResultErrorCode.None;
	}
}
