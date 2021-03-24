using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using SUT = BrokerageLib;

namespace BrokerageLib.nUnit {
	[TestFixture]
	class NUnitTestClass {
		[TestCase]
		public void ReturnDate30DaysInFuture_WhenProposedDateFallsOnWeekday() {
			// arrange
			var pd = new SUT.PaymentSystem.PaymentDate();
			DateTime sampleDate = DateTime.Parse("7/6/2011");
			// act
			var futureDate = pd.CalculateFuturePaymentDate(sampleDate);
			// assert

			Assert.AreEqual(sampleDate.AddDays(30), futureDate);
		}

		[TestCase]
		public void ReturnMonday_WhenProposedDateFallsOnSunday() {
			// arrange
			var pd = new SUT.PaymentSystem.PaymentDate();

			DateTime sampleDate = DateTime.Parse("2011/7/8");

			// act
			var resultDateWhichShouldBeMonday = pd.CalculateFuturePaymentDate(sampleDate);

			// assert

			Assert.AreEqual(DayOfWeek.Monday, resultDateWhichShouldBeMonday.DayOfWeek);
		}

		[TestCase]
		public void ReturnMonday_WhenProposedDateFallsOnSaturday() {
			// arrange
			var pd = new SUT.PaymentSystem.PaymentDate();

			DateTime sampleDate = DateTime.Parse("7/7/2011");

			// act
			var resultDateWhichShouldBeMonday = pd.CalculateFuturePaymentDate(sampleDate);

			// assert

			Assert.AreEqual(DayOfWeek.Monday, resultDateWhichShouldBeMonday.DayOfWeek);
		}

		
		

		[TestCase]
		public void FloatingPointTest()
		{
			// Work with floating point numbers 
			// assert between scalar and floating point numbers


			// specify a tolerance for equals


		}

		

		[TestCase]
		public void BooleanTest()
		{
			// classic nUnit assert 
			int headCount = 20;
			Assert.IsTrue(headCount > 10);

			// with constraint syntax
			Assert.That(headCount > 10);

		}
		[TestCase]
		public void EqualTest()
		{
			// classic nUnit assert 
			string greeting = "welcome";
			Assert.AreEqual("welcome", greeting);

			// with constraint syntax
			Assert.That(greeting, new EqualConstraint("welcome"));
			Assert.That(greeting, Is.EqualTo("welcome"));
			Assert.That(greeting, Is.Not.EqualTo("hello"));
			Assert.That(greeting, Is.EqualTo("Welcome").IgnoreCase);
		}

		[TestCase]
		public void EqualModifiersTest()
		{

			// EqualTo, Numeric modifiers
			// in float math, rounding error can make
			// 3.0 == 2.9999999
			var floatMathResult = 2.9999999;
			Assert.That(floatMathResult, Is.EqualTo(3.0).Within(0.0000001));
			Assert.That(82, Is.EqualTo(100).Within(20).Percent);

            // EqualTo, DateTime modifiers
            DateTime date1 = DateTime.Parse("2020/7/15");
			DateTime date2 = DateTime.Parse("2020/7/17");

			Assert.That(date1, Is.EqualTo(date2).Within(3).Days);

		}

		[TestCase]
		public void SameAsTest()
		{
			// test for object identity
			var tour1 = new Tour { TourName = "Chicago" };
			var tour2 = new Tour { TourName = "Barcelona" };

			var tourCopy = tour1;
			Assert.That(tour1, Is.SameAs(tourCopy));

		}

		[TestCase]
		public void ComparisonTest()
		{
			Assert.That(100, Is.GreaterThan(75));
			Assert.That(100, Is.LessThanOrEqualTo(200));
		}

		[TestCase]
		public void ConditionTest()
		{
			Tour tourNull = null;
			Tour tourInstantiated = new Tour { TourName = "Singapore" };

			Assert.That(tourNull, Is.Null);
			Assert.That(tourInstantiated, Is.Not.Null);


			var tours = new List<Tour>();
			tours.Add(tourNull);
			tours.Add(tourInstantiated);
			Assert.That(tours, Is.Not.Empty);
		}
		[TestCase]
		public void TypeTest()
		{
			Tour tour = new Tour { TourName = "Stockholm" };
			Assert.That(tour, Is.TypeOf(typeof(Tour)));
		}
		[TestCase]
		public void CollectionTest()
		{
			var colors = new List<string> { "red", "blue", "green", "yellow" };
			var otherColors = new List<string> { "blue", "yellow" };
			Assert.That(colors, Is.Unique);
			Assert.That(otherColors, Is.SubsetOf(colors));
		}

		[TestCase(2201)]
		[TestCase(603)]
		[TestCase(700)]
		public void ReturnTrue_WhenThereIsAOddDigit(int candidateNumber)
		{
			// arrange
			var analyzer = new SUT.NumberAnalyzer(candidateNumber);

			// act
			var result = analyzer.ContainsOddDigit();

			// assert
			Assert.True(result);

		}

		[TestCase(101, 1, 2)]
		[TestCase(222345, 2, 3)]
		[TestCase(123, 4, 0)]
		public void ReturnsCountWithMultiParam(int candidateNumber,
																		 int testDigit,
																		 int expectedCount)
		{
			// arrange

			var analyzer = new SUT.NumberAnalyzer(candidateNumber);

			// act

			var result = analyzer.GetTheCountOfThisDigit(testDigit);

			// assert

			Assert.AreEqual(expectedCount, result);

		}

	}

	class Tour
	{
		public string TourName { get; set; }
		public string Description { get; set; }
	}
}
