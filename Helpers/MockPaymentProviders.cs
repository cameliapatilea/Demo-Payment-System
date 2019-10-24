using PaymentApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApplication.Helpers
{
    /*
     * In order to simulate failed payments, the program introduces an artificial probability.
     * 
     */
     class MockPaymentProviders
    {
        public bool PremiumPaymentServices(CreditCard creditCard)
        {
            int randomNumber = GenerateRandomNumber(0, 100);

            if (randomNumber < 10)
            {
                Console.WriteLine("Premium Payment failed");
                return false;
            }
            Console.WriteLine("Premium Payment has been processed successfully!");
            return true;
        }


        public bool ExpensivePaymentServices(CreditCard creditCard)
        {
            int randomNumber = GenerateRandomNumber(0, 100);

            if (randomNumber < 20)
            {
                Console.WriteLine("Expensive Payment failed");
                return false;
            }
            Console.WriteLine("Expensive Payment has ben processed successfully!");
            return true;
        }


        public bool CheapPaymentServices(CreditCard creditCard)
        {

            int randomNumber = GenerateRandomNumber(0, 100);

            if (randomNumber < 30)
            {
                Console.WriteLine("Cheap Payment failed");
                return false;
            }


            Console.WriteLine("Cheap Payment has been processed successfully!");
            return true;
        }


        #region Utilities

        public int GenerateRandomNumber(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                int temp = minValue;
                minValue = maxValue;
                maxValue = temp;
            }

            Random random = new Random();
            int randomNumber = random.Next(minValue, maxValue);

            return randomNumber;
        }

        #endregion

    }

}
