using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArticleApi.Domain.Entities
{
    public class Article : EntityBase<Article>
    {
        public Article()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        public override Article GetNullInstance()
        {
            var nullArticle = new Article
            {
                Content = "Content NULL",
                Name = "Name NULL",
                Id = -1,
                AuthorId = -1,
                Author = new Author
                {
                    Id = -1,
                    Name = "Name NULL",
                    Bio = "Bio NULL",
                    Articles = new HashSet<Article>()
                }
            };

            nullArticle.Author.Articles.Add(new Article
            {
                    Content = "Content NULL",
                    Name = "Name NULL",
                    Id = -1,
                    Author = nullArticle.Author,
                    AuthorId = nullArticle.AuthorId
            });

            return nullArticle;
        }

        [Required]
        [MaxLength(250, ErrorMessage = "Name cannot be longer than 250 characters")]
        public string Name { get; set; }

        public string Content { get; set; }

        //[Required(ErrorMessage = "An Article must have a Author")]
        public int? AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
