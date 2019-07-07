using System;
using System.Data;
using System.Linq;
using System.Net;
using ArticleApi.Application.Models;
using ArticleApi.Application.Repository;
using ArticleApi.Application.Response;
using ArticleApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ArticleApi.Application.Exceptions;

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
            if (!ModelState.IsValid) throw new InvalidModelException("Submitted Article is Not Valid !");

            var entity = await Repository.AddAsync(submittedArticle.ConvertToBo());
            return Json(new DefaultResponse(HttpStatusCode.Created, entity.ConvertToDto()));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateArticle(ArticleSubmitDto submittedArticle)
        {
            if (!ModelState.IsValid) throw new InvalidModelException("Submitted Article is Not Valid !");

            var entity = await Repository.UpdateAsync(submittedArticle.ConvertToBo());
            return Json(new DefaultResponse("changed", 204, entity.ConvertToDto()));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteArticle([FromQuery] int? id)
        {
            if (!id.HasValue || id <= 0) throw new IndexOutOfRangeException("Article Id Must be Greater Than 0");

            var entity = await Repository.DeleteByIdAsync(id.Value);

            return Json(new DefaultResponse("deleted", 204, entity.ConvertToDto()));
        }
    }
}