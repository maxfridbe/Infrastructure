using System;

namespace Infrastructure.Types.Event
{
	/// <summary>
	/// Taken partly from http://diditwith.net/PermaLink,guid,aacdb8ae-7baa-4423-a953-c18c1c7940ab.aspx
	/// </summary>
	/// <example>
	/// <![CDATA[
	/// public class EventSubscriber
	///{
	///  public EventSubscriber(EventProvider provider)
	///  {
	///    provider.MyEvent += new EventHandler<EventArgs>(MyWeakEventHandler).MakeWeak(eh => provider.MyEvent -= eh);
	///  }
	///
	///  private void MyWeakEventHandler(object sender, EventArgs e)
	///  {
	///  }
	///}
	/// //or
	/// public class EventProvider
	///{
	///  private EventHandler<EventArgs> m_MyEvent;
	///  public event EventHandler<EventArgs> MyEvent
	///  {
	///    add
	///    {
	///      m_Event += value.MakeWeak(eh => m_Event -= eh);
	///    }
	///    remove
	///    {
	///    }
	///  }
	///}
	/// ]]>
	/// 
	/// 
	/// 
	/// </example>
	/// <typeparam name="T"></typeparam>
	/// <typeparam name="TEventArgs"></typeparam>
	public class WeakEventHandler<T, TEventArgs> : IWeakEventHandler<TEventArgs>
		where T : class
		where TEventArgs : EventArgs
	{
		private delegate void OpenEventHandler(T @this, object sender, TEventArgs e);

		private WeakReference m_TargetRef;
		private OpenEventHandler m_OpenHandler;
		private EventHandler<TEventArgs> m_Handler;
		private UnregisterCallback<TEventArgs> m_Unregister;

		public WeakEventHandler(EventHandler<TEventArgs> eventHandler, UnregisterCallback<TEventArgs> unregister)
		{
			m_TargetRef = new WeakReference(eventHandler.Target);
			m_OpenHandler = (OpenEventHandler)Delegate.CreateDelegate(typeof(OpenEventHandler),
																	  null, eventHandler.Method);
			m_Handler = Invoke;
			m_Unregister = unregister;
		}

		public void Invoke(object sender, TEventArgs e)
		{
			T target = (T)m_TargetRef.Target;

			if (target != null)
				m_OpenHandler.Invoke(target, sender, e);
			else if (m_Unregister != null)
			{
				m_Unregister(m_Handler);
				m_Unregister = null;
			}
		}

		public EventHandler<TEventArgs> Handler
		{
			get { return m_Handler; }
		}

		public static implicit operator EventHandler<TEventArgs>(WeakEventHandler<T, TEventArgs> weh)
		{
			return weh.m_Handler;
		}
	}
}