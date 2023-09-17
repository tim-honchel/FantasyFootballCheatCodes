using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;

namespace Fantasy.Logic.Interfaces
{
    public interface ICostAnalysisLogic
    {
        CostAnalysisResponse Get(CostAnalysisRequest request);
    }
}
