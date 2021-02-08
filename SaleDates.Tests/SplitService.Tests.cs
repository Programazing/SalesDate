using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace SaleDates.Tests
{
    [TestFixture]
    public class SplitServiceTests
    {
        [Test]
        public void SplitService_IsTodayASaleDayForTheUser_ReturnsTrue_IfTheUser_IsInAValidDateRange()
        {
            var sut = new Services.SplitService();

            var repository = new Data.UserRepository();
            var jane = repository.GetUsers().Where(x => x.Name == "Jane Doe").FirstOrDefault();

            sut.IsTodayASaleDayForTheUser(jane).Result.Should().Be(true);
        }

        [Test]
        public void SplitService_IsTodayASaleDayForTheUser_ReturnsFalse_IfTheUser_IsNotInAValidDateRange()
        {
            var sut = new Services.SplitService();

            var repository = new Data.UserRepository();
            var john = repository.GetUsers().Where(x => x.Name == "John Smith").FirstOrDefault();

            sut.IsTodayASaleDayForTheUser(john).Result.Should().Be(false);
        }
    }
}
