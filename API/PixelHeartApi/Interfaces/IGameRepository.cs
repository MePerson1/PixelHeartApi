using PixelHeartApi.Models;

namespace PixelHeartApi.Interfaces
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAll();
        Task<Game?> GetById(int id);
        Task<int> Create(Game game);
        Task<bool> Update(int id, Game game);
        Task<bool> Delete(int id);
        Task<IEnumerable<User>> GetUserByGameId(int gameId);

        Task SaveChanges();


    }
}
