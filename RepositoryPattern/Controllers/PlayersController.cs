

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Repository;
using Seedingdata.Models;

namespace RepositoryPattern.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayersController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        // GET: Players
        public async Task<IActionResult> Index()
        {
            var players = await _playerRepository.GetAllPlayers();
            return View(players);
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _playerRepository.Details(id.Value);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlayerName,PlayerPosition,JerseyNumber")] Player player)
        {
            if (ModelState.IsValid)
            {
                await _playerRepository.CreatePlayer(player);
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _playerRepository.GetPlayerById(id.Value);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // POST: Players/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlayerName,PlayerPosition,JerseyNumber")] Player player)
        {
            if (id != player.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _playerRepository.EditPlayer(player);
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _playerRepository.GetPlayerById(id.Value);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deletedPlayer = await _playerRepository.DeletePlayer(id);
            if (deletedPlayer == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
