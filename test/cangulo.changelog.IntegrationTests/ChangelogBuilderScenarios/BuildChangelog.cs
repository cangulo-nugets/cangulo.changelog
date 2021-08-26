using cangulo.changelog.abstractions.models;
using cangulo.changelog.builders;
using cangulo.changelog.IntegrationTests.Helpers;
using cangulo.changelog.IntegrationTests.Models;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace cangulo.changelog.IntegrationTests.ChangelogBuilderScenarios.NonConventionalCommits
{
    public class BuildChangelog
    {
        private readonly IChangelogBuilder sut;
        private const string TestDataPath = "./ChangelogBuilderScenarios/BuildChangelogTestData.json";
        private const string TemporalOutputChangelogPath = "./ChangelogBuilderScenarios/OutputChangelogPath.md";

        public BuildChangelog()
        {
            var changelogSettings = new ChangelogSettings
            {
                CommitsMode = CommitsMode.NonConventionalCommits
            };

            var serviceProvider = ServicesForTestBuilder.GetServiceProvider(changelogSettings);
            sut = serviceProvider.GetRequiredService<IChangelogBuilder>();
        }

        [Theory]
        [InlineData("first_version")]
        [InlineData("second_version")]
        public async Task HappyPath(string scenario)
        {
            // Arrange
            var testData = await TestDataHelper.GetTestDataForScenario<BuildChangelogTestData>(scenario, TestDataPath);
            var input = testData.Input;
            var expectedOutputLines = testData.ExpectedOutput;

            PreparePreviousChangelogFile(input);

            // Act
            sut.Build(input.Version, input.NewChanges, TemporalOutputChangelogPath);
            var resultLines = File.ReadAllLines(TemporalOutputChangelogPath);

            // Assert
            resultLines
                .Length
                .Should()
                .Be(expectedOutputLines.Length, "result doesn't have the same length as the expected result");


            var lineResultVslineExpected = resultLines.Zip(expectedOutputLines, (resultLine, expectedLine) => new { resultLine, expectedLine });

            lineResultVslineExpected
                .ToList()
                .ForEach(x =>
                    {
                        var lineContainsPlaceholder = PlaceholderConstants.PLACEHOLDER_LIST.Any(y => y == x.expectedLine);
                        if (!lineContainsPlaceholder)
                            x.resultLine.Should().BeEquivalentTo(x.expectedLine);
                    });
        }
        private static void PreparePreviousChangelogFile(Input input)
        {
            var currentChangelogContent = string.Join("\r\n", input.PreviousChangelogFile.ToArray());
            File.WriteAllText(TemporalOutputChangelogPath, currentChangelogContent);
        }
    }
}
