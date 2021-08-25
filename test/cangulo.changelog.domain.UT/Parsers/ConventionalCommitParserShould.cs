using cangulo.changelog.domain.Parsers;
using cangulo.common.testing.dataatributes;
using Xunit;

namespace cangulo.changelog.domain.UT.Parsers
{
    public class ConventionalCommitParserShould
    {
        [Theory]
        [InlineAutoNSubstituteData()]
        public async Task Build_HappyPath(
            ConventionalCommitParser sut)
        {
            // Arrange
            var input = await JsonTestDataParser.DeserializeFile<Input>(inputTestDataJsonFilePath);
            var expectedResult = await TextFileReader.ReadAsync(expectedResultFilePath);

            // Act
            var result = sut.Build(input.Changes);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}