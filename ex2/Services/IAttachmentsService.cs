using ex2.Models;
using System.Data;
using System.Net.Mail;

namespace ex2.Services
{
    public interface IAttachmentsService
    {
        DataTable CreateAttachment(string attachmentName, string attachmentPath);
        bool CreateAt(AttachmentWithTask model);

    }

}
