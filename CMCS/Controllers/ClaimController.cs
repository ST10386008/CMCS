using Microsoft.AspNetCore.Mvc;
using CMCS.Models;
namespace CMCS.Controllers
{
    public class ClaimController : Controller
    {
        // Lecturer submits a claim
        public IActionResult SubmitClaim()
        {
            return View();
        }

        // Coordinator approves or rejects a claim
        public IActionResult ApproveClaim()
        {
            return View();
        }

        // Lecturer tracks the status of their claim
        public IActionResult TrackClaim()
        {
            return View();
        }
    }
}
