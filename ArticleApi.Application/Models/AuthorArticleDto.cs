using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ArticleApi.Domain.Interfaces;

namespace ArticleApi.Application.Models
{
    public class AuthorArticleDto : INullableObject<AuthorArticleDto>
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Name cannot be longer than 250 characters")]
        public string Name { get; set; }
        public string Content { get; set; }
        public AuthorArticleDto GetNullInstance()
        {
            return new AuthorArticleDto
            {
                Name = "Name NULL",
                Content = "Content NULL",
                Id = -1
            };
        }
    }
}
