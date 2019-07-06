using System;
using System.Collections.Generic;
using System.Text;
using ArticleApi.Domain.Entities;

namespace ArticleApi.Application.Models
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public ArticleAuthorDto Author { get; set; }
    }

    public static class ArticleDtoExtensions
    {
        public static ArticleDto ConvertToDto(this Article article)
        {
            return new ArticleDto
            {
                Id = article.Id,
                Name = article.Name,
                Content = article.Content,
                Author = new ArticleAuthorDto
                {
                    Id = article.AuthorId,
                    Name = article.Author.Name,
                    Bio = article.Author.Bio
                }
            };
        }
    }
}
