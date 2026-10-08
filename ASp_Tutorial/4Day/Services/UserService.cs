using ASp_Tutorial._4Day.Entitiy;
using ASp_Tutorial._4Day.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace ASp_Tutorial._4Day.Dtos_4
{
    public class UserService : IUserService
    {
        private static List<UserEntity> _entities = new List<UserEntity>()
        {
            new UserEntity{Id=1,Name="Ali 1",Phone="0933 421 1423",IsMarried=true,LastName="Ahmadiyan 1"}
            ,new UserEntity{Id=2,Name="Ali 2",Phone="0922 444 6423",IsMarried=false,LastName="Ahmadiyan 2"}
            ,new UserEntity{Id=3,Name="Ali 3",Phone="0918 271 8753",IsMarried=false,LastName="Ahmadiyan 3"}
        };
        private static int Index = 4;
        public bool Delete(int id)
        {
            UserEntity? o =_entities.FirstOrDefault(w => w.Id == id);
            if (o is null) return false;
            _entities.Remove(o);
            return true;
        }

        public ResponseUserDTO? GetByID(int id)
        {
            UserEntity? Result = _entities.FirstOrDefault(w=>w.Id == id);
            if(Result is null) return null;
            ResponseUserDTO resu= Result.ToResponse();
            return resu;
        
        }

        public IEnumerable<ListUserDTO> GetUsers()
        {
           return _entities.Select(x=>x.ToList_user()).ToList();
        }

        public ResponseUserDTO ?Update(int id, UpdateuserDTO x)
        {
            UserEntity?User= _entities.FirstOrDefault(x => x.Id == id);
            if (User is null) return null;
            User.Name = x.Name;
            User.Phone = x.Phone;
            User.IsMarried = x.IsMarried;
            return User.ToResponse();
        
        }
        public ResponseUserDTO Create(CreateUserDTO x)
        {
            var t = x.ToEntity();
            t.Id = Index++;
            _entities.Add(t);
            return t.ToResponse();
        }
    }
}
