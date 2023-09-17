using Fantasy.Logic.Interfaces;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;

namespace Fantasy.Logic.Implementations
{
    public class LeagueRulesLogic : ILeagueRulesLogic
    {
        public LeagueRulesResponse Get(LeagueRulesRequest request)
        {
            LeagueRulesResponse response = new LeagueRulesResponse();

            if (request.Provider == Provider.ESPN)
            {
                response = ParseESPNRules(request.EspnRules);
            }
            else
            {
                response.Success = false;
                response.ErrorTypes.Add(ErrorType.ProviderNotSupported);
            }

            return response;
        }

        Positions ParseESPNPositions(Dictionary<int,int> positionSlotCounts, Dictionary<int,int> positionLimits)
        {
            Positions positions = new Positions()
            {
                Quarterbacks = new int[] { positionSlotCounts[0], positionLimits[1] },
                RunningBacks = new int[] { positionSlotCounts[2], positionLimits[2] },
                WideReceivers = new int[] { positionSlotCounts[4], positionLimits[3] },
                TightEnds = new int[] { positionSlotCounts[6], positionLimits[4] },
                FLEX = positionSlotCounts[21],
                Kickers = new int[] { positionSlotCounts[17], positionLimits[5] },
                TeamDefenses = new int[] { positionSlotCounts[16], positionLimits[16] },
                Bench = positionSlotCounts[20],
                InjuredReserve = positionSlotCounts[22],

                DefensiveTackles = new int[] { positionSlotCounts[8], positionLimits[8] },
                DefensiveEnds = new int[] { positionSlotCounts[9], positionLimits[9] },
                Linebackers = new int[] { positionSlotCounts[10], positionLimits[10] },
                Cornerbacks = new int[] { positionSlotCounts[11], positionLimits[11] },
                Safeties = new int[] { positionSlotCounts[12], positionLimits[12] },
                Punters = new int[] { positionSlotCounts[18], positionLimits[6] },
                Coaches = new int[] { positionSlotCounts[19], positionLimits[7] },

                TeamQuarterbacks = new int[] { positionSlotCounts[1], positionLimits[0] },
                BacksAndReceivers = positionSlotCounts[3],
                ReceiversAndEnds = positionSlotCounts[5],
                OffensivePlayerUtilities = positionSlotCounts[7],
                Linemen = positionSlotCounts[11],
                DefensiveBacks = positionSlotCounts[14],
                DefensivePlayerUtilities = positionSlotCounts[15],
            };
            return positions;
        }
        
        LeagueRulesResponse ParseESPNRules(RulesESPN rawRules)
        {
            LeagueRulesResponse response = new();

            Positions positions = ParseESPNPositions(rawRules.PositionSlotCounts, rawRules.PositionLimits);

            Settings settings = ParseESPNSettings(rawRules);

            Size size = new Size()
            {
                PlayoffTeams = rawRules.PlayoffTeams,
                Teams = rawRules.Teams,
            };

            Status status = new Status()
            {
                DraftComplete = rawRules.DraftComplete,
                DraftInProgress = rawRules.DraftInProgress,
                IsActive = rawRules.IsActive,
                Season = rawRules.Season,
            };

            Rules rules = new Rules()
            {
                LeagueID = rawRules.LeagueID,
                Positions = positions,
                Settings = settings,
                Size = size,
                Status = status,
            };

            response.Success = true;
            response.Rules = rules;

            return response;
        }

        public Settings ParseESPNSettings(RulesESPN rawRules)
        {
            bool keeper = rawRules.KeeperCount > 0;

            Dictionary<string, DraftOrderType> draftOrderTypeDictionary = new()
            {
                {"NONE", DraftOrderType.None}
            };
            DraftOrderType draftOrderType;
            if (draftOrderTypeDictionary.ContainsKey(rawRules.DraftOrderType.ToUpper()))
            {
                draftOrderType = draftOrderTypeDictionary[rawRules.DraftOrderType.ToUpper()];
            }
            else
            {
                draftOrderType = DraftOrderType.Other;
            }

            Dictionary<string, DraftType> draftTypeDictionary = new()
            {
                {"AUCTION", DraftType.Auction }
            };
            DraftType draftType;
            if (draftTypeDictionary.ContainsKey(rawRules.DraftType.ToUpper()))
            {
                draftType = draftTypeDictionary[rawRules.DraftType.ToUpper()];
            }
            else
            {
                draftType = DraftType.Other;
            }

            Dictionary<string, ScoringType> scoringTypeDictionary = new()
            {
                {"H2H_POINTS", ScoringType.HeadToHead }
            };
            ScoringType scoringType;
            if (scoringTypeDictionary.ContainsKey(rawRules.ScoringType.ToUpper()))
            {
                scoringType = scoringTypeDictionary[rawRules.ScoringType.ToUpper()];
            }
            else
            {
                scoringType = ScoringType.Other;
            }

            Settings settings = new Settings()
            {
                DraftOrderType = draftOrderType,
                DraftPick = 0,
                DraftType = draftType,
                IsTradingEnabled = rawRules.IsTradingEnabled,
                Keeper = rawRules.KeeperCount > 0,
                SalaryCap = rawRules.AuctionBudget,
                ScoringType = scoringType
            };
            return settings;
        }
    }
}
