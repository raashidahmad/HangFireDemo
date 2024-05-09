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
        private IResponseHelper response;
        public JobSchedulerController(IResponseHelper responseHelper) 
        { 
            response = responseHelper;
        }

        [HttpGet]
        public IActionResult FireAndForgetJob()
        {
            BackgroundJob.Enqueue(() => Console.WriteLine($"Welcome to {welcomePackage}"));
            return Ok();
        }
    }
}
