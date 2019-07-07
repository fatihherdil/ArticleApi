using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using ArticleApi.Application.Interfaces;
using ArticleApi.Domain.Entities;
using ArticleApi.Domain.Interfaces;

namespace ArticleApi.Application.Models
{
    public class AuthorDto : INullableObject<AuthorDto>
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Name cannot be longer than 250 characters")]
        public string Name { get; set; }
        public string Bio { get; set; }
        public ICollection<AuthorArticleDto> Articles { get; set; }
        public AuthorDto GetNullInstance()
        {
            return new AuthorDto
            {
                Id = -1,
                Name = "NULL",
                Bio = "NULL",
                Articles = new List<AuthorArticleDto>
                {
                    new AuthorArticleDto
                    {
                        Id = -1,
                        Name = "NULL",
                        Content = "NULL"
                    }
                }
            };
        }
    }

    public static class AuthorDtoExtensions
    {
        public static AuthorDto ConvertToDto(this Author author)
        {
            if(author == null) return new AuthorDto().GetNullInstance();
            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                Bio = author.Bio,
                Articles = author.Articles?.Select(article => new AuthorArticleDto { Id = article.Id, Content = article.Content, Name = article.Content }).ToList()
            };
        }
    }
}
