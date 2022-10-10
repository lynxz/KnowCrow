using KnowCrow.UserInfo.Data;
using KnowCrow.UserInfo.Services;

namespace KnowCrow.UserInfo;

public class Query
{
    public IEnumerable<UserInformation> GetUsers([Service] UserInfoService service) =>
        service.GetUsers();

    public UserInformation GetUser(int id, [Service] UserInfoService service) =>
        service.GetUser(id);
}
