using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaymentApplication.Helpers
{
    class DateEqualOrHigherThanTodayAttribute : ValidationAttribute
    {
        /*
         * Return true if date is equal or higher than today
         * Else return false
         */
        public override bool IsValid(object value) 
        {
            
            DateTime d = Convert.ToDateTime(value);
            return d >= DateTime.Now;
        }
    }
}
