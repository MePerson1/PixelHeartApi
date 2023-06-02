﻿using PixelHeartApi.Models;

namespace PixelHeartApi.Interfaces
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetAll();
        Game? GetById(int id);
        int Create(Game game);
        bool Update(int id, Game game);
        bool Delete(int id);

        ICollection<Game> GetGameByUserId(int userId);
        ICollection<Game> GetAllGames();
        ICollection<User> GetUserByGameId(int userId);


    }
}