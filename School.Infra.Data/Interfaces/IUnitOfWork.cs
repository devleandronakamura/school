namespace School.Infra.Data.Interfaces;
public interface IUnitOfWork
{
    //IProfessorRepository ProfessorRepository { get; }
    //ICategoriaRepository CategoriaRepository { get; }
    Task CommitAsync();
}