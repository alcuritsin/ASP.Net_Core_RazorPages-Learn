using MailKit.Net.Smtp;
using MailKit;
using Microsoft.Extensions.Options;
using MimeKit;

namespace ASP.Net_Core_RazorPages_Learn.Models;

public class MailKitSender : IEmailSender
{
    private readonly ILogger<MailKitSender> _logger;
    private readonly SmtpCredentials _smtpCredentials;

    public MailKitSender(IOptionsSnapshot<SmtpCredentials> options, ILogger<MailKitSender> logger)
    {
        _logger = logger;
        _smtpCredentials = options.Value;
    }

    public async Task SendAsync (string senderName, string title, string body, string recipient,
        CancellationToken cancellationToken)
    {
        
        _logger.LogDebug("Попытка отправить письмо");

        MimeMessage mailMessage = new MimeMessage();
        
        mailMessage.From.Add(new MailboxAddress(senderName, _smtpCredentials.UserName));
        mailMessage.To.Add(new MailboxAddress(senderName, recipient));
        mailMessage.Subject = title;
        mailMessage.Body = new TextPart("sybtype")
        {
            Text = body
        };

        using (var smtpClient = new SmtpClient())
        {
            await smtpClient.ConnectAsync("smtp.gmail.com", 587, true, cancellationToken);
            await smtpClient.AuthenticateAsync("user", "password", cancellationToken);
            await smtpClient.SendAsync(mailMessage, cancellationToken);
            await smtpClient.DisconnectAsync(true, cancellationToken);
        };
        
    }
    public class SmtpCredentials
    {
        public string? UserName { get; set; } = "asds@gmail.com";
        public string? Password { get; set; }
        public string? Host { get; set; }
        public int Port { get; set; }
    }
}