using ArticleApi.Application.Repository;
using ArticleApi.Application.Response;
using ArticleApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            return Json(new DefaultResponse(await Repository.GetAllAsync()));
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