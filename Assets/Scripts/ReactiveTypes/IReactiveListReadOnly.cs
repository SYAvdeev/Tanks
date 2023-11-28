using System;
using System.Collections;
using System.Collections.Generic;

namespace ReactiveTypes
{
	public interface IReactiveListReadOnlyUntyped : IEnumerable
	{
		object this[int index] { get; }
		int Count { get; }
	}
	
	public interface IReactiveListReadOnly<T> : IReactiveListReadOnlyUntyped, IEnumerable<T>
	{
		event Action<GenericPairEventArgs<int, T>> OnAddItem;
		event Action<GenericEventArg<IEnumerable<T>>> OnClear;
		event Action<GenericPairEventArgs<int, T>> OnElementChange;
		event Action<GenericPairEventArgs<int, T>> OnRemoveItem;
		event Action<ReactiveListSortingArgs<T>> OnSort;
		T this[int index] { get; }
		int IndexOf(T item);
	}
}
