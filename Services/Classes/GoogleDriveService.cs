using RestSharp;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Classes
{
    public class GoogleDriveService: IGoogleDriveService
    {
        public static void ApiRequest(FileParameter file)
        {
            try
            {
                var client = new RestClient(file.Name);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                IRestResponse response = client.Execute(request);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
