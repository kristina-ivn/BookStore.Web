using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Web.Data.Entity
{
    public class BookGenre 
    {

        [ForeignKey(nameof(Book))]
        public int IdBook { get; set; }
        public virtual Book? Book { get; set; }
        [ForeignKey(nameof(Genre))]
        public int IdGenre { get; set; }
        public virtual Genre? Genre { get; set; }
    }
}
