//Minimal API Back - End(ServerApp.cs):

using ServerApp.DTO;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

//don’t use AllowAnyOrigin in production) copilot suggests using specific origins for security reasons, but for development purposes, we can allow any origin to avoid CORS issues when testing with a frontend application running on a different port.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

//copilot suggests configuring JSON options to use camelCase naming, which is a common convention in JavaScript and can help ensure that the JSON data sent to the frontend is easily consumable without needing additional transformations.
builder.Services.ConfigureHttpJsonOptions(options => 
{ 
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; 
});

var app = builder.Build();

app.UseCors();


//coplist suggests making it async to improve performance and scalability, especially if the product data is retrieved from a database or an external service. This allows the server to handle other requests while waiting for the product data to be fetched, enhancing the overall responsiveness of the API.
app.MapGet("/api/productlist", async () =>
{
    var products = new[]
    {
        new ProductDto
        {
            Id = 1,
            Name = "Laptop",
            Price = 1200.50,
            Stock = 25,
            Category = new CategoryDto { Id = 101, Name = "Electronics" }
        },
        new ProductDto
        {
            Id = 2,
            Name = "Headphones",
            Price = 50.00,
            Stock = 100,
            Category = new CategoryDto { Id = 102, Name = "Accessories" }
        }
    };
    //colpit suggests returning the products using Results.Ok() to ensure that the response is properly formatted as a JSON object with a 200 OK status code, which is a standard practice for API responses.
    return Results.Ok(products);
});

app.Run();