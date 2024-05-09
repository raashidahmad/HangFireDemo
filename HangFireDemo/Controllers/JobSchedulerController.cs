using Hangfire;
using HangFireDemo.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HangFireDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSchedulerController : ControllerBase
    {
        string welcomePackage = "HangFire";
        public IResponseHelper responseHelper;
        private Response response;

        public JobSchedulerController(IResponseHelper responseHelper) 
        { 
            this.responseHelper = responseHelper;
            response = this.responseHelper.GetResponseTemplate();
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult FireAndForgetJob()
        {
            var jobId = BackgroundJob.Enqueue(() => Console.WriteLine($"Welcome to {welcomePackage}"));
            response.Message = $"Successfully executed the Fire and Forget Job having Id {jobId}";
            return Ok(response);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult DelayedJob()
        {
            var jobId = BackgroundJob.Schedule(() => Console.WriteLine("Welcome user in Delayed Job Demo!"), TimeSpan.FromSeconds(60));
            response.Message = $"Successfully executed the Schduled Job having Id {jobId}";
            return Ok(response);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult ContinuousJob()
        {
            var jobId = BackgroundJob.Schedule(() => Console.WriteLine("A scheduled parent job"), TimeSpan.FromSeconds(120));
            BackgroundJob.ContinueJobWith(jobId, () => Console.WriteLine());
            response.Message = $"Successfully configured a job with continu with id having Job Id as ${jobId}";
            return Ok(response);
        }
    }
}
