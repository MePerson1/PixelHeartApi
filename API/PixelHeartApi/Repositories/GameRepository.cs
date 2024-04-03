using Microsoft.EntityFrameworkCore;
using PixelHeartApi.Data;
using PixelHeartApi.Interfaces;
using PixelHeartApi.Models;

namespace PixelHeartApi.Repositories
{
    public class GameRepository : IGameRepository
    {
        private DatabaseContext _context;
        public GameRepository(DatabaseContext context)
        {
            this._context = context;
        }
        public async Task<int> Create(Game game)
        {

            await _context.Games.AddAsync(game);
            await SaveChanges();
            return game.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var gameToDelete = _context.Games.Find(id);
            if (gameToDelete is null)
            { return false; }
            _context.Games.Remove(gameToDelete);
            await SaveChanges();
            return true;
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game?> GetById(int id)
        {
            return await _context.Games.FirstOrDefaultAsync(game => game.Id == id);
        }

        public async Task<IEnumerable<User>> GetUserByGameId(int gameId)
        {
            var games = await _context.UserGames.Where(e => e.GameId == gameId).Include(p => p.User).ToListAsync();
            return games.Select(g => g.User);
        }

        public async Task<bool> Update(int id, Game game)
        {
            var gameToUpadet = await _context.Games.FindAsync(id);
            if (gameToUpadet is null)
            {
                return false;
            }
            gameToUpadet.Name = game.Name;

            await SaveChanges();

            return true;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
