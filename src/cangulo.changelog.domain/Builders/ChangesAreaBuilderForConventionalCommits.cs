using System.Linq;
using System.Text;

namespace cangulo.changelog.domain.Builders
{
    public class ChangesAreaBuilderForConventionalCommits : IChangesAreaBuilder
    {
        public string Build(string[] changes)
        {
            // 1. Read convention commit settings
            // 2. Parse Changes to conventional commits model
            // 3. Create groups depending of the conventional commits


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