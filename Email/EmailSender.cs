using Space.Language;
using Space.Models;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Space.Email;

public class EmailSender
{
    const string smtpServer = "smtp.office365.com";
    const int smtpPort = 587;

    public static void SendEmail(Spaceport spaceport, string filePath)
    {
        while (true)
        {
            Console.WriteLine($"\n{LangHelper.GetString("EnterEmail")}");
            string? senderEmail = Console.ReadLine();

            Console.WriteLine($"\n{LangHelper.GetString("EnterPassword")}");
            string senderPassword = ReadPassword();

            Console.WriteLine($"\n{LangHelper.GetString("EnterReceiverEmail")}");
            string? receiverEmail = Console.ReadLine();

            if (!string.IsNullOrEmpty(senderEmail) &&
                !string.IsNullOrEmpty(senderPassword) &&
                !string.IsNullOrEmpty(receiverEmail))
            {
                bool success = SendSMTPEmail(senderEmail, senderPassword, receiverEmail, spaceport, filePath);
                if (success)
                    break;
            }
            else
                Console.WriteLine($"\n{LangHelper.GetString("MissingInput")}");
        }
    }

    static bool SendSMTPEmail(string senderEmail, string senderPassword, string receiverEmail, Spaceport spaceport, string filePath)
    {
        try
        {
            using SmtpClient client = new(smtpServer, smtpPort)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(senderEmail, senderPassword)
            };

            MailMessage message = new(senderEmail, receiverEmail)
            {
                Subject = $"{LangHelper.GetString("EmailSubject")}",
                Body = string.Format($"{LangHelper.GetString("EmailBody")}", spaceport.Location, spaceport.LaunchBestDate)
            };

            Attachment attachment = new(filePath);
            message.Attachments.Add(attachment);

            client.Send(message);
            Console.WriteLine($"\n{LangHelper.GetString("EmailSent")}");

            return true;
        }
        catch
        {
            Console.WriteLine($"\n{LangHelper.GetString("EmailNotSent")}");
        }
        return false;
    }

    static string ReadPassword()
    {
        StringBuilder sb = new();
        ConsoleKeyInfo keyInfo;

        do
        {
            keyInfo = Console.ReadKey(true);

            if (keyInfo.Key is not ConsoleKey.Enter
                            and not ConsoleKey.Backspace)
            {
                sb.Append(keyInfo.KeyChar);
                Console.Write('*');
            }
            else if (keyInfo.Key is ConsoleKey.Backspace && sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
                Console.Write("\b \b");
            }
        }
        while (keyInfo.Key is not ConsoleKey.Enter);


        return sb.ToString();
    }
}
