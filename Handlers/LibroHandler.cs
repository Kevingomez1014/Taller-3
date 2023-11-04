namespace handlers.Handlers;

public class LibroHandler
{
    private List<LibroDTO> _libros;

    public LibroHandler(List<LibroDTO> libros)
    {
        this._libros = libros;
    }

    public List<LibroDTO> All()
    {
        return this._libros;
    }

    public void Create(LibroDTO libro)
    {
        this._libros.Add(libro);
    }

    public void Update(LibroDTO libro, Guid id)
    {
        var libroExistente = this._libros.FirstOrDefault(l => l.Id == id);

        foreach (LibroDTO dto in this._libros)
    {
       if (dto.Id == id){
        dto.Título = libro.Título;
        break;
       }else if(libroExistente != null)
        {
            libroExistente.AutorId = libro.AutorId;
        break;
       }
    }
    }

    public void Delete(Guid id)
    {
        var libroAEliminar = this._libros.FirstOrDefault(l => l.Id == id);

        if (libroAEliminar != null)
        {
            this._libros.Remove(libroAEliminar);
        }
    }
}

public class AutorHandler
{
    private List<AutorDTO> _autores;

    public AutorHandler(List<AutorDTO> autores)
    {
        this._autores = autores;
    }

    public List<AutorDTO> All()
    {
        return this._autores;
    }

    public void Create(AutorDTO autor)
    {
        this._autores.Add(autor);
    }

    public void Update(AutorDTO autor, Guid id)
    {
        var autorExistente = this._autores.FirstOrDefault(a => a.Id == id);

        if (autorExistente != null)
        {
            autorExistente.Nombre = autor.Nombre;
            autorExistente.Apellido = autor.Apellido;
        }
    }

    public void Delete(Guid id)
    {
        var autorAEliminar = this._autores.FirstOrDefault(a => a.Id == id);

        if (autorAEliminar != null)
        {
            this._autores.Remove(autorAEliminar);
        }
    }
}

public class AutorDTO
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
}

public class LibroDTO
{
    public Guid Id { get; set; }
    public string Título { get; set; }
    public Guid AutorId { get; set; }
}