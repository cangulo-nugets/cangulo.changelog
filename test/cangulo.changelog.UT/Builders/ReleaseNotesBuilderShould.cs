// using cangulo.changelog.builders;
// using cangulo.common.testing;
// using System.Threading.Tasks;
// using FluentAssertions;
// using Xunit;
// using cangulo.common.testing.dataatributes;
// using cangulo.changelog.domain.Builders;

// namespace cangulo.changelog.UT.Builders
// {
//     public class ReleaseNotesBuilderShould
//     {
//         [Theory]
//         [InlineAutoNSubstituteData]
//         public async Task Build_HappyPath(
//             IChangesAreaBuilder changesAreaBuilder,
//             string[] changes,
//             string expectedResult,
//             ReleaseNotesBuilder sut)
//         {
//             // Arrange
//             changesAreaBuilder.


//                         // Act
//                         var result = sut.Build(changes);

//             // Assert
//             result.Should().BeEquivalentTo(expectedResult);
//         }
//     }
// }
