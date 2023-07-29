using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SocietyManagementApi.Helper
{
    public static class NotificationService
    {
        public static void SendCode(string UserName, string Password, string SenderID, string msg, string mobno, string msgtyp, string entityID, string templateID)
        {
            string result = "";
            WebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                string smsurl = "http://piosys.co.in/SendSMS.aspx?UserName=" + UserName + "&Password=" + Password + "&SenderId=" + SenderID + "&Message=" + msg + "&MobileNo=" + mobno.ToString() + "&MsgTyp=" + msgtyp.ToString() + "&EntityId=1701158046859603415&TemplateId=1707162080497255983";
                
                request = WebRequest.Create(smsurl);
                response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                Encoding ec = System.Text.Encoding.GetEncoding("utf-8");
                StreamReader reader = new System.IO.StreamReader(stream, ec);
                result = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            catch (Exception exp)
            {
                result = exp.ToString();
            }
            finally
            {
                if (response != null)
                    response.Close();
            }
        }

        public static void SendMail(string msg, string email)
        {
            MailMessage mymailmsg = new MailMessage();
            SmtpClient Smtp = new SmtpClient();
            
            System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("email2pioneer@gmail.com", "tkxpjvtjmgoudoxr");
            MailAddress myfrom = default(MailAddress);
            myfrom = mymailmsg.From;
            mymailmsg.From = new MailAddress("email2pioneer@gmail.com");
            mymailmsg.To.Add(new MailAddress(email));
            mymailmsg.Subject = "Forgot Password";
            mymailmsg.IsBodyHtml = true;
            mymailmsg.Body = msg;
            Smtp.Host = "smtp.gmail.com";
            Smtp.Port = 587;
            Smtp.EnableSsl = true;
            Smtp.UseDefaultCredentials = false;
            Smtp.Credentials = basicAuthenticationInfo;
            Smtp.Send(mymailmsg);
        }

    }
}
