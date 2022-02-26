namespace Demo.Membership.Services
{
    public interface IEmailService
    {
        void SendEmail(string receiver, string subject, string body);
    }
}