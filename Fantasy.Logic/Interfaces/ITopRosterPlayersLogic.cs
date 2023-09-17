using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;

namespace Fantasy.Logic.Interfaces
{
    public interface ITopRosterPlayersLogic
    {
        TopRosterPlayersResponse Get(TopRosterPlayersRequest request);
    }
}
