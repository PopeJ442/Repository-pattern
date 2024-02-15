using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using Seedingdata.Models;

namespace RepositoryPattern.Repository
{
    public interface IPlayerRepository
    {
        Task<Player> CreatePlayer(Player player);
        Task<Player> EditPlayer(Player player);
        Task<Player> DeletePlayer(int id);
        Task<Player> Details(int id);
        Task<Player> GetPlayerById(int id);
        Task SaveChangesAsync();
        Task <List<Player>>GetAllPlayers();
        

    }
}


