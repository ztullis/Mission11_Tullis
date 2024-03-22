namespace Mission11_Tullis.Models
{
    public interface IBookRepository
    {
        public IQueryable<Book> Books { get; }
    }
}
