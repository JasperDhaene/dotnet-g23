namespace dotnet_g23.Models.Domain.Repositories
{
    public interface IUserRepository
    {
        GUser GetByEmail(string userEmail);
        void SaveChanges();
    }
}