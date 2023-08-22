using Dapper;
using FluentAssertions;
using NUnit.Framework;

namespace gettingstarted.week34.prg_1_Dapper.Exercises;

[TestFixture]
public class MyOwnTest
{
    public bool AddAuthorToBook(int bookId, int authorId)
    {
        var sql = $@"INSERT INTO library.author_wrote_book_items (book_id, author_id) VALUES ({bookId}, {authorId})";

        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.Execute(sql) == 1;
        }
    }


    [Test]
    public void AddAuthorToBookTest()
    {
        
        //Arrange
        Helper.TriggerRebuild();
        var book = Helper.MakeRandomBookWithId(1);
        var author1 = Helper.MakeRandomAuthorWithId(1);
        var author2 = Helper.MakeRandomAuthorWithId(2);

        var sqlBook = "INSERT INTO library.books (title, publisher, cover_img_url) VALUES (@title, @publisher, @coverImgUrl);";
        var sqlAuthor = "INSERT INTO library.authors (name, birthday, nationality) VALUES (@name, @birthday, @nationality);";
        var sqlAuthorBook = "INSERT INTO library.author_wrote_book_items (book_id, author_id) VALUES (@bookId, @authorId);";

        using (var conn = Helper.DataSource.OpenConnection())
        {
            conn.Execute(sqlBook, book);
            conn.Execute(sqlAuthor, author1);
            conn.Execute(sqlAuthor, author2);
            conn.Execute(sqlAuthorBook, new { book.BookId, author1.AuthorId });
        }
        
        //Act
        bool actual;

        actual = AddAuthorToBook(book.BookId, author2.AuthorId);

        // Assert
        using (var conn = Helper.DataSource.OpenConnection())
        {
            var result = conn.ExecuteScalar<int>(
                "SELECT count(*) FROM library.author_wrote_book_items WHERE book_id = @bookId",
                new { book.BookId }) == 2;
            (actual && result).Should().Be(true);
        }
    }
}