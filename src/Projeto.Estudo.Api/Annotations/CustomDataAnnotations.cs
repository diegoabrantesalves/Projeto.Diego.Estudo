using System.ComponentModel.DataAnnotations;

namespace Projeto.Estudo.Api.Annotations
{
    public class CurrentDateAttribute : ValidationAttribute
    {
        public CurrentDateAttribute()
        {
        }

        public override bool IsValid(object? value)
        {
            if (value == null)
                return false;

            if ((DateTime)value < DateTime.Now)            
                return false;
            
            return true;
        }
    }
}
