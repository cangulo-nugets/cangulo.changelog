using System.Threading.Tasks;
using cangulo.changelog.domain.Builders;
using cangulo.common.testing;
using cangulo.common.testing.dataatributes;
using FluentAssertions;
using Xunit;

namespace cangulo.changelog.domain.UT.Builders
{
    public class ChangesAreaBuilderForConventionalCommitsShould
    {
        public class Input
        {
            public string[] Changes { get; set; }
        }

        [Theory]
        [InlineAutoNSubstituteData(
            "./Builders/testData/ConcentionalCommits_happyPath_input.json",
            "./Builders/testData/ConcentionalCommits_happyPath_expected.txt"
            )]
        public async Task Build_HappyPath(
            string inputTestDataJsonFilePath,
            string expectedResultFilePath,
            ChangesAreaBuilderForConventionalCommits sut)
        {
            // Arrange
            var input = await JsonTestDataParser.DeserializeFile<Input>(inputTestDataJsonFilePath);
            var expectedResult = await TextFileReader.ReadAsync(expectedResultFilePath);

            // Act
            var result = sut.Build(input.Changes);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }


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
