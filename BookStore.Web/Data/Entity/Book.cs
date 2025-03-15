namespace BookStore.Web.Data.Entity
{
    public class Book:BaseEntity
    {
        public string Title { get; set; }
        public DateOnly ReleaseBook { get; set; }
        public int AuthorId { get; set; }
        public virtual Author? Author { get; set; }
        //public virtual List<Genre>? Genres { get; set; }
        public ICollection<BookGenre> BookGenres { get; set; }=new List<BookGenre>();

    }
}
