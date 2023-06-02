using PixelHeartApi.Data;
using PixelHeartApi.Interfaces;
using PixelHeartApi.Models;

namespace PixelHeartApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DatabaseContext context;


        public UserRepository(DatabaseContext context) { this.context = context; }

        public int Create(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user.Id;
        }

        public bool Delete(int id)
        {
            var userToDelete = context.Users.Find(id);
            if (userToDelete is null)
            { return false; }
            context.Users.Remove(userToDelete);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User? GetByEmail(string email)
        {
            var user = context.Users.FirstOrDefault(u => u.Email == email);
            return user;
        }

        public User? GetById(int id)
        {
            return context.Users.FirstOrDefault(user => user.Id == id);
        }

        public bool Update(int id, User user)
        {
            var userToUpdate = context.Users.Find(id);
            if (userToUpdate is null)
            {
                return false;
            }
            userToUpdate.Name = user.Name;
            userToUpdate.Password = user.Password;
            userToUpdate.Age = user.Age;
            userToUpdate.Email = user.Email;
            userToUpdate.Backstory = user.Backstory;

            context.SaveChanges();

            return true;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }


    }
}
