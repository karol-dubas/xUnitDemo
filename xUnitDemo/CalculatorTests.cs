using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace xUnitDemo
{
	public class CalculatorTests
	{
		// System under tests
		private readonly Calculator _sut;

		public CalculatorTests()
		{
			_sut = new Calculator();
		}

		[Fact(Skip = "test description")]
		public void AddTwoNumbersShouldEqualTheirEqual()
		{
			_sut.Add(3);
			_sut.Add(2);

			Assert.Equal(5, _sut.Value);
		}

		[Theory]
		[InlineData(5, 2, 3)]
		[InlineData(0, -3, 3)]
		[InlineData(0, 0, 0)]
		public void AddTwoNumbersShouldEqualTheirEqualTheory(
			decimal expected,
			decimal firstToAdd,
			decimal secondToAdd)
		{
			_sut.Add(firstToAdd);
			_sut.Add(secondToAdd);

			Assert.Equal(expected, _sut.Value);
		}

		[Theory]
		[MemberData(nameof(TestData))]
		public void AddManyNumbersShouldEqualTheirEqualTheory(
			decimal expected,
			params decimal[] valuesToAdd)
		{
			foreach (decimal value in valuesToAdd)
			{
				_sut.Add(value);
			}

			Assert.Equal(expected, _sut.Value);
		}

		public static IEnumerable<object[]> TestData()
		{
			var values = new List<Tuple<decimal, decimal[]>>
			{
				new(15, new decimal[] { 10, 5 }),
				new(15, new decimal[] { 5, 5, 5 }),
				new(0, new decimal[] { -5, 5, 0 }),
				new(-5, new decimal[] { -2, -3 })
			};

			return values.Select(v => new object[] { v.Item1, v.Item2 });
		}

		[Theory]
		[ClassData(typeof(DivisionTestData))]
		public void DivideManyNumbersTheory(
			decimal expected,
			params decimal[] valuesToAdd)
		{
			foreach (decimal value in valuesToAdd)
			{
				_sut.Divide(value);
			}

			Assert.Equal(expected, _sut.Value);
		}
	}
}
