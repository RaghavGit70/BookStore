namespace BookWebApp.Service
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}