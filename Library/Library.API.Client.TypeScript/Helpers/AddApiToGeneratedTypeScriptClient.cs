using JetBrains.Annotations;
using NJsonSchema;
using NSwag;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;

namespace Library.API.Client.TypeScript.Helpers
{
	[UsedImplicitly]
	public class AddApiToGeneratedTypeScriptClient : IOperationProcessor
	{
		public bool Process(OperationProcessorContext context)
		{
			context.OperationDescription.Path = $"/{context.OperationDescription.Path}";
			
			return true;
		}
	}
}
