using Microsoft.AspNetCore.Mvc;
using Minimo.Data;
using Minimo.Models;
using System.Diagnostics;

namespace Minimo.Controllers {
    public class HomeController : Controller {
        private readonly IPostsRepository _postsRepository;
        public HomeController(IPostsRepository repository) {
            this._postsRepository = repository;
        }

        public async Task<IActionResult> Index() {
            return View(await _postsRepository.GetPreviewPostListAsync());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}