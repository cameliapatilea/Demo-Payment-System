using PaymentApplication.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaymentApplication.Models
{
    public class CreditCard
    {
        [Required(ErrorMessage = "The Credit Card Number is mandatory!")]
        [RegularExpression(@"^[0-9]{16}", ErrorMessage = "The Credit Card Number must have only 16 digits!")]
        [DisplayName("Credit Card Number")]
        public string CreditCardNumber { get; set; }
        
        [Required(ErrorMessage = "The name os the Card Holder is mandatory!")]
        [DisplayName("Credit Card Holder")]
        public string CardHolder { get; set; }

        [Required(ErrorMessage = "You need to enter the Card's Expiration Date!")]
        [DataType(DataType.Date)]
        [DateEqualOrHigherThanToday(ErrorMessage ="The expiration date cannot be in the past!")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Expiration Date")]
        public DateTime ExpirationDate { get; set; }


        /* Security code might be 009. Int type will replace it with 9
         * Field type -> string
         */
        [RegularExpression(@"(^[0-9]{3})|(^$)", ErrorMessage = "The Security code must have 3 digits!")]
        [DisplayName("Security Code")]
        public string SecurityCode { get; set; }

        [Required(ErrorMessage = "You have to type the amount of money!")]
        [Range(0.0, Double.MaxValue, ErrorMessage = "The amount must be positive!")]
        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        
    }
}

