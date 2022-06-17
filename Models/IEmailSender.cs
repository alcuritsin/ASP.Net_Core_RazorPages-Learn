namespace ASP.Net_Core_RazorPages_Learn.Models;

public interface IEmailSender
{
    Task SendAsync(
        string senderName,
        string title,
        string body,
        string recipient,
        CancellationToken cancellationToken);
}