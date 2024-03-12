using FeedbackPro.Data;
using FeedbackPro.DTO;
using FeedbackPro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FeedbackPro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : Controller
    {
        private readonly FeedbackProContext _db;

        public DashboardController(

            FeedbackProContext db
          )
        {
            _db = db;
        }
        [Route("~/Api/Dashboard")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //Faraz
            var counts = await _db.FeedbackDetails.Where(x => x.FormFieldId != 7)
                   .GroupBy(item => new { item.FormFieldValue })
                     .Select(g => new
                     {
                         FormFieldValue = g.Key.FormFieldValue,
                         Count = g.Count()
                     }).OrderByDescending(x=>x.Count).ToListAsync();





            return Ok(counts);
        }
    }
}
