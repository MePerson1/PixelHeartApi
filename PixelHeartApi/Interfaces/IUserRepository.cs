using PixelHeartApi.Models;

namespace PixelHeartApi.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User? GetById(int id);
        int Create(User user);
        bool Update(int id, User user);
        bool Delete(int id);
        //dodac sprawdzenie czy user o danym emailu istnieje
    }
}
