using Microsoft.Extensions.DependencyInjection;
using cangulo.changelog.abstractions.models;
using cangulo.changelog.domain.Builders;
using cangulo.changelog.domain.Parsers;
using cangulo.changelog.domain.Builders.ConventionalCommits;
using cangulo.changelog.domain.Builders.NonConventionalCommits;

namespace cangulo.changelog.domain.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services, ChangelogSettings changelogSettings)
        {

            if (changelogSettings.CommitsMode is CommitsMode.ConventionalCommits)
                services
                    .AddTransient<IChangesListAreaBuilder, ChangesAreaBuilderForConventionalCommits>()
                    .AddTransient<IConventionalCommitParser, ConventionalCommitParser>()
                    .AddSingleton(changelogSettings);
            else if (changelogSettings.CommitsMode is CommitsMode.NonConventionalCommits)
                services
                    .AddTransient<IChangesListAreaBuilder, ChangesAreaBuilderForNonConventionalCommits>();

            services
                .AddTransient<IChangelogVersionNotesBuilder, ChangelogVersionNotesBuilder>();

            return services;
        }
    }
}