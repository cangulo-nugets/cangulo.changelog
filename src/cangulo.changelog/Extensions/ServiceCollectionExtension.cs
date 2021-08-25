using cangulo.changelog.abstractions.models;
using cangulo.changelog.builders;
using cangulo.changelog.domain.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace cangulo.changelog.Extensions
{
    public static class ChangelogServiceCollectionExtension
    {
        public static IServiceCollection AddChangelogServices(this IServiceCollection services, ChangelogSettings changelogSettings)
        {
            return services
                .AddTransient<IReleaseNotesBuilder, ReleaseNotesBuilder>()
                .AddDomainServices(changelogSettings);
        }
    }
}