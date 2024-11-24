﻿using ex2.Models;
using System.Data;

namespace ex2.Repositories
{
    public interface IAttachmentsRepositories
    {
        DataTable CreateAttachment(string attachmentName, string attachmentPath);
        public bool ProcessTransaction(Attachment attachment, Models.Tasks task);


    }
}
