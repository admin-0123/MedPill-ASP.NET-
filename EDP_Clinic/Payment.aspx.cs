using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;
using System.Text.RegularExpressions;
using System.Drawing;

namespace EDP_Clinic
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private bool ValidateInput()
        {
            DateTime currentDate = DateTime.Now;
            //Checks if card name is empty
            if (String.IsNullOrEmpty(nameOnCardTB.Text))
            {
                nameOnCardError.Text = "Please enter name on card";
                nameOnCardError.ForeColor = Color.Red;
                nameOnCardError.Visible = true;
            }
            else if (!Regex.IsMatch(nameOnCardTB.Text, "^[a-zA-Z0-9 ]*$"))
            {
                nameOnCardError.Text = "Please enter valid card name";
                nameOnCardError.ForeColor = Color.Red;
                nameOnCardError.Visible = true;
            }
            else
            {
                nameOnCardError.Text = "";
                nameOnCardError.Visible = false;
            }

            //result = int.TryParse(cardNumberTB.Text, out cardNumber);
            //checks if card number is actually numbers     
            //checks if there is other character other than numbers
            if (!Regex.IsMatch(cardNumberTB.Text, "^[0-9]*$"))
            {
                //cardNumberError.Text = "Testing";
                cardNumberError.Text = "Please enter a valid card number";
                cardNumberError.ForeColor = Color.Red;
                cardNumberError.Visible = true;
            }
            //checks if its empty or null
            else if (String.IsNullOrEmpty(cardNumberTB.Text))
            {
                cardNumberError.Text = "Please enter card number";
                cardNumberError.ForeColor = Color.Red;
                cardNumberError.Visible = true;
            }
            else if (cardNumberTB.Text.Length > 16)
            {
                cardNumberError.Text = "Please enter a valid card number";
                cardNumberError.ForeColor = Color.Red;
                cardNumberError.Visible = true;
            }
            else
            {
                cardNumberError.Text = "";
                cardNumberError.Visible = false;
            }

            //Checks Card CVV Number
            if (!Regex.IsMatch(CVVTB.Text, "^[0-9]*$"))
            {
                CVVError.Text = "Please enter a valid CVV number";
                CVVError.ForeColor = Color.Red;
                CVVError.Visible = true;
            }
            //checks if its empty or null
            else if (String.IsNullOrEmpty(CVVTB.Text))
            {
                CVVError.Text = "Please enter CVV number";
                CVVError.ForeColor = Color.Red;
                CVVError.Visible = true;
            }
            else if (CVVTB.Text.Length != 4)
            {
                CVVError.Text = "Please enter a 4 digit CVV number";
                CVVError.ForeColor = Color.Red;
                CVVError.Visible = true;
            }
            else
            {
                CVVError.Text = "";
                CVVError.Visible = false;
            }

            //Checks if card expiry date is chosen or not
            if (String.IsNullOrEmpty(cardExpiryTB.Text))
            {
                cardExpiryError.Text = "Please select card expiry date";
                cardExpiryError.ForeColor = Color.Red;
                cardExpiryError.Visible = true;
            }
            else
            {
                DateTime inputDate = Convert.ToDateTime(cardExpiryTB.Text);
                double monthDifference = inputDate.Subtract(currentDate).Days / (365.25 / 12);
                if (monthDifference < 3)
                {
                    cardExpiryError.Text = "Please ensure that your expiry date is at least 3 months from current date";
                    cardExpiryError.ForeColor = Color.Red;
                    cardExpiryError.Visible = true;
                }
                else
                {
                    //cardExpiryError.Text = monthDifference.ToString();
                    //cardExpiryError.ForeColor = Color.Black;
                    cardExpiryError.Text = "";
                    cardExpiryError.Visible = false;
                }
            }

            //checks if any error labels is empty or not
            if (String.IsNullOrEmpty(cardNumberError.Text)
                && String.IsNullOrEmpty(nameOnCardError.Text)
                && String.IsNullOrEmpty(cardExpiryError.Text)
                && String.IsNullOrEmpty(CVVError.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            bool validInput = ValidateInput();
            //Testing Stripe
            StripeConfiguration.ApiKey = "sk_test_4eC39HqLyjWDarjtT1zdp7dc";
            var options = new PaymentIntentCreateOptions
            {
                Amount = 1000,
                Currency = "usd",
                PaymentMethodTypes = new List<string>
              {
                "card",
              },
                ReceiptEmail = "jenny.rosen@example.com",
            };

            var service = new PaymentIntentService();
            var paymentIntent = service.Create(options);
            System.Diagnostics.Debug.WriteLine(paymentIntent);
            //Console.WriteLine(paymentIntent);
        }
    }
}