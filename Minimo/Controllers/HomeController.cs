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
            IndexViewModel vm = new IndexViewModel(
                await _postsRepository.GetMainPostAsync(),
                await _postsRepository.GetPreviewPostListAsync(0, 4), 
                await _postsRepository.GetPreviewPostListAsync(4, 2));
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Post(int id) {
            var post = await _postsRepository.GetPostAsync(id);
            PostViewModel vm = new PostViewModel() {
                Post = post,
                AlsoLikePosts = await _postsRepository.GetRandomPreviewPostListAsync(3,post),
                Comments = await _postsRepository.GetCommentsForPostAsync(post),
                MostCommentedPosts = await _postsRepository.GetTopCommentedPosts(3),
            };
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> GetPosts(int skip, int take) {
            var posts = await _postsRepository.GetPreviewPostListAsync(skip, take);
            return Json(posts);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(int? idPost, string? authorName, string? text, int? replyTo) {
            if(idPost is not null && authorName is not null && text is not null) {
                await _postsRepository.PushComment(idPost.Value, authorName, text, replyTo);
            }
            return Redirect($"Post/{idPost}#add-comment-form");
        }

        [HttpPost]
        public async Task<IActionResult> SubscribeToNewsletter(string email) {
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}