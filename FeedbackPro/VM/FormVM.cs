using FeedbackPro.DTO;
using FeedbackPro.Models;

namespace FeedbackPro.VM
{
    public class FormVM
    {
       public FormsDTO? Forms { get; set; }

       public IList<FormField>? FormField { get; set; }
    }
}
