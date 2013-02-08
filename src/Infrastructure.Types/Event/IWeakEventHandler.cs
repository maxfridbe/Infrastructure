using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Types.Event
{
	public interface IWeakEventHandler<TEventArgs>
	  where TEventArgs : EventArgs
	{
		EventHandler<TEventArgs> Handler { get; }
	}
}
