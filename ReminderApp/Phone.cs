using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace ReminderApp
{
    /*
     * This class contains all the functionality for phone functions like text and call
     * It uses Twilio API
     */
    class Phone
    {

        string _twilioNumber = "";//Enter the number associated with your Twilio account
        static string accountSid = ""; //Enter the SID associated with your Twilio account
        static string authToken = "";  //Enter your access token associated with your Twilio account
        TwilioRestClient twilio = new TwilioRestClient(accountSid, authToken);
        /*
         * Takes two string parameters used to build text message body and destination phone number repectively
         */
        public void sendMessage(string msg, string phoneNumber)
        {
            try
            {
                var message = twilio.SendMessage(
                    _twilioNumber, // From
                     phoneNumber, // To
                    "The task " + msg
                    );
                if (message.RestException != null)
                {
                    var error = message.RestException.Message;
                    throw new CustomException("Number does not exist");

                }
            }
            catch (CustomException)
            {
                MessageBox.Show("This number is not registered, please register is first!");
            }
        }
        /*
         * Takes destination phone number as string parameter
         */
        public void Call(string phoneNumber)
        {
            // The XML file generated when a new task is added is uploaded to the link below
            var call = twilio.InitiateOutboundCall(_twilioNumber, phoneNumber, "http://mobile.sheridanc.on.ca/¬ahmasaad/Twilio/voice.xml");
            var callStatus = twilio.GetCall(call.Sid);

            if (call.RestException != null)
            {
                var error = call.RestException.Message;
                //MessageBox.Show(error);
            }
        }

    }
}
/*
 * User defined exception
 */
public class CustomException : Exception
{
    public CustomException(string Message)
        : base(Message)
    {
    }
}