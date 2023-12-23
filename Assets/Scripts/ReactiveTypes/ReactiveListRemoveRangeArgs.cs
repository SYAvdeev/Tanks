using System;
using System.Collections.Generic;

namespace ReactiveTypes
{
	public class ReactiveListRemoveRangeArgs<TValue> : EventArgs
	{
		public int Index;
		public int Count;
		public IEnumerable<TValue> removedValues;

		public ReactiveListRemoveRangeArgs()
		{
			removedValues = new List<TValue>();
		}

		public ReactiveListRemoveRangeArgs(int index, int count, IEnumerable<TValue> removed)
		{
			Index = index;
			Count = count;
			removedValues = removed;
		}
	}
}
