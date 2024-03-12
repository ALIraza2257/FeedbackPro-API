
using FeedbackPro.Data;
using FeedbackPro.DTO;
using FeedbackPro.Models;
using FeedbackPro.VM;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace FeedbackPro.Controllers
{
    //[EnableCors("OpenCORSPolicy")]
    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackProContext _db;

        public FeedbackController(

            FeedbackProContext db
          )
        {
            _db = db;
        }
        [Route("~/Api/GetForms")]
        [HttpGet]
        public async Task<IActionResult> GetForms()
        {
            try
            {
                var form = await _db.RefCompanies.Where(x => x.Id == 1)
                 .Join(_db.Forms,
                 refcompanies => refcompanies.Id,
                 forms => forms.CompanyId,
                 (refcompanies, forms) => new FormsDTO
                 {
                     CompanyId = refcompanies.Id,
                     FormTitleToShow = forms.FormTitleToShow,
                     MessageToShow = forms.MessageToShow,
                     LogoUrl = refcompanies.LogoUrl,
                     FormId = forms.Id,
                 }).FirstOrDefaultAsync();

                var formField = await _db.FormFields.Where(x => x.CompanyId == 1).ToListAsync();

                var formVM = new FormVM
                {
                    Forms = form,
                    FormField = formField,
                };

                return Ok(new { result = true, message = "Form Field  fetched successfully", Data = formVM, });
            }
            catch (Exception ex) {
                return Ok(new { result = false, Data = "", message = ex.Message });
            }
            
        }


        [Route("/Api/Feedback")]
        [HttpPost]
        public async Task<IActionResult> Feedback(Feedback Feedback)
        {
            try
            {
                long maxid = await _db.Feedbacks.Select(x => x.Id).DefaultIfEmpty().MaxAsync() + 1;
                Feedback.Id = maxid;
                Feedback.QrcodeId = 1;
                Feedback.EntryDate = DateTime.Now;
                Feedback.EntryUserId = 0;
                Feedback.IsActive = true;

                long maxiddetail = await _db.FeedbackDetails.Select(x => x.Id).DefaultIfEmpty().MaxAsync() + 1;

                for (int i = 0; i < Feedback.FeedbackDetail.Count(); i++)
                {
                    Feedback.FeedbackDetail[i].Id = maxiddetail;
                    Feedback.FeedbackDetail[i].FeedbackId = maxid;
                    Feedback.FeedbackDetail[i].CompanyId = Feedback.CompanyId;
                    Feedback.FeedbackDetail[i].EntryUserId = 0;
                    Feedback.FeedbackDetail[i].EntryDate = DateTime.Now;
                    Feedback.FeedbackDetail[i].IsActive = true;
                    maxiddetail++;
                }

                await _db.AddAsync(Feedback);

                await _db.AddRangeAsync(Feedback.FeedbackDetail);

                await _db.SaveChangesAsync();

                return Ok(new { result = true, message = "Feedback Saved successfully", Data = Feedback });

            }
            catch (Exception ex)
            {
                return Ok(new { result = false, message = ex.Message, Data = "", });
            }

            
        }
    }
}
