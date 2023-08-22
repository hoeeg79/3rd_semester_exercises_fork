using System.Security.Cryptography.X509Certificates;
using Dapper;
using FluentAssertions;
using NUnit.Framework;

namespace gettingstarted.week34.prg_1_Dapper.Exercises;

[TestFixture]
public class CountBooksByAuthor
{
    public int CountBookByAuthor(int authorId)
    {
        var sql = "SELECT Count(*) FROM library.author_wrote_book_items " +
                  "WHERE author_id = @authorId;";

        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.ExecuteScalar<int>(sql, new { authorId });
        }
    }

    [Test]
    public void CountBooksByAuthorTest()
    {
        // Arrange
        Helper.TriggerRebuild();

        var book = Helper.MakeRandomBookWithId(1);
        var book2 = Helper.MakeRandomBookWithId(2);
        var book3 = Helper.MakeRandomBookWithId(3);
        var author = Helper.MakeRandomAuthorWithId(1);
        var author2 = Helper.MakeRandomAuthorWithId(2);

        var sqlBook =
            "INSERT INTO library.books (title, publisher, cover_img_url) VALUES (@title, @publisher, @coverImgUrl);";
        var sqlAuthor =
            "INSERT INTO library.authors (name, birthday, nationality) VALUES (@name, @birthday, @nationality);";
        var sqlAuthorBook =
            "INSERT INTO library.author_wrote_book_items (book_id, author_id) VALUES (@bookId, @authorId);";

        using (var conn = Helper.DataSource.OpenConnection())
        {
            conn.Execute(sqlBook, book);
            conn.Execute(sqlBook, book2);
            conn.Execute(sqlBook, book3);
            conn.Execute(sqlAuthor, author);
            conn.Execute(sqlAuthor, author2);
            conn.Execute(sqlAuthorBook, new { book.BookId, author.AuthorId });
            conn.Execute(sqlAuthorBook, new { book2.BookId, author2.AuthorId });
            conn.Execute(sqlAuthorBook, new { book3.BookId, author.AuthorId });
        }

        // Act
        var actual = CountBookByAuthor(author.AuthorId);

        // Assert
        using (var conn = Helper.DataSource.OpenConnection())
        {
            var result =
                conn.ExecuteScalar<int>("SELECT count(*) FROM library.author_wrote_book_items WHERE author_id = @authorId", new {author.AuthorId});
            (result == actual).Should().Be(true);
        }
    }
}