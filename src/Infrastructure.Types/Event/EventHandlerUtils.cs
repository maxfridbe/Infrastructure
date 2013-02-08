using System;
using System.Reflection;

namespace Infrastructure.Types.Event
{
	

	/// <summary>
	/// 
	/// </summary>
	/// <example>
	/// <![CDATA[
	/// 
	/// public class eventr
	///{
	///	public event EventHandler<EventArgs> kill;
	///}
	///
	///public class myclass
	///{
	///	public myclass()
	///	{
	///		var ev = new eventr();
	///		ev.kill += new EventHandler<EventArgs>(ev_kill).MakeWeak(eh => ev.kill -= eh);
	///
	///	}
	///
	///	private void ev_kill(object sender, EventArgs e)
	///	{
	///		throw new NotImplementedException();
	///	}
	///}
	/// 
	/// ]]>
	/// </example>
	public static class EventHandlerUtils
	{
		public static EventHandler<TEventArgs> MakeWeak<TEventArgs>(this EventHandler<TEventArgs> eventHandler, UnregisterCallback<TEventArgs> unregister)
			where TEventArgs : EventArgs
		{
			if (eventHandler == null)
				throw new ArgumentNullException("eventHandler");
			if (eventHandler.Method.IsStatic || eventHandler.Target == null)
				throw new ArgumentException("Only instance methods are supported.", "eventHandler");

			Type wehType = typeof(WeakEventHandler<,>).MakeGenericType(eventHandler.Method.DeclaringType, typeof(TEventArgs));
			ConstructorInfo wehConstructor = wehType.GetConstructor(new Type[]
			                                                        	{
			                                                        		typeof (EventHandler<TEventArgs>),
			                                                        		typeof (UnregisterCallback<TEventArgs>)
			                                                        	});

			var weh = (IWeakEventHandler<TEventArgs>) wehConstructor.Invoke(
				new object[] {eventHandler, unregister});

			return weh.Handler;
		}
	}
}