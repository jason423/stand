using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PublicClass
{
  public class SendEmail
    {
      /// <summary>
      /// 发送邮件
      /// </summary>
      /// <param name="emailaddress">目标邮箱地址</param>
      /// <param name="subject">邮件标题</param>
      /// <param name="body">邮件内容</param>
        public  static bool Send(string emailaddress,string subject,string body)
      {
          try
          {
              Regex regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
              if (!regex.IsMatch(emailaddress.Trim()))
              {
                  MessageBox.Show("请输入正确的Email", "Email错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  return false;
              }
              MailMessage mail = new MailMessage();
              mail.Subject = subject;  //标题                     
              string from = "standdownload@163.com";
              string pwd = "tsc123456";
              mail.Body = body;  //内容
              mail.From = new MailAddress(from);
              string[] mailNames = (emailaddress + ";").Split(';');
              foreach (string name in mailNames)
              {
                  if (name != string.Empty)
                  {
                      mail.To.Add(new MailAddress(name));
                  }
              }
              
              SmtpClient smtpClient = new SmtpClient();
              smtpClient.UseDefaultCredentials = true;
              smtpClient.Credentials = new System.Net.NetworkCredential(from, pwd);
              smtpClient.Host = "smtp.163.com"; //主机    
              smtpClient.Send(mail);
              return true;
          }
            catch(Exception ex)
          {
              MessageBox.Show(ex.Message);
              return false;
          }
      }
    }
}
