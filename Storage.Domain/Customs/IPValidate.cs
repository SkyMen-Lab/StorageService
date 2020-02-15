using System;
using System.ComponentModel.DataAnnotations;

namespace Storage.Domain.Customs
{
    public class IPValidate : ValidationAttribute
    {
        private string _ip;

        public string GetErrorMessage() =>
            $"{_ip} is not valid IP address";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _ip = (string) value;
            string[] numbers = _ip.Split(".");
            if (numbers.Length != 4) return new ValidationResult(GetErrorMessage());

            int[] octets;
            try
            {
                octets = Array.ConvertAll(numbers, Int32.Parse);
            }
            catch
            {
                return new ValidationResult(GetErrorMessage());
            }

            foreach (var octet in octets)
            {
                if (octet < 0 || octet > 255) return new ValidationResult(GetErrorMessage());
            }
            
            return ValidationResult.Success;
        }
    }
}