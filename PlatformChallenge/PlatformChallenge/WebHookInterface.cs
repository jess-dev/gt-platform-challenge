﻿using Newtonsoft.Json;
using PlatformChallenge.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PlatformChallenge
{
    class WebHookInterface
    {
        public static void Post(ParsedRecord record)
        {
            try
            {
                // create web request
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(appSettings.WebhookPath);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                // convert our object to a json string
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(record);
                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }

                Console.WriteLine("ID: {0} - Posted successfully - {1}", record.data.id, DateTime.Now);
            }
            catch (WebException)
            {
                Console.WriteLine("There was an issue while posting ID: {0}", record.data.id);
                throw;
            }
        }
    }
}
