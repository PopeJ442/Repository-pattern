using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using Seedingdata.Models;
using System;
using System.Numerics;

namespace RepositoryPattern.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext _context;
        public PlayerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Player> CreatePlayer(Player player)
        {
            
            _context.Staging_Players.Add(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<Player> DeletePlayer(int id)
        {
          

            var player = await _context.Staging_Players.FindAsync(id);
            if (player == null) { return null; }
            _context.Staging_Players.Remove(player);
            await _context.SaveChangesAsync();
            return player;

        }

        public async Task<Player> Details(int id)
        {   
            return await _context.Staging_Players.FindAsync(id);
        }

        public async Task<Player> EditPlayer(Player player)
        {
            _context.Staging_Players.Update(player);
            await _context.SaveChangesAsync();
            return player;
        }

      

        public async Task<Player> GetPlayerById(int id)
        {
            return  await _context.Staging_Players.FindAsync(id);
         
            
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

       async  Task<List<Player>> IPlayerRepository.GetAllPlayers()
        {
            return await _context.Staging_Players.ToListAsync();
        }
    }


}