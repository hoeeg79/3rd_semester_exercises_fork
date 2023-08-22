namespace gettingstarted.week34.prg_1_Dapper;

public class Book
{
    public int BookId { get; set; }
    public string? Title { get; set; }
    public string? Publisher { get; set; }
    public string? CoverImgUrl { get; set; }
}

public class EndUser
{
    public string? Email { get; set; }
    public string? Status { get; set; }
    public string? Role { get; set; }
    public int EndUserId { get; set; }
    public string? PasswordHash { get; set; }
    public string? Salt { get; set; }
    public int ProfileImgUrl { get; set; }
}

public class BookWithAuthors
{
    public int BookId { get; set; }
    public string? Title { get; set; }
    public IEnumerable<string> Authors { get; set; }
}

public class Author
{
    public string Name { get; set; }
    public string Nationality { get; set; }
    public int AuthorId { get; set; }
    public DateTime Birthday { get; set; }
}

public class FullBookDetails
{
    public int BookId { get; set; }
    public string? Title { get; set; }
    public IEnumerable<string> Authors { get; set; }
    public string? Publisher { get; set; }
    public string? CoverImgUrl { get; set; }
}