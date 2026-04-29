namespace DatesAndStuff.Tests
{
    public sealed class SimulationTimeTests
    {
        [OneTimeSetUp]
        public void OneTimeSetupStuff()
        {
            // Setup code that runs once before all tests, if needed.
        }

        [SetUp]
        public void Setup()
        {
            // Setup code that runs before each test, if needed.
        }

        [TearDown]
        public void TearDown()
        {
            // Cleanup code that runs after each test, if needed.
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Cleanup code that runs once after all tests, if needed.
        }

        private class Constructors
        {
            [Test]
            public void Constructor_DateOnly_DiffersFromExactCurrentTime()
            {
                // Arrange
                var sut = new SimulationTime(2026, 2, 26);
                var now = SimulationTime.Now;

                // Act

                // Assert
                Assert.AreNotEqual(now.TotalMilliseconds, sut.TotalMilliseconds, "Should not be equal");
            }

            [Test]
            // Default time is not current time.
            public void SimulationTime_DefaultConstructor_ShouldNotBeCurrentTime()
            {
                // Arrange
                var sut = new SimulationTime();

                // Act
                var now = SimulationTime.Now;

                // Assert
                Assert.AreNotEqual(now.TotalMilliseconds, sut.TotalMilliseconds, "Should not be equal");
            }

            [Test]
            public void Constructor_WithAllParameters_ShouldWork()
            {
                var sut = new SimulationTime(2026, 5, 1, 10, 30, 0);
                Assert.AreEqual("2026-05-01T10:30:00", sut.ToString());
            }
        }

        [Test]
        public void SimulationTime_EqualsOperator_ShouldReturnTrueForEqualInstances()
        {
            // Arrange
            var sut1 = new SimulationTime(2026, 2, 26);
            var sut2 = new SimulationTime(2026, 2, 26);
            // Act
            // Assert
            Assert.AreEqual(sut1, sut2, "Should be equal");
        }

        [Test]
        public void SimulationTime_NotEqualsOperator_ShouldReturnFalseForEqualInstances()
        {
            // Arrange
            var sut1 = new SimulationTime(2026, 2, 26);
            var sut2 = new SimulationTime(2026, 2, 26);
            // Act
            // Assert
            Assert.IsFalse(sut1 != sut2);
        }

        [Test]
        public void SimulationTime_GreaterThanOperator_ShouldReturnFalseForEqualInstances()
        {
            // Arrange
            var sut1 = new SimulationTime(2026, 2, 26);
            var sut2 = new SimulationTime(2026, 2, 26);
            // Act
            // Assert
            Assert.IsFalse(sut1 > sut2, "Should not be greater than");
        }

        [Test]
        public void SimulationTime_LessThanOperator_ShouldReturnFalseForEqualInstances()
        {
            // Arrange
            var sut1 = new SimulationTime(2026, 2, 26);
            var sut2 = new SimulationTime(2026, 2, 26);
            // Act
            // Assert
            Assert.IsFalse(sut1 < sut2, "Should not be less than");
        }

        [Test]
            public void SimulationTime_GreaterThanOrEqualOperator_ShouldReturnTrueForEqualInstances()
            {
                // Arrange
                var sut1 = new SimulationTime(2026, 2, 26);
                var sut2 = new SimulationTime(2026, 2, 26);
                // Act
                // Assert
                Assert.IsTrue(sut1 >= sut2, "Should be greater than or equal");
        }

        [Test]
        public void SimulationTime_MaxValue_ShouldBeGreaterThanAnyOtherInstance()
        {
            // Arrange
            var sut = SimulationTime.MaxValue;
            var other = new SimulationTime(2026, 2, 26);
            // Act
            // Assert
            Assert.IsTrue(sut > other, "MaxValue should be greater than any other instance");
        }

        [Test]
        public void SimulationTime_MinValue_ShouldBeLessThanAnyOtherInstance()
        {
            // Arrange
            var sut = SimulationTime.MinValue;
            var other = new SimulationTime(2026, 2, 26);
            // Act
            // Assert
            Assert.IsTrue(sut < other, "MinValue should be less than any other instance");
        }

        private class TimeSpanArithmeticTests
        {

            [Test]
            // TimeSpanArithmetic
            // add
            // substract
            // Given_When_Then
            public void Addition_SimulationTimeIsShifted()
            {
                    // UserSignedIn_OrderSent_OrderIsRegistered
                    // DBB, specflow, cucumber, gherkin

                    // Arrange
                    DateTime baseDate = new DateTime(2010, 8, 23, 9, 4, 49);
                    SimulationTime sut = new SimulationTime(baseDate);

                    var ts = TimeSpan.FromMilliseconds(4544313);

                    // Act
                    var result = sut + ts;

                    // Assert
                    var expectedDateTime = baseDate + ts;
                    Assert.AreEqual(expectedDateTime, result.ToAbsoluteDateTime());
            }

            [Test]
            //Method_Should_Then
            public void Subtraction_SimulationTimeShifted()
            {
                // Code friendly
                // RegisterOrder_SignedInUserSendsOrder_OrderIsRegistered
                // Arrange
                DateTime baseDate = new DateTime(2010, 8, 23, 9, 4, 49);
                SimulationTime sut = new SimulationTime(baseDate);
                var ts = TimeSpan.FromMilliseconds(4544313);
                // Act
                var result = sut - ts;
                // Assert
                var expectedDateTime = baseDate - ts;
                Assert.AreEqual(expectedDateTime, result.ToAbsoluteDateTime());
            }
        }

        [Test]
        // Next millisec calculation works
        public void GivenSimulationTime_WhenCalculatingNextMillisec_ThenReturnsCorrectValue()
        {
            var sut = new SimulationTime(2026, 2, 26, 12, 0, 0);
            var next = sut.NextMillisec;
            Assert.AreEqual(sut.TotalMilliseconds + 1, next.TotalMilliseconds);
        }

        [Test]
        // Create a SimulationTime from a DateTime, add the same milliseconds to both and check if they are still equal
        public void GivenDateTimeAndSimulationTime_WhenAddingMilliseconds_ThenTimesShouldBeEqual()
        {
            var date = new DateTime(2026, 2, 26, 12, 0, 0);
            var sut = new SimulationTime(date);
            var result = sut.AddMilliseconds(500);
            Assert.AreEqual(date.AddMilliseconds(500), result.ToAbsoluteDateTime());
        }

        [Test]
        // The same as before just with seconds
        public void GiveDateTimeAndSimulationTime_WhenAddingSeconds_ThenTimesShouldBeEqual()
        {
            var date = new DateTime(2026, 2, 26, 12, 0, 0);
            var sut = new SimulationTime(date);
            var result = sut.AddSeconds(10);
            Assert.AreEqual(date.AddSeconds(10), result.ToAbsoluteDateTime());
        }

        [Test]
        // Check string representation given by ToString
        public void SimulationTime_ToString_ReturnsExpectedString()
        {
            // Arrange
            var sut = new SimulationTime(2026, 2, 26);

            // Act
            var result = sut.ToString();

            // Assert
            Assert.AreEqual("2026-02-26T00:00:00", result);
        }
    }
}
