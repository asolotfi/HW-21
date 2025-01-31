using HW_20.Domain.Entites.Attirbute;
using HW_20.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace HW_20.Domain.Entites.Car
{
    public class InspectionRequest
    {
        #region Properties
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "کد ملی الزامی است.")]
        [StringLength(10, ErrorMessage = "کد ملی باید 10 رقم باشد.")]
        public string CodeMeli { get; set; }

        [Required(ErrorMessage = "شماره پلاک الزامی است.")]
        [RegularExpression(@"^[A-Za-z0-9]{6,8}$", ErrorMessage = "شماره پلاک باید حاوی 6 تا 8 کاراکتر باشد.")]
        public string PlateNumber { get; set; }
        public DateTime RequestDate { get; set; }
        public RequestStatusEnum Status { get; set; } // وضعیت درخواست (تأیید شده، رد شده، در انتظار)
        [Required(ErrorMessage = "لطفاً نام ماشین را وارد کنید")]
        public String Car { get; set; }
        [Required(ErrorMessage = "لطفاً نام شرکت را وارد کنید")]
        public string Company { get; set; }
        public DateTime ProductionDate { get; set; }
        #endregion
    }
}
