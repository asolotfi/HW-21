using System.ComponentModel.DataAnnotations;

namespace HW_20.Domain.Entites.User
{
    public class User
    {
  
        public int Id { get; set; }
        [Required(ErrorMessage = "نام کاربری الزامی است.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "رمز عبور الزامی است.")]
        [MinLength(6, ErrorMessage = "رمز عبور باید حداقل 10 کاراکتر باشد.")]
        public string PhoneNumber { get; set; }
    }
}
