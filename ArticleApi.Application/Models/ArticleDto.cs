using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ArticleApi.Domain.Entities;
using ArticleApi.Domain.Interfaces;

namespace ArticleApi.Application.Models
{
    public class ArticleDto: INullableObject<ArticleDto>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "Name cannot be longer than 250 characters")]
        public string Name { get; set; }
        public string Content { get; set; }
        public ArticleAuthorDto Author { get; set; }
        public ArticleDto GetNullInstance()
        {
            return new ArticleDto
            {
                Id = -1,
                Name = "NULL",
                Content = "NULL",
                Author = new ArticleAuthorDto
                {
                    Id = -1,
                    Name = "NULL",
                    Bio = "NULL"
                }
            };
        }
    }

    public static class ArticleDtoExtensions
    {
        public static ArticleDto ConvertToDto(this Article article)
        {
            if(article == null) return new ArticleDto().GetNullInstance();
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
