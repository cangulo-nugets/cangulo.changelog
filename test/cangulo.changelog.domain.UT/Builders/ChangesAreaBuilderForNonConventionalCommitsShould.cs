using cangulo.changelog.domain.Builders.NonConventionalCommits;
using cangulo.common.testing.dataatributes;
using FluentAssertions;
using Xunit;

namespace cangulo.changelog.domain.UT.Builders
{
    public class ChangesAreaBuilderForNonConventionalCommitsShould
    {
        [Theory]
        [AutoNSubstituteData]
        public void ReturnEmpty_WhenNoChangesProvided(
            ChangesAreaBuilderForNonConventionalCommits sut)
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
