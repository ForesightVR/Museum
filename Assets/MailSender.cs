using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

public class MailSender : MonoBehaviour
{

    private void Start()
    {
        SendEmail();
    }
    public void SendEmail()
    {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("contact@foresightvr.com");
        mail.To.Add("hectorborges94@gmail.com");
        mail.Subject = "Email From Unity";
        mail.Body = "It's working!";
        // you can use others too.
        SmtpClient smtpServer = new SmtpClient("mail.foresightvr.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential("contact@foresightvr.com", "Foresight2020") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
        delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        { return true; };
        smtpServer.Send(mail);
    }
}
