using PixelHeartApi.Data;
using PixelHeartApi.Interfaces;
using PixelHeartApi.Models;

namespace PixelHeartApi.Repositories
{
    public class GameRepository : IGameRepository
    {
        private DatabaseContext context;
        public GameRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public int Create(Game game)
        {

            context.Games.Add(game);
            context.SaveChanges();
            return game.Id;
        }

        public bool Delete(int id)
        {
            var gameToDelete = context.Games.Find(id);
            if (gameToDelete is null)
            { return false; }
            context.Games.Remove(gameToDelete);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<Game> GetAll()
        {
            return context.Games.ToList();
        }

        public ICollection<Game> GetAllGames()
        {
            throw new NotImplementedException();
        }

        public Game? GetById(int id)
        {
            return context.Games.FirstOrDefault(game => game.Id == id);
        }

        public ICollection<Game> GetGameByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> GetUserByGameId(int userId)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Game game)
        {
            var gameToUpadet = context.Games.Find(id);
            if (gameToUpadet is null)
            {
                return false;
            }
            gameToUpadet.Name = game.Name;

            context.SaveChanges();

            return true;
        }
    }
}
