using System.Linq;
using System.Text;

namespace cangulo.changelog.domain.Builders
{
    public class ChangesAreaBuilderForNonConventionalCommits : IChangesAreaBuilder
    {
        public string Build(string[] changes)
        {
            if (changes.Any())
            {
                var body = new StringBuilder();

                changes
                    .ToList()
                    .ForEach(x => body.AppendLine(MarkdownBullet(x)));

                return body.ToString();
            }

            return string.Empty;
        }

        private string MarkdownBullet(string input) => $"* {input}";
    }
}