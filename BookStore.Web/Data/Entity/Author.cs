namespace BookStore.Web.Data.Entity
{
    public class Author:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<Book>? Books { get; set; }
    }
}
