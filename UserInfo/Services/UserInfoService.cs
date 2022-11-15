using KnowCrow.UserInfo.Data;

namespace KnowCrow.UserInfo.Services;

public class UserInfoService
{
    private readonly Dictionary<int, UserInformation> _users;

    public UserInfoService()
    {
        var office = new Office(1, "Sweden", "Uppsala", "Påvel Snickares Gränd 12");
        _users = new Dictionary<int, UserInformation>
        {
            { 0, new UserInformation(1, "John", "Doe", new DateTime(1, 1, 1), office) },
            { 1, new UserInformation(1, "Anders", "Strömberg", new DateTime(1980, 04, 30), office) },
            { 2, new UserInformation(2, "Tobias", "Bertilsson", new DateTime(1980, 04, 24), office) }
        };
    }

    public UserInformation GetUser(int id) => _users[id];

    public IEnumerable<UserInformation> GetUsers() => _users.Values.ToList();
}