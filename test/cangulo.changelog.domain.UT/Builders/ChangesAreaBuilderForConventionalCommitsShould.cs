using cangulo.changelog.domain.Builders.ConventionalCommits;
using cangulo.common.testing.dataatributes;
using FluentAssertions;
using Xunit;

namespace cangulo.changelog.domain.UT.Builders
{
    public class ChangesAreaBuilderForConventionalCommitsShould
    {
        [Theory]
        [AutoNSubstituteData]
        public void ReturnEmpty_WhenInvalidEmptyChangesProvided(
            string version,
            ChangesAreaBuilderForConventionalCommits sut)
        {
            // Arrange
            var changes = new string[] { };
            // Act
            var result = sut.Build(changes);

            // Assert
            result.Should().BeEquivalentTo(string.Empty);
        }
    }

}
