namespace ReactiveTypes
{
	public class GenericEventArg<TValue>
	{
		public TValue Value;

		public GenericEventArg()
		{ }

		public GenericEventArg(TValue value)
		{
			Value = value;
		}
	}
}
