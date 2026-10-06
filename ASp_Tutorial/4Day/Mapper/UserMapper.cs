using ASp_Tutorial._4Day.Dtos_4;
using ASp_Tutorial._4Day.Entitiy;

namespace ASp_Tutorial._4Day.Mapper
{
    public static class UserMapper
    {
        public static UserEntity ToEntity(this CreateUserDTO x)
        {
            UserEntity userEntity=new UserEntity() 
            {
                IsMarried=x.IsMarried,
                LastName=x.LastName,
                Name=x.Name,
                Phone=x.phone,
                RegisterDate=DateTimeOffset.UtcNow
            };
            return userEntity;
        }
        public static ListUserDTO ToList_user(this UserEntity x)
        {
            ListUserDTO New = new ListUserDTO(
                IsMarried : x.IsMarried,
                LastName : x.LastName,
                Name : x.Name);
           return New;
        }
        public static ResponseUserDTO ToResponse(this UserEntity x)
        {
            var i = new ResponseUserDTO(
                Id : x.Id,
                Name:x.Name,
                LastName:x.LastName,
                register:x.RegisterDate
                );
            return i;
        }

    }
}
