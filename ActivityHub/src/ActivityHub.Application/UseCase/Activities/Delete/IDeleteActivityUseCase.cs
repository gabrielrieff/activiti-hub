namespace ActivityHub.Application.UseCase.Activities.Delete;
public interface IDeleteActivityUseCase
{
    Task Execute(int id);
}
