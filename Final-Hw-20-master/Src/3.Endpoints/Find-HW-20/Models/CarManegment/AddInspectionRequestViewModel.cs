using HW_20.Domain.Entites.Attirbute;
using System.ComponentModel.DataAnnotations;

namespace Find_HW_20.Models.CarManegment
{
    public class AddInspectionRequestViewModel
    {
        //[Range(1,10,string="بین 1 تا 10")]
        //[Display(PhoneNumber = "شماره موبایل")]
        [Required(ErrorMessage ="وارد نمودن شماره موبایل احباری می یاشد")]
        [PhoneNumberValidation(ErrorMessage = "شماره موبایل را وارد کنید")]
        [StringLength(13)]
        [RegularExpression(@"^(\+98|0)?9\d{9}$",ErrorMessage = "فرمت شماره موبایل صحیح نمی باشد")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "کد ملی الزامی است")]
        [StringLength(10, ErrorMessage = "کد ملی باید 10 رقم باشد")]
        public string CodeMeli { get; set; }
        [Required(ErrorMessage = "شماره پلاک الزامی است")]
        [RegularExpression(@"^[A-Za-z0-9]{6,8}$", ErrorMessage = "شماره پلاک باید حاوی 6 تا 8 کاراکتر باشد")]
        public string PlateNumber { get; set; }
        public String Car { get; set; }
        [Required(ErrorMessage = "لطفاً نام شرکت را وارد کنید")]
        public string Company { get; set; }
        public DateTime ProductionDate { get; set; }
    }
}
