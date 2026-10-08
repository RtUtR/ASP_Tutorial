using ASp_Tutorial._4Day.Dtos_4;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;

namespace ASp_Tutorial._4Day
{
    public interface IUserService
    {
        IEnumerable<ListUserDTO> GetUsers();
        ResponseUserDTO?GetByID(int id);
        bool Delete(int id);
        ResponseUserDTO? Update(int id , UpdateuserDTO x);
        ResponseUserDTO Create(CreateUserDTO x);
    }
}
