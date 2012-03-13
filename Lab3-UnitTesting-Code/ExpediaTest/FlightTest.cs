using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        private readonly DateTime startDate = new DateTime(2010, 10, 18);
        private readonly DateTime endDate = new DateTime(2010, 10, 19);
        private readonly int miles = 1000;

        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(startDate, endDate, miles);
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestThatHasCorrectBasePriceSameDay()
        {
            var target = new Flight(startDate, startDate, miles);
            Assert.AreEqual((double)200, target.getBasePrice());
        }

        [Test()]
        public void TestThatHasCorrectBasePriceOneDay()
        {
            var target = new Flight(startDate, endDate, miles);
            Assert.AreEqual((double)220, target.getBasePrice());
        }

        [Test()]
        public void TestThatHasCorrectBasePriceTwoDay()
        {
            var target = new Flight(startDate, new DateTime(2010, 10,20), miles);
            Assert.AreEqual(240, target.getBasePrice());
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnBadDateRange()
        {
            new Flight(endDate, startDate, miles);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadMiles()
        {
            new Flight(startDate, endDate, -100);
        }

        [Test()]
        public void TestThatFlightEqualsReturnsTrueOnSameFlight()
        {
            var target = new Flight(startDate, endDate, 1000);
            Assert.True(target.Equals(target));
        }

        [Test()]
        public void TestThatFlightEqualsReturnsTrueOnSameFlightInfo()
        {
            var target1 = new Flight(startDate, endDate, 1000);
            var target2 = new Flight(startDate, endDate, 1000);
            Assert.True(target1.Equals(target2));
        }

        [Test()]
        public void TestThatFlightEqualsReturnsTrueOnSameFlightInfoReverse()
        {
            var target1 = new Flight(startDate, endDate, 1000);
            var target2 = new Flight(startDate, endDate, 1000);
            Assert.True(target2.Equals(target1));
        }

        [Test()]
        public void TestThatFlightEqualsReturnsFalseOnDifferentStartDate()
        {
            var target1 = new Flight(new DateTime(2010, 9, 20), endDate, 1000);
            var target2 = new Flight(startDate, endDate, 1000);
            Assert.False(target1.Equals(target2));
        }

        [Test()]
        public void TestThatFlightEqualsReturnsFalseOnDifferentStartDateReverse()
        {
            var target1 = new Flight(new DateTime(2010, 9, 20), endDate, 1000);
            var target2 = new Flight(startDate, endDate, 1000);
            Assert.False(target2.Equals(target1));
        }

        [Test()]
        public void TestThatFlightEqualsReturnsFalseOnDifferentEndDate()
        {
            var target1 = new Flight(startDate, new DateTime(2010, 11, 20), 1000);
            var target2 = new Flight(startDate, endDate, 1000);
            Assert.False(target1.Equals(target2));
        }

        [Test()]
        public void TestThatFlightEqualsReturnsFalseOnDifferentEndDateReverse()
        {
            var target1 = new Flight(startDate, new DateTime(2010, 11, 20), 1000);
            var target2 = new Flight(startDate, endDate, 1000);
            Assert.False(target2.Equals(target1));
        }

        [Test()]
        public void TestThatFlightEqualsReturnsFalseOnDifferentMiles()
        {
            var target1 = new Flight(startDate, endDate, 1001);
            var target2 = new Flight(startDate, endDate, 1000);
            Assert.False(target1.Equals(target2));
        }

        [Test()]
        public void TestThatFlightEqualsReturnsFalseOnDifferentMilesReverse()
        {
            var target1 = new Flight(startDate, endDate, 1001);
            var target2 = new Flight(startDate, endDate, 1000);
            Assert.False(target2.Equals(target1));
        }

        [Test()]
        public void TestThatFlightEqualsReturnsFalseOnObjectOtherThanFlight()
        {
            var target = new Flight(startDate, endDate, 1001);
            var hotel = new Hotel(10);
            Assert.False(target.Equals(hotel));
        }
	}
}
