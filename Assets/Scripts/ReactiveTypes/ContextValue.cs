namespace ReactiveTypes
{
	public class ContextValue<TContext, TValue>
	{
		public TContext Context { get; protected set; }
		public TValue Value { get; protected set; }

		public ContextValue(TContext context, TValue value)
		{
			Context = context;
			Value = value;
		}
	}
}
