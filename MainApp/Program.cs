using Infrustructure.Models;
using Infrustructure.Services;
using Infrustructure.Services.AuthorService;
using Infrustructure.Services.BookRentalsService;
using Infrustructure.Services.CategoryService;
using Infrustructure.Services.UserService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IBookService,BookService>();
builder.Services.AddScoped<IBookRentalsService,BookRentalsService>();
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IAuthorService,AuthorService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Books
app.MapPost("api/book",async (IBookService bookService, Books books)=>
{
    return await bookService.CreateBookAsync(books);
});

app.MapGet("api/books", async (IBookService bookService) =>
{
    return await bookService.GetAllBooksAsync();
});

app.MapGet("api/books/{id}", async (IBookService bookService, Guid id) =>
{
    return await bookService.GetBookByIdAsync(id);
});

app.MapPut("api/book",async (IBookService bookService, Books books)=>
{
    return await bookService.UpdateBookAsync(books);
});

app.MapDelete("api/book/{id}",async (IBookService bookService, Guid id)=>
{
    return await bookService.DeleteBookAsync(id);
});

app.MapGet("api/book-author-and-category", async (IBookService bookService) =>
{
    return await bookService.GetBookAuthorAndCategoryAsync() ;
});

app.MapGet("api/book/by/{authorId}", async (IBookService bookService, Guid authorId) =>
{
    return await bookService.GetBooksByAuthorAsync(authorId);
});

#endregion

#region Authors

app.MapPost("api/author",async (IAuthorService authorService, Authors authors)=>
{
    return await authorService.CreateAuthorAsync(authors);
});

app.MapPut("api/author",async (IAuthorService authorService, Authors authors)=>
{
    return await authorService.UpdateAuthorAsync(authors);
});

app.MapDelete("api/author/{id}",async (IAuthorService authorService, Guid id)=>
{
    return await authorService.DeleteAuthorAsync(id);
});

app.MapGet("api/authors", async (IAuthorService authorService) =>
{
    return await authorService.GetAuthors();
});
app.MapGet("api/author/{id}", async (IAuthorService authorService, Guid id) =>
{
    return await authorService.GetAuthorByIdAsync(id);
});

#endregion


#region Rentals

app.MapPost("api/rental",async (IBookRentalsService bookRentalsService, BookRentals bookRentals)=>
{
    return await bookRentalsService.CreateBookRentalsAsync(bookRentals);
});

app.MapPut("api/rental",async (IBookRentalsService bookRentalsService, BookRentals bookRentals)=>
{
    return await bookRentalsService.UpdateBookRentalsAsync(bookRentals);
});

app.MapDelete("api/rental/{id}",async (IBookRentalsService bookRentalsService, Guid id)=>
{
    return await bookRentalsService.DeleteBookRentalsAsync(id);
});

app.MapGet("api/rental/{id}", async (IBookRentalsService bookRentalsService, Guid id) =>
{
    return await bookRentalsService.GetBookRentalsByIdAsync(id);
});

app.MapGet("api/rentals", async (IBookRentalsService bookRentalsService) =>
{
    return await bookRentalsService.GetBookRentalsAsync();
});

app.MapGet("api/rentals/{userId}", async (IBookRentalsService bookRentalsService, Guid userId) =>
{
    return await bookRentalsService.GetBookRentalsByUserIdAsync(userId);
});

#endregion

#region Categories

app.MapPost("api/categories", async (ICategoryService categoryService, Categories categories) =>
{
    return await categoryService.CreateCategoryAsync(categories);
});

app.MapPut("api/categories",async (ICategoryService categoryService, Categories categories) =>
{
    return await categoryService.UpdateCategoryAsync(categories);
});

app.MapDelete("api/categories/{id}",async (ICategoryService categoryService, Guid id)=>
{
    return await categoryService.DeleteCategoryAsync(id);
});

app.MapGet("api/categories", async (ICategoryService categoryService) =>
{
    return await categoryService.GetAllCategoriesAsync();
});

app.MapGet("api/category/{id}", async (ICategoryService categoryService, Guid id) =>
{
    return await categoryService.GetCategoryByIdAsync(id);
});

#endregion

#region Users

app.MapPost("api/user",async (IUserService userService,Users users)=>
{
    return await userService.CreateUserAsync(users);
});

app.MapDelete("api/user/{id}",async (IUserService userService, Guid id)=>
{
    return await userService.DeleteUserAsync(id);
});

app.MapPut("api/user",async (IUserService userService, Users users)=>
{
    return await userService.UpdateUserAsync(users);
});

app.MapGet("api/users", async (IUserService userService) =>
{
    return await userService.GetUsersAsync();
});
app.MapGet("api/users/{id}", async (IUserService userService, Guid id) =>
{
    return await userService.GetUserByIdAsync(id);
});

#endregion






app.Run();
