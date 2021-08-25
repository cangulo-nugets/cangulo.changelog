using System;
using cangulo.changelog.domain.Builders;

namespace cangulo.changelog.builders
{
    public interface IReleaseNotesBuilder
    {
        string Build(string[] changes);
    }

    public class ReleaseNotesBuilder : IReleaseNotesBuilder
    {
        private readonly IChangesAreaBuilder _changesAreaBuilder;

        public ReleaseNotesBuilder(IChangesAreaBuilder changesAreaBuilder)
        {
            _changesAreaBuilder = changesAreaBuilder ?? throw new ArgumentNullException(nameof(changesAreaBuilder));
        }
        public string Build(string[] changes)
            => _changesAreaBuilder.Build(changes);
    }
}
