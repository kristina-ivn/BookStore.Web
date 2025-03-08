namespace BookStore.Web.Data.Entity
{
    public class Book:BaseEntity
    {
        public string Title { get; set; }
        public DateOnly ReleaseBook { get; set; }
        public int IdAuthor { get; set; }

    }
}
