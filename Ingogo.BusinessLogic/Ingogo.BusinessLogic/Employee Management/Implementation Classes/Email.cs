using System.Text;
using System.Web.Helpers;

namespace Ingogo.BusinessLogic.Employee_Management.Implementation_Classes
{
    public class Email
    {
        public void SendEmail(string email, string message, string subject)
        {
            var boddy = new StringBuilder();

            boddy.Append(message);
            string bodyFor = boddy.ToString();
            string subjectFor = subject;

            string toFor = email;

            WebMail.SmtpServer = "pod51014.outlook.com";
            WebMail.SmtpPort = 587;
            WebMail.UserName = "21217040@dut4life.ac.za";
            WebMail.Password = "Dut921208";
            WebMail.From = "ingogofarm@outlook.com";
            WebMail.EnableSsl = true;

            try { WebMail.Send(toFor, subjectFor, bodyFor); }
            catch
            {
                // ignored
            }
        }
    }
}
