using System;
using System.Linq;
using System.Net;
using ArticleApi.Application.Repository;
using ArticleApi.Application.Response;
using ArticleApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ArticleApi.Application.Exceptions;
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
            if (!ModelState.IsValid) throw new InvalidModelException("Submitted Author is Not Valid !");

            var entity = await Repository.AddAsync(submittedAuthor);
            return Json(new DefaultResponse(HttpStatusCode.Created, entity.ConvertToDto()));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(Author submittedAuthor)
        {
            if (!ModelState.IsValid) throw new InvalidModelException("Submitted Author is Not Valid !");

            var entity = await Repository.UpdateAsync(submittedAuthor);
            return Json(new DefaultResponse("changed", 204, entity.ConvertToDto()));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAuthor([FromQuery] int? id)
        {
            if (!id.HasValue || id <= 0) throw new IndexOutOfRangeException("Author Id Must be Greater Than 0");

            var entity = await Repository.DeleteByIdAsync(id.Value);

            return Json(new DefaultResponse("deleted", 204, entity.ConvertToDto()));
        }
    }
}