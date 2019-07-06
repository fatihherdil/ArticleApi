using System.Linq;
using ArticleApi.Application.Models;
using ArticleApi.Application.Repository;
using ArticleApi.Application.Response;
using ArticleApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArticleApi.Web.Api.Controllers
{
    [Route("[action]")]
    public class ArticleController : ControllerBase<Article>
    {
        public ArticleController(RepositoryBase<Article> entityRepository) : base(entityRepository)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Articles()
        {
            var articles = await Repository.GetAllAsync();
            return Json(new DefaultResponse(articles.Select(article => article.ConvertToDto())));
        }

        [HttpPost]
        public async Task<IActionResult> AddArticle(ArticleSubmitDto submittedArticle)
        {
            if (!ModelState.IsValid) return Json(new ErrorResponse(400, "Submitted Article is Not Valid !"));

            var entity = await Repository.AddAsync(submittedArticle.ConvertToBo());
            return Json(new DefaultResponse(entity));
        }
    }
}