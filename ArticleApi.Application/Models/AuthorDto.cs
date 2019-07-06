using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArticleApi.Application.Interfaces;
using ArticleApi.Domain.Entities;

namespace ArticleApi.Application.Models
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public ICollection<AuthorArticleDto> Articles { get; set; }
    }

    public static class AuthorDtoExtensions
    {
        public static AuthorDto ConvertToDto(this Author author)
        {
            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                Bio = author.Bio,
                Articles = author.Articles.Select(article=>new AuthorArticleDto{Id = article.Id, Content = article.Content, Name = article.Content}).ToList()
            };
        }
    }
}
