using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Operations
{
	public interface IServiceOperation
	{
		Task Preform(CancellationToken token, TimeSpan repeatDelay);
	}
}