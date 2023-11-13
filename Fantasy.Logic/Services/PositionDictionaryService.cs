
using Fantasy.Logic.Models;

namespace Fantasy.Logic.Services
{
    public static class PositionDictionaryService
    {
        public static Dictionary<string, List<string>> GetComboPositionsAndTheirBasePositions()
        {
            Dictionary<string, List<string>> positions = new Dictionary<string, List<string>>()
            {
                // offense in order of priority
                {ComboPositionConstants.ReceiversAndEnds, new List<string>() {BasePositionConstants.WideReceiver, BasePositionConstants.TightEnd} },
                {ComboPositionConstants.BacksAndReceivers, new List<string>() {BasePositionConstants.RunningBack, BasePositionConstants.WideReceiver } },
                {ComboPositionConstants.FLEX, new List<string>() {BasePositionConstants.RunningBack, BasePositionConstants.WideReceiver, BasePositionConstants.TightEnd } },
                {ComboPositionConstants.OffensivePlayerUtilities, new List<string>() {BasePositionConstants.Quarterback, BasePositionConstants.RunningBack, BasePositionConstants.WideReceiver, BasePositionConstants.TightEnd } },

                // defense in order of priority
                {ComboPositionConstants.DefensiveBacks, new List<string>() {BasePositionConstants.Cornerback, BasePositionConstants.Safety } },
                {ComboPositionConstants.DefensiveLinemen, new List<string>() {BasePositionConstants.DefensiveTackle, BasePositionConstants.DefensiveEnd } },
                {ComboPositionConstants.DefensivePlayerUtilities, new List<string>() {BasePositionConstants.DefensiveTackle, BasePositionConstants.DefensiveEnd, BasePositionConstants.Linebacker, BasePositionConstants.Cornerback, BasePositionConstants.Safety } },

                
            };
            
            return positions;
        }

        public static Dictionary<string, int> GetMaximumPlayersPerPosition(Positions positions)
        {
            Dictionary<string, int> maximumPlayersPerPosition = new()
            {
                { BasePositionConstants.Coach, Math.Max(0,positions.Coaches[1]) },
                { BasePositionConstants.Cornerback, Math.Max(0,positions.Cornerbacks[1]) },
                { BasePositionConstants.DefensiveEnd, Math.Max(0,positions.DefensiveEnds[1])},
                { BasePositionConstants.DefensiveTackle, Math.Max(0,positions.DefensiveTackles[1])},
                { BasePositionConstants.Kicker, Math.Max(0,positions.Kickers[1])},
                { BasePositionConstants.Linebacker, Math.Max(0,positions.Linebackers[1])},
                { BasePositionConstants.Punter, Math.Max(0,positions.Punters[1])},
                { BasePositionConstants.Quarterback, Math.Max(0,positions.Quarterbacks[1])},
                { BasePositionConstants.RunningBack, Math.Max(0,positions.RunningBacks[1])},
                { BasePositionConstants.Safety, Math.Max(0,positions.Safeties[1])},
                { BasePositionConstants.TeamDefense, Math.Max(0,positions.TeamDefenses[1])},
                { BasePositionConstants.TeamQuarterback, Math.Max(0,positions.TeamQuarterbacks[1])},
                { BasePositionConstants.TightEnd, Math.Max(0,positions.TightEnds[1])},
                { BasePositionConstants.WideReceiver, Math.Max(0,positions.WideReceivers[1])}
            };

            return maximumPlayersPerPosition;
        }

        public static Dictionary<string, int> GetStarterSlotsByPosition(Positions positions)
        {
            Dictionary<string, int> starterSlotsByPosition = new()
            {
                { BasePositionConstants.Coach, Math.Max(0,positions.Coaches[0]) },
                { BasePositionConstants.Cornerback, Math.Max(0,positions.Cornerbacks[0]) },
                { BasePositionConstants.DefensiveEnd, Math.Max(0,positions.DefensiveEnds[0]) },
                { BasePositionConstants.DefensiveTackle, Math.Max(0,positions.DefensiveTackles[0]) },
                { BasePositionConstants.Kicker, Math.Max(0,positions.Kickers[0]) },
                { BasePositionConstants.Linebacker, Math.Max(0,positions.Linebackers[0]) },
                { BasePositionConstants.Punter, Math.Max(0,positions.Punters[0]) },
                { BasePositionConstants.Quarterback, Math.Max(0,positions.Quarterbacks[0]) },
                { BasePositionConstants.RunningBack, Math.Max(0,positions.RunningBacks[0]) },
                { BasePositionConstants.Safety, Math.Max(0,positions.Safeties[0]) },
                { BasePositionConstants.TeamDefense, Math.Max(0,positions.TeamDefenses[0]) },
                { BasePositionConstants.TeamQuarterback, Math.Max(0,positions.TeamQuarterbacks[0]) },
                { BasePositionConstants.TightEnd, Math.Max(0,positions.TightEnds[0]) },
                { BasePositionConstants.WideReceiver, Math.Max(0,positions.WideReceivers[0]) },

                { ComboPositionConstants.BacksAndReceivers, Math.Max(0,positions.BacksAndReceivers) },
                { ComboPositionConstants.DefensiveBacks, Math.Max(0,positions.DefensiveBacks) },
                { ComboPositionConstants.DefensiveLinemen, Math.Max(0,positions.DefensiveLinemen) },
                { ComboPositionConstants.DefensivePlayerUtilities, Math.Max(0,positions.DefensivePlayerUtilities) },
                { ComboPositionConstants.FLEX, Math.Max(0,positions.FLEX) },
                { ComboPositionConstants.OffensivePlayerUtilities, Math.Max(0,positions.OffensivePlayerUtilities) },
                { ComboPositionConstants.ReceiversAndEnds, Math.Max(0,positions.ReceiversAndEnds) }
            };

            return starterSlotsByPosition;
        }
    }
}
