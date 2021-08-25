using System;

namespace cangulo.changelog.abstractions.models
{
    public class ChangelogSettings
    {
        public CommitsMode CommitsMode { get; set; }
        public ConventionalCommitsSettings ConventionCommitsSettings { get; set; }
    }

    public class ConventionalCommitsSettings
    {
        public string[] Types { get; set; }
    }
}
