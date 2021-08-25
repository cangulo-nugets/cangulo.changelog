using System;
using System.Linq;
using cangulo.changelog.abstractions.models;
using static cangulo.changelog.abstractions.models.Constants;

namespace cangulo.changelog.domain.Parsers
{
    public interface IConventionalCommitParser
    {
        ConventionalCommit ParseConventionalCommit(string lastCommitMessage);
    }

    public class ConventionalCommitParser : IConventionalCommitParser
    {
        private ChangelogSettings _changelogSettings { get; set; }
        private const string InvalidCommitMsg = "commit msg does not provide a valid convention commit type.";

        public ConventionalCommitParser(ChangelogSettings changelogSettings)
        {
            _changelogSettings = changelogSettings ?? throw new ArgumentNullException(nameof(changelogSettings));
        }

        public ConventionalCommit ParseConventionalCommit(string lastCommitMessage)
        {
            var parts = lastCommitMessage.Split(":", StringSplitOptions.TrimEntries);

            if (parts.Length < 2)
                throw new ArgumentException(InvalidCommitMsg);

            var commitType = parts[0].Trim();
            if (CommitTypeIsNotValid(commitType))
                commitType = ConventionalCommitConstants.TYPE_OTHERS;

            return new ConventionalCommit
            {
                Type = commitType,
                Message = parts[1].Trim()
            };
        }

        private bool CommitTypeIsNotValid(string commitType) =>
            !_changelogSettings
                .ConventionCommitsSettings
                .Types
                .Any(x => commitType.Equals(x, StringComparison.InvariantCultureIgnoreCase));
    }
}