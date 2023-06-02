using PixelHeartApi.Models;

namespace PixelHeartApi.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User? GetById(int id);
        User? GetByEmail(string email);
        int Create(User user);
        bool Update(int id, User user);
        bool Delete(int id);
        void SaveChanges();
    }
}
