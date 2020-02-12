using System;

namespace Email_test
{
    class Program
    {
        static void Main(string[] args)
        {
            var ms = new MailSender();
            ms.SendEmailAsync("michael.polivka@pslib.cz", "Subject", "Mám rád černý párky");
        }
    }
}
