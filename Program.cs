var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure CORS (allow any origin)
var corsPolicyName = "_frontend_policy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName, p =>
        p.AllowAnyOrigin()
         .AllowAnyHeader()
         .AllowAnyMethod()
    );
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable CORS (must be before MapControllers / endpoints)
app.UseCors(corsPolicyName);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGet("/healthz", () => Results.Ok("healthy"));

app.Run();
