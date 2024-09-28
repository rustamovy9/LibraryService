namespace Infrustructure.Models;

public class SqlCommand
{
    public const string connectionString = "Host=localhost;Port=5432;Database=library_db;User Id=postgres;Password=123456;";
    public const string createBook = @"insert into books (title, description, isbn, publisheddate, authorid, categoryid, createdat) values (@title, @description, @isbn, @publisheddate, @authorid, @categoryid, @createdat);";
    public const string getBookById = @"select * from books where id = @id;";
    public const string getAllBooks = @"select * from books;";
    public const string updateBook = @"update books set title = @title, description = @description, isbn = @isbn, publisheddate = @publisheddate, authorid = @authorid, categoryid = @categoryid, createdat = @createdat where id = @id;";
    public const string deleteBook = @"delete from books where id = @id;";
    
    public const string createUser = @"insert into users (username, email, passwordhash, createdat) values (@username, @email, @passwordhash, @createdat);";
    public const string getUserById = @"select * from users where id = @id;";
    public const string getAllUsers = @"select * from users;";
    public const string updateUser = @"update users set username = @username, email = @email, passwordhash = @passwordhash, createdat = @createdat where id = @id;";
    public const string deleteUser = @"delete from users where id = @id;";
    
    public const string createCategory = "INSERT INTO Categories (name, CreatedAt) VALUES (@Name, @CreatedAt)";
    public const string getCategoryById = "SELECT * FROM Categories WHERE Id = @Id";
    public const string getAllCategories = "SELECT * FROM Categories";
    public const string updateCategory = "UPDATE Categories SET Name = @Name, CreatedAt = @CreatedAt WHERE Id = @Id";
    public const string deleteCategory = "DELETE FROM Categories WHERE Id = @Id";
    
    public const string createBookRental = @"insert into bookrentals (bookid, userid, rentaldate, returndate, createdat) values (@bookid, @userid, @rentaldate, @returndate, @createdat);";
    public const string getBookRentalById = @"select * from bookrentals where id = @id;";
    public const string getAllBookRentals = @"select * from bookrentals;";
    public const string updateBookRental = @"update bookrentals set bookid = @bookid, userid = @userid, rentaldate = @rentaldate, returndate = @returndate, createdat = @createdat where id = @id;";
    public const string deleteBookRental = @"delete from bookrentals where id = @id;";
    
    public const string createAuhtor = @"insert into authors (firstname, lastname, dateofbirth, biography, createdat)values (@firstname, @lastname, @dateofbirth, @biography, @createdat);";
    public const string getAuthorById = @"select * from authors where id = @id;";
    public const string getAllAuthors = @"select * from authors;";
    public const string updateAuthor = @"update authors set firstname = @firstname, lastname = @lastname, dateofbirth = @dateofbirth, biography = @biography, createdat = @createdat where id = @id;";
    public const string deleteAuthor = @"delete from authors where id = @id;";
    
    public const string getBookByFiltrDate = @"select * from books 
                              where Extract(Year from @publisheddate) >= Extract(Year from current_date) - 5;";
    
    public const string getBookAutohorAndCategory = @"select b.id, b.title, a.firstName || ' ' || a.lastName as authorName,a.dateOfBirth as authorDateOfBirth,a.biography, c.name as categoryName from books b 
                                join authors a on a.id = b.authorId
                                join categories c on c.id = b.categoryId
                               ";
    
    public const string getBookByAuthor = @"select * from books b 
                                join authors a on a.id = b.authorId
                                where a.id = @authorId;";
    
    public const string getBookRentalsByUserId = @"select br.id, b.id as bookId, b.title, br.RentalDate, br.ReturnDate, br.CreatedAt from bookrentals br
                               join books b on b.id = br.bookId
                               where br.userid = @userId";

}