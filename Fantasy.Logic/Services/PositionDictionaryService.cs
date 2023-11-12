
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
    }
}
