using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;

namespace Fantasy.Logic.Interfaces
{
    public interface ITagsLogic
    {
        TagsResponse Get(TagsRequest request);
    }
}
