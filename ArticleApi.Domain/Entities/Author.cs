using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArticleApi.Domain.Entities
{
    public class Author : EntityBase<Author>
    {
        public Author()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        public override Author GetNullInstance()
        {
            var nullAuthor = new Author
            {
                Bio = "Bio NULL",
                Name = "Name NULL",
                Id = -1,
                Articles = new HashSet<Article>()
            };

            nullAuthor.Articles.Add(new Article
            {
                Content = "Content NULL",
                Name = "Name NULL",
                Id = -1,
                Author = nullAuthor,
                AuthorId = nullAuthor.Id
            });

            return nullAuthor;
        }

        [Required]
        [MaxLength(250, ErrorMessage = "Name cannot be longer than 250 characters")]
        public string Name { get; set; }

        public string Bio { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
