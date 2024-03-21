using FeedbackPro.Data;
using FeedbackPro.DTO;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using LinqKit;
using FeedbackPro.Models;


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

        [Route("~/Api/GetQrCode")]
        [HttpGet]
        public async Task<IActionResult> GetQrCode()
        {
            try
            {
                var qrcodes = await _db.Qrcodes.Select(x => new QrCodeDTO
                {
                    Id = x.Id,
                    Registration = x.Registration,
                }).ToListAsync();

                return Ok(new { result = true, message = "Qr codes  fetched successfully", Data = qrcodes, });
            }
            catch (Exception ex)
            {
                return Ok(new { result = false, Data = "", message = ex.Message });
            }
        }


        [Route("~/Api/OverallFeedbackScore")]
        [HttpPost]
        public async Task<IActionResult> OverallFeedbackScore(ScoreDTO score)
        {
            try
            {
                var fbpredicate = PredicateBuilder.New<Feedback>();

                fbpredicate = fbpredicate.And(x => x.CompanyId == 1);

                if (score.QrcodeId != null && score.QrcodeId != 0)
                {
                    fbpredicate = fbpredicate.And(x => x.CompanyId ==1  && x.QrcodeId == score.QrcodeId);
                }

                var fbdpredicate = PredicateBuilder.New<FeedbackDetail>();

                fbdpredicate = fbdpredicate.And(x => x.CompanyId == 1);

                if (score.NumberofDays != null && score.NumberofDays != 0)
                {
                    fbdpredicate = fbdpredicate.And(x => x.CompanyId == 1 && x.EntryDate == DateTime.Now.AddDays(Convert.ToInt32(score.NumberofDays)));
                }

                var query = await _db.Qrcodes.Where(qr => qr.CompanyId == 1)
                .Select(qr => new OverallFeedbackScoreDTO
                {
                    OneStar = _db.Feedbacks.Where(fbpredicate)
                    .Join(_db.FeedbackDetails, fb => fb.Id, fbd => fbd.FeedbackId, (fb, fbd) => fbd)
                    .Where(fbdpredicate).Count(fbd=> fbd.FormFieldValue == "1" ),
                    TwoStar = _db.Feedbacks.Where(fbpredicate)
                    .Join(_db.FeedbackDetails, fb => fb.Id, fbd => fbd.FeedbackId, (fb, fbd) => fbd)
                    .Where(fbdpredicate).Count(fbd => fbd.FormFieldValue == "2"),
                    ThreeStar = _db.Feedbacks.Where(fbpredicate)
                    .Join(_db.FeedbackDetails, fb => fb.Id, fbd => fbd.FeedbackId, (fb, fbd) => fbd)
                    .Where(fbdpredicate).Count(fbd => fbd.FormFieldValue == "3"),
                    FourStar = _db.Feedbacks.Where(fbpredicate)
                    .Join(_db.FeedbackDetails, fb => fb.Id, fbd => fbd.FeedbackId, (fb, fbd) => fbd)
                    .Where(fbdpredicate).Count(fbd => fbd.FormFieldValue == "4"),
                    FiveStar = _db.Feedbacks.Where(fbpredicate)
                    .Join(_db.FeedbackDetails, fb => fb.Id, fbd => fbd.FeedbackId, (fb, fbd) => fbd)
                    .Where(fbdpredicate).Count(fbd =>fbd.FormFieldValue == "5"),
                }).FirstOrDefaultAsync();

                return Ok(new { result = true, message = "Overall Feedback Score  fetched successfully", Data = query });
            }
            catch (Exception ex)
            {
                return Ok(new { result = false, Data = "", message = ex.Message });
            }
           
        }
    }
}
