using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccese.MailServices
{
    class SystemSuportMail:MasterMailServer
    {
        public SystemSuportMail()
        {
            senderMail = "alguien_2350@hotmail.com";
            password = "FamiliaBa3";
            host = "smtp.live.com";
            //host = "smtp.gmail.com";
            port = 587;
            ssl = true;
            initializeSmtpClient();
        }
    }
}
