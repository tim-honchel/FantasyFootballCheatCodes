using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;

namespace Fantasy.Logic.Interfaces
{
    public interface ICsvStartersLogic
    {
        string Get(CsvStartersRequest request);
    }
}
