using EntityLayer.Concrete;
using MyCVCore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCVCore.BusinessLayer.Abstract
{
    public interface IWriterMessageService : IGenericService<WriterMessage>
    {
        List<WriterMessage> GetListSendMessage(string p);
        List<WriterMessage> GetListReceiverMessage(string p);
    }
}
