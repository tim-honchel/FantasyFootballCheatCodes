
namespace Fantasy.Logic.Services
{
    public class PositionListService
    {
        public static List<string> GetListOfBasePositions()
        {
            var listOfBasePositions = new List<string>()

            {
                BasePositionConstants.Coach,
                BasePositionConstants.Cornerback,
                BasePositionConstants.DefensiveEnd,
                BasePositionConstants.DefensiveTackle,
                BasePositionConstants.Kicker,
                BasePositionConstants.Linebacker,
                BasePositionConstants.Punter,
                BasePositionConstants.Quarterback,
                BasePositionConstants.RunningBack,
                BasePositionConstants.Safety,
                BasePositionConstants.TeamDefense,
                BasePositionConstants.TeamQuarterback,
                BasePositionConstants.TightEnd,
                BasePositionConstants.WideReceiver
            };

            return listOfBasePositions;
        }
    }
}
