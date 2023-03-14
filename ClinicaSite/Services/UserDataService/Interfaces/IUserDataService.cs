namespace ClinicaSite.Services.UserDataService.Interfaces
{
    public interface IUserDataService
    {
        Task<Guid> GetLoggedInUserId();
    }
}