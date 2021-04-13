using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace EDP_Clinic
{
    public class RecaptchaValidation
    {
        public string Success { get; set; }
        public List<String> ErrorMessage { get; set; }

        //Default Constructor
        public RecaptchaValidation()
        {

        }

        public bool ValidateCaptcha(string recaptchaResponse)
        {
            bool result;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://www.google.com/recaptcha/api/siteverify?secret=6LejmBwaAAAAAN_gzUf_AT0q_3ZrPbD5WP5oaTml &response=" + recaptchaResponse);

            try
            {
                using (WebResponse wResponse = req.GetResponse())
                {
                    using (StreamReader readStream = new StreamReader(wResponse.GetResponseStream()))
                    {
                        //Read entire json response from recaptcha
                        string jsonResponse = readStream.ReadToEnd();

                        JavaScriptSerializer js = new JavaScriptSerializer();

                        RecaptchaValidation jsonObject = js.Deserialize<RecaptchaValidation>(jsonResponse);

                        //Read success property in json object
                        result = Convert.ToBoolean(jsonObject.Success);
                    }
                }
                return result;
            }
            catch (WebException)
            {
                throw;
            }
        }
    }
}