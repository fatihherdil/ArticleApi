using System.Linq;
using ArticleApi.Application.Repository;
using ArticleApi.Application.Response;
using ArticleApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ArticleApi.Application.Models;

namespace ArticleApi.Web.Api.Controllers
{
    [Route("[action]")]
    public class AuthorController : ControllerBase<Author>
    {
        public AuthorController(RepositoryBase<Author> entityRepository) : base(entityRepository)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Authors()
        {
            var authors = await Repository.GetAllAsync();
            return Json(new DefaultResponse(authors.Select(author => author.ConvertToDto())));
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(Author submittedAuthor)
        {
            if (!ModelState.IsValid) return Json(new ErrorResponse(400, "Submitted Author is Not Valid !"));

            var entity = await Repository.AddAsync(submittedAuthor);
            return Json(new DefaultResponse(entity));
        }
    }
}