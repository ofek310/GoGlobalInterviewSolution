using ApiGitHubInterview.Models;
using ApiSolutionInterview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ApiGitHubInterview.Controllers
{
    public class GitHubRepositoryController : ApiController
    {
        public HttpClient ApiClient { get; set; } = new HttpClient();
        public GitHubRepositoryController()
        {
            ApiClient.DefaultRequestHeaders.Add("User-Agent", "ApiSolutionInterview");
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // Set the Authorization header with your GitHub token
            ApiClient.DefaultRequestHeaders.Add("Authorization", "Bearer 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"); // Replace "YOUR_ACCESS_TOKEN" with your token.
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetGitHubRepository([FromUri] string user_keyword)
        {
            Root result = null;
            string url = $"https://api.github.com/search/repositories?q=" + user_keyword;
            try
            {

                using (HttpResponseMessage response = await ApiClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsAsync<Root>();
                    }
                    else
                    {
                        string message = "the request does not exsists";
                        return Content(HttpStatusCode.NotFound, message);
                    }
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }
            return Ok(result);
        }
        [Route("SendEmail")]
        [HttpPost]
        public async Task<IHttpActionResult> SendEmailRequest([FromBody] Send_Information information)
        {
            MailMessage mailMessage=null;
            try
            {
                mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("interviewgithub1@gmail.com", "GitHub Interview");
                mailMessage.To.Add(information.email);
                mailMessage.Subject = "Repository Information";
                mailMessage.Body = "full name: "+information.item_repo.full_name + "\n"+"owner id: "+information.item_repo.owner.id+"\n"+
                    "avatar url: "+information.item_repo.owner.avatar_url;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("interviewgithub1@gmail.com", "vzxa pmaa myrz vyao");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMessage);
            }catch(Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Ok();
        }
        [Route("SaveInSession")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveInSession([FromBody] Item item)
        {
            if (HttpContext.Current.Session == null)
            {
                return Ok();
            }
            /*
            //asume that which item have is own id
            //save all the repository in a dictionary that its will be more easy to find all of them
            //instead of search of the session that there key contain 
            Dictionary<int, Item> repositoryListItem;
            if (HttpContext.Current.Session["RepositoryListItem"] == null)
            {
                HttpContext.Current.Session["RepositoryListItem"] = new Dictionary<int, Item>();
            }
            repositoryListItem = HttpContext.Current.Session["RepositoryListItem"] as Dictionary<int, Item>;
            if (repositoryListItem.ContainsKey(item.id))
            {
                //if it already exists delete and save the new one beacuse it may have been changed
                repositoryListItem.Remove(item.id);
            }
            repositoryListItem.Add(item.id, item);
            HttpContext.Current.Session["RepositoryListItem"] = repositoryListItem;*/
            return Ok();
        }
    }
}
