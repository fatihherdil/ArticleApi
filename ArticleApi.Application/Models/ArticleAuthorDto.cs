using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArticleApi.Application.Models
{
    public class ArticleAuthorDto
    {
        public int? Id { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Name cannot be longer than 250 characters")]
        public string Name { get; set; }
        public string Bio { get; set; }
    }
}
