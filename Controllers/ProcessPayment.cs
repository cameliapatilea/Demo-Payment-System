using PaymentApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;
using PaymentApplication.Helpers;

namespace PaymentApplication.Controllers
{
    public class ProcessPayment
    {
        public void ProcessPaymentMethod(CreditCard creditCard)
        {
            MockPaymentProviders mock = new MockPaymentProviders();

            if (creditCard.Amount < 21)
            {
                bool result = mock.CheapPaymentServices(creditCard);
            }
            else if (creditCard.Amount >= 21 && creditCard.Amount < 500)
            {
                bool result = mock.ExpensivePaymentServices(creditCard);
                if (result == false)
                    result = mock.CheapPaymentServices(creditCard);
            }
            else
            {
                bool result = mock.PremiumPaymentServices(creditCard);
                int cnt = 3;


                while (cnt > 0 && result == false)

                {
                    result = mock.PremiumPaymentServices(creditCard);
                    cnt--;
                }

            }

        }
    }
}
