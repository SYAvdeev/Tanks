namespace ReactiveTypes
{
	public interface IReactiveList<T> : IReactiveListReadOnly<T>
	{
		void Add(T item);
		bool Remove(T item);
		void RemoveAt(int index);
	}
}
