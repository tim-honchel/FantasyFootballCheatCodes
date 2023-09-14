
using Fantasy.Logic.Implementations;
using Fantasy.Logic.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Fantasy.Logic.Configuration
{
    public static class LogicLayerConfiguration
    {
        public static IServiceCollection AddDataScope(this IServiceCollection services)
        {
            services.AddTransient<ICostAnalysisLogic, CostAnalysisLogic>();
            services.AddTransient<ICsvStartersLogic, CsvStartersLogic>();
            services.AddTransient<ICsvSuggestedRostersLogic, CsvSuggestedRostersLogic>();
            services.AddTransient<IEditProjectionsLogic, EditProjectionsLogic>();
            services.AddTransient<IEspnPlayersLogic, EspnPlayersLogic>();
            services.AddTransient<IEspnRulesLogic, EspnRulesLogic>();
            services.AddTransient<IExpectedValueLogic, ExpectedValueLogic>();
            services.AddTransient<ILeagueRulesLogic, LeagueRulesLogic>();
            services.AddTransient<IPlayerProjectionsLogic, PlayerProjectionsLogic>();
            services.AddTransient<IPointAveragesLogic, PointAveragesLogic>();
            services.AddTransient<IPossibleRostersLogic, PossibleRostersLogic>();
            services.AddTransient<IRelativePointsLogic, RelativePointsLogic>();
            services.AddTransient<ISimplifiedDraftPoolLogic, SimplifiedDraftPoolLogic>();
            services.AddTransient<IStrongRosterLogic, StrongRosterLogic>();
            services.AddTransient<IStrongerRosterLogic, StrongerRosterLogic>();
            services.AddTransient<ISuggestedRostersLogic, SuggestedRostersLogic>();
            services.AddTransient<ITagsLogic, TagsLogic>();
            services.AddTransient<ITopRosterFrequencyLogic, TopRosterFrequencyLogic>();
            services.AddTransient<ITopRosterPercentLogic, TopRosterPercentLogic>();
            services.AddTransient<ITopRosterPlayersLogic, TopRosterPlayersLogic>();
            services.AddTransient<IValidRulesLogic, ValidRulesLogic>();
            return services;
        }
    }
}
