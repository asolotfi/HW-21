using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HW_20.Domain.Entites.Attirbute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PhoneNumberValidation:ValidationAttribute
    { 
        public override bool Equals([NotNullWhen(true)] object? obj) => base.Equals(obj);
        public override sealed bool IsValid(Object? valuse)
        {
            if (valuse == null) return false;
            var PhoneNumber=valuse.ToString();
            if(PhoneNumber.StartsWith("98"))  return true;
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
