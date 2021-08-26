using System;
using System.Linq;
using cangulo.changelog.abstractions.models;
using static cangulo.changelog.abstractions.models.Constants;

namespace cangulo.changelog.domain.Parsers
{
    public interface IConventionalCommitParser
    {
        ConventionalCommit Parse(string commitMsg);
    }

    public class ConventionalCommitParser : IConventionalCommitParser
    {
        private ChangelogSettings _changelogSettings { get; set; }

        public ConventionalCommitParser(ChangelogSettings changelogSettings)
        {
            _changelogSettings = changelogSettings ?? throw new ArgumentNullException(nameof(changelogSettings));
        }

        public ConventionalCommit Parse(string commitMsg)
        {
            var parts = commitMsg.Split(":", StringSplitOptions.TrimEntries);

            if (parts.Length < 2)
            {
                return new ConventionalCommit
                {
                    Type = ConventionalCommitConstants.TYPE_OTHERS,
                    Message = commitMsg
                };
            }

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