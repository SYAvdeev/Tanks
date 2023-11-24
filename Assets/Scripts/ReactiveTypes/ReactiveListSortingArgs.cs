using System;

namespace ReactiveTypes
{
	public class ReactiveListSortingArgs<TValue> : EventArgs
	{
		public int OldIndex;
		public int NewIndex;
		public TValue Value;

		public ReactiveListSortingArgs()
		{ }

		public ReactiveListSortingArgs(int oldIndex, int newIndex, TValue value)
		{
			OldIndex = oldIndex;
			NewIndex = newIndex;
			Value = value;
		}
	}
}
