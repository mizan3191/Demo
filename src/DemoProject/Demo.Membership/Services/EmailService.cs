using MailKit.Net.Smtp;
using MimeKit;

namespace Demo.Membership.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _host;
        private readonly int _port;
        private readonly string _username;
        private readonly string _password;
        private readonly string _from;
        private readonly bool _useSSL;

        public EmailService(string host , int port, string username, string password, string from, bool useSSL)
        {
            _host = host;
            _port = port;
            _username = username;
            _password = password;
            _from = from;
            _useSSL = useSSL;
        }
        public void SendEmail(string receiver, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_from, _from));
            message.To.Add(new MailboxAddress(receiver, receiver));
            message.Subject = subject;
            message.Body = new TextPart("html")
            {
                Text = body,
            };

            using var client = new SmtpClient();
            client.Timeout = 60000;
            client.Connect(_host, _port, _useSSL);
            client.Authenticate(_username, _password);
            client.Send(message);
            client.Disconnect(true);
        }
    }
}