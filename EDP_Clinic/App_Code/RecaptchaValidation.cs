using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace EDP_Clinic.App_Code
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

            //Retrieve keys from web.config
            NameValueCollection myKeys = ConfigurationManager.AppSettings;
            var googleSecretKey = myKeys["GOOGLE_RECAPTCHA_SECRET_KEY"];

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://www.google.com/recaptcha/api/siteverify?secret="+
                googleSecretKey + "&response=" + recaptchaResponse);

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