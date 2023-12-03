using System.Net;
using System.Net.Mail;

public class EmailSender
{
    public static void Posalji(string to, string messageSubject, string messageBody, bool isBodyHTML)
    {
        if (to == "")
            return;

        string sendMailFrom = "ajdin.kuduzovic@gmail.com";
        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com", 587);
        smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
        MailMessage email = new MailMessage();
        //start
        email.From = new MailAddress(sendMailFrom);
        email.To.Add(to);
        email.CC.Add(sendMailFrom);
        email.Subject = messageSubject;
        email.Body = messageBody;
        email.IsBodyHtml = isBodyHTML;
        //end
        smtpServer.Timeout = 5000;
        smtpServer.EnableSsl = true;
        smtpServer.UseDefaultCredentials = false;
        smtpServer.Credentials = new NetworkCredential(sendMailFrom, "ptwozcemfbolsnmq");
        smtpServer.Send(email);

    }
}