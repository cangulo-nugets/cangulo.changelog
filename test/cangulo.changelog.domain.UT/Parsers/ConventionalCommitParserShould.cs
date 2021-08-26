using AutoFixture.Xunit2;
using cangulo.changelog.abstractions.models;
using cangulo.changelog.domain.Parsers;
using cangulo.common.testing;
using cangulo.common.testing.dataatributes;
using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace cangulo.changelog.domain.UT.Parsers
{
    public class ConventionalCommitParserShould
    {
        private const string TestDataPath = "./Parsers/testData/ConventionalCommitParserTestData.json";

        public class TestData
        {
            public string Scenario { get; set; }
            public string Input { get; set; }
            public ConventionalCommit Output { get; set; }
        }

        private static async Task<TestData> GetTestDataForScenario(string scenario)
        {
            var testCases = await JsonTestDataParser.DeserializeFile<TestData[]>(TestDataPath);
            return testCases.Single(x => x.Scenario == scenario);
        }

        private static void SetChangeLogSettings(ChangelogSettings changelogSettings)
        {
            changelogSettings.CommitsMode = CommitsMode.ConventionalCommits;
            changelogSettings.ConventionCommitsSettings = new ConventionalCommitsSettings
            {
                Types = new string[] { "feat", "fix" }
            };
        }

        [Theory]
        [InlineAutoNSubstituteData("conventional_type_feat")]
        [InlineAutoNSubstituteData("conventional_type_fix")]
        [InlineAutoNSubstituteData("invalid_conventional_type_provided")]
        [InlineAutoNSubstituteData("no_conventional_type_provided")]
        public async Task Should_Process_ConventionalCommits(
            string scenario,
            [Frozen] ChangelogSettings changelogSettings,
            ConventionalCommitParser sut)
        {
            // Arrange
            SetChangeLogSettings(changelogSettings);
            var testData = await GetTestDataForScenario(scenario);
            var input = testData.Input;
            var output = testData.Output;

            // Act
            var result = sut.Parse(input);

            // Assert
            result.Should().BeEquivalentTo(output);
        }
    }
}