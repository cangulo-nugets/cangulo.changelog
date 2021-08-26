using cangulo.changelog.domain.Builders;
using System;
using System.IO;
using System.Text;

namespace cangulo.changelog.builders
{
    public interface IChangelogBuilder
    {
        void Build(string version, string[] changes, string path);
    }
    public class ChangelogBuilder : IChangelogBuilder
    {
        private readonly IChangelogVersionNotesBuilder _changelogVersionNotesBuilder;

        public ChangelogBuilder(IChangelogVersionNotesBuilder changelogVersionNotesBuilder)
        {
            _changelogVersionNotesBuilder = changelogVersionNotesBuilder ?? throw new ArgumentNullException(nameof(changelogVersionNotesBuilder));
        }

        public void Build(string version, string[] changes, string path)
        {
            var notesForThisVersion = _changelogVersionNotesBuilder.Build(version, changes);

            if (!File.Exists(path))
            {
                File.Create(path);
                File.WriteAllText(path, notesForThisVersion);
            }
            else
            {
                var currentContent = File.ReadAllText(path);
                if (currentContent == string.Empty)
                {
                    File.WriteAllText(path, notesForThisVersion);
                }
                else
                {
                    var result = new StringBuilder();
                    result.AppendLine(notesForThisVersion);
                    result.Append(currentContent);
                    File.AppendAllText(path, result.ToString());
                }
            }
        }
    }
}