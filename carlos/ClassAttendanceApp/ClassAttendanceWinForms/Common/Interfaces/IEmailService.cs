using System;
using Common.Notifications;

namespace Common.Interfaces
{
    public interface IEmailService
    {
        void Send(Email email);
    }

    public class EmailService : IEmailService
    {
        public void Send(Email email)
        {
            if (email == null)
            {
                throw new ArgumentNullException("email");
            }

            Console.WriteLine($"Sending an email to: {email.To}");
            Console.WriteLine($"\tSubject: {email.Subject}");
            Console.WriteLine($"\tBody: {email.Body}");
        }
    }
}