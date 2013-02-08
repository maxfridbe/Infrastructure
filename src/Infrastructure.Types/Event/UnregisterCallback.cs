using System;

namespace Infrastructure.Types.Event
{
	public delegate void UnregisterCallback<E>(EventHandler<E> eventHandler)
		where E : EventArgs;
}