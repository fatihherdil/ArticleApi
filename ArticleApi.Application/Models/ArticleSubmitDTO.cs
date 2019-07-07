using System;
using ArticleApi.Application.Interfaces;
using ArticleApi.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using ArticleApi.Application.Exceptions;

namespace ArticleApi.Application.Models
{
    public class ArticleSubmitDto : IDto<Article>
    {
        [Required]
        [MaxLength(250, ErrorMessage = "Name cannot be longer than 250 characters")]
        public string Name { get; set; }

        public string Content { get; set; }

        [Required(ErrorMessage = "An Article must have a Author")]
        public int? AuthorId { get; set; }

        public Article ConvertToBo()
        {
            if(AuthorId == null) throw new InvalidModelException("An Article must have a Author");
            return new Article
            {
                AuthorId = AuthorId.Value,
                Content = Content,
                Name = Name
            };
        }
    }
}
