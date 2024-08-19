using System;
using System.Collections;
using System.Collections.Generic;

namespace xUnitDemo
{
	public class DivisionTestData : IEnumerable<object[]>
	{
		public IEnumerator<object[]> GetEnumerator()
		{
			var values = new List<Tuple<decimal, decimal[]>>
			{
				new(30, new decimal[] { 60, 2 }),
				new(0, new decimal[] { 0, 1 }),
				new(1, new decimal[] { 10, 10 })
			};

			foreach (var value in values)
				yield return new object[] { value.Item1, value.Item2 };
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
