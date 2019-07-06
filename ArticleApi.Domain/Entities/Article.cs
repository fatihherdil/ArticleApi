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
            return new Article
            {
                Content = "Content NULL",
                Name = "Name NULL",
                Id = -1,
                Author = new Author().GetNullInstance()
            };
        }

        [Required]
        [MaxLength(250, ErrorMessage = "Name cannot be longer than 250 characters")]
        public string Name { get; set; }

        public string Content { get; set; }

        [Required(ErrorMessage = "An Article must have a Author")]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
