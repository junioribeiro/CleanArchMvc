namespace CleanArchMvc.Domain.Account
{
    public interface ISeedUserRoleInitial
    {
        Task SeedUsers();
        Task SeedRoles();
    }
}
