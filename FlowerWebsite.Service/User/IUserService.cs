

namespace FlowerWebsite.Service
{
    public interface IUserService
    {
        UserRes GetUsers(UserReq req);
        UserRes RegisterUser(RegisterReq req, ref string msg);
    }
}
