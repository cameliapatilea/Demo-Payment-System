using PaymentApplication.Controllers;
using PaymentApplication.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessPayment paymentProcess = new ProcessPayment();

            Console.WriteLine("Pick one of the following tests:");
            Console.WriteLine("1. Test no. 1 - Validation failed because of the Credit Card Number and the Expiration Date.");
            Console.WriteLine("2. Test no. 2 - Validation approved for the expensive amount of money.");
            Console.WriteLine("3. Test no. 3 - Enter all details of the card: Credit Card Number, Card Holder, Expiration Code, Security Code(opional) and the amount of money.");

            string input = Console.ReadLine();
            if (input.Equals("1"))
            {
                // Credit card number validation fails
                try
                {
                    CreditCard creditCard = new CreditCard
                    {
                        CreditCardNumber = "123456789",
                        ExpirationDate = Convert.ToDateTime("10/01/2010"),
                        CardHolder = "Vasile",
                        SecurityCode = "023",
                        Amount = 15
                    };

                    Validator.ValidateObject(creditCard, new ValidationContext(creditCard, null, null), true);

                    paymentProcess.ProcessPaymentMethod(creditCard);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                // Expiration date custom validation fails
                try
                {
                    CreditCard creditCard = new CreditCard
                    {
                        CreditCardNumber = "1234567890000000",
                        ExpirationDate = Convert.ToDateTime("10/01/2010"),
                        CardHolder = "Vasile",
                        SecurityCode = "023",
                        Amount = 15
                    };

                    Validator.ValidateObject(creditCard, new ValidationContext(creditCard, null, null), true);

                    paymentProcess.ProcessPaymentMethod(creditCard);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            //The payment is processed for an Expensive amount

            else if (input.Equals("2"))
            {
                try
                {
                    CreditCard creditCard = new CreditCard
                    {
                        CreditCardNumber = "1234567890000000",
                        ExpirationDate = Convert.ToDateTime("10/01/2020"),
                        CardHolder = "Vasile",
                        SecurityCode = "023",
                        Amount = 250
                    };

                    Validator.ValidateObject(creditCard, new ValidationContext(creditCard, null, null), true);

                    paymentProcess.ProcessPaymentMethod(creditCard);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (input.Equals("3"))
            {


                try
                {
                    Console.WriteLine("Enter Credit Card Number:");
                    string cardNum = Console.ReadLine();

                    Console.WriteLine("Enter Credit Card Holder:");
                    string cardName = Console.ReadLine();

                    Console.WriteLine("Enter the Expiration Date of the card:");
                    DateTime cardExp = Convert.ToDateTime(Console.ReadLine());


                    Console.WriteLine("Enter the Security Code (optional):");
                    string cardSecurityCode = Console.ReadLine();

                    Console.WriteLine("Enter the amount of money:");
                    decimal amountOfMoney = Convert.ToDecimal(Console.ReadLine());

                    CreditCard creditCard = new CreditCard
                    {
                        CreditCardNumber = cardNum,
                        ExpirationDate = cardExp,
                        CardHolder = cardName,
                        SecurityCode = cardSecurityCode,
                        Amount = amountOfMoney
                    };

                    Validator.ValidateObject(creditCard, new ValidationContext(creditCard, null, null), true);

                    paymentProcess.ProcessPaymentMethod(creditCard);
                }


                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
    }
}
