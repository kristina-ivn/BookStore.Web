using System.Reflection.Metadata.Ecma335;

namespace BookStore.Web.Data.Entity
{
    public class Genre:BaseEntity
    {
        public string Name { get; set; }
        public virtual List<Book>? Books { get; set; }
    }
}
