using ex2.Models;
using ex2.Repositories;
using ex2.Services;
using System.Data;

namespace ex2.Services
{
    public class AttachmentsServices : IAttachmentsService
    {
        private readonly IAttachmentsRepositories _attachmentsRepository;

        public AttachmentsServices(IAttachmentsRepositories attachmentsRepository)
        {
            _attachmentsRepository = attachmentsRepository;
        }
        public DataTable CreateAttachment(string attachmentName, string attachmentPath)
        {
            return _attachmentsRepository.CreateAttachment(attachmentName, attachmentPath);
        }
        public bool CreateAt(AttachmentWithTask model)
        {
            return _attachmentsRepository.ProcessTransaction(model.Attachment, model.Task);
        }
    }
}
