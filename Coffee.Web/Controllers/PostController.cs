using AutoMapper;
using Coffee.Web.Data;
using Coffee.Web.DTOs;
using Coffee.Web.Models;
using Coffee.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Slugify;
using System.Net.WebSockets;

namespace Coffee.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository repo;
        private readonly IMapper mapper;
        
        private readonly SlugHelper _slughelper;

        public PostController(IPostRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
            
            _slughelper = new SlugHelper();
        }
        public async Task<IActionResult> Index()
        {
            var posts = await repo.GetAllAsync();
            var dto = mapper.Map<List<PostDto>>(posts);
            return View(dto);
        }



        public async Task<IActionResult> Details(string slug)
        {
            var post = await repo.GetBySlugAsync(slug);
            if (post == null) return NotFound();

            var dto = mapper.Map<PostDto>(post);
            return View(dto);
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreatePostDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var post = mapper.Map<Post>(dto);

            post.Slug = _slughelper.GenerateSlug(post.Title);

            await repo.AddAsync(post);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var post = await repo.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<UpdatePostDto>(post);
            return View(dto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid id,UpdatePostDto dto)
        {
            if (!ModelState.IsValid) return View(dto);


            var post = mapper.Map<Post>(dto);
            post.Slug = _slughelper.GenerateSlug(post.Title);

            await repo.UpdateAsync(id,post);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
