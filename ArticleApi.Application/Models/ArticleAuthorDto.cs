using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ArticleApi.Domain.Interfaces;

namespace ArticleApi.Application.Models
{
    public class ArticleAuthorDto : INullableObject<ArticleAuthorDto>
    {
        public int? Id { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Name cannot be longer than 250 characters")]
        public string Name { get; set; }
        public string Bio { get; set; }
        public ArticleAuthorDto GetNullInstance()
        {
            return new ArticleAuthorDto
            {
                Id = -1,
                Bio = "Bio NULL",
                Name = "Name NULL"
            };
        }
    }
}
