using Microsoft.Extensions.DependencyInjection;
using cangulo.changelog.abstractions.models;
using cangulo.changelog.domain.Builders;

namespace cangulo.changelog.domain.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services, ChangelogSettings changelogSettings)
        {

            if (changelogSettings.CommitsMode is CommitsMode.ConventionalCommits)
                services.AddTransient<IChangesAreaBuilder, ChangesAreaBuilderForConventionalCommits>();
            else if (changelogSettings.CommitsMode is CommitsMode.NonConventionalCommits)
                services.AddTransient<IChangesAreaBuilder, ChangesAreaBuilderForNonConventionalCommits>();

            return services;
        }
    }
}