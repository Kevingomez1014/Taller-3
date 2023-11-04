using handlers.Handlers;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<LibroDTO> BD = new List<LibroDTO>();
LibroHandler libroo = new LibroHandler(BD);

List<AutorDTO> BDD = new List<AutorDTO>();
AutorHandler autorr = new AutorHandler(BDD);

app.MapPost("/api/v1/libro", (LibroDTO libro) => {
    libroo.Create(libro);
});

app.MapPut("/api/v1/libro/{id:guid}", (Guid id, LibroDTO libro) => {
    libroo.Update(libro, id);
});

app.MapGet("/api/v1/libro", () => {
    return Results.Ok(libroo.All());
});

app.MapDelete("/api/v1/libro/{id:guid}", (Guid id) => {
    libroo.Delete(id);
});

app.MapPost("/api/v1/autor", (AutorDTO autor) => {
    autorr.Create(autor);
});

app.MapPut("/api/v1/autor/{id:guid}", (Guid id, AutorDTO autor) => {
    autorr.Update(autor, id);
});

app.MapGet("/api/v1/autor", () => {
    return Results.Ok(autorr.All());
});

app.MapDelete("/api/v1/autor/{id:guid}", (Guid id) => {
    autorr.Delete(id);
});

app.Run();