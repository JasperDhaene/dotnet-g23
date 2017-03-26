namespace dotnet_g23.Models.Domain.Repositories
{
    public interface ILabelRepository
    {
        Label GetByGroup(int id);
    }
}