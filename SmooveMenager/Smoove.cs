using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SmooveMenager
{
    internal class Smoove
    {
        public async Task<HttpStatusCode> CreateList(string apiKey, string name, string publicName)
        {
            using (var httpClient = new HttpClient())
            {

                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://rest.smoove.io/v1/Lists"))
                {

                    var jsonObj = new
                    {
                        description = "This list is a list for new subscribers",
                        name = $"{name}",
                        publicDescription = "Public name - This list is a list for new subscribers",
                        permissions = new
                        {
                            isPublic = true,
                            allowsUsersToSubscribe = true,
                            allowsUsersToUnsubscribe = true,
                            isPortal = false
                        },
                        publicName = $"{publicName}"
                    };
                    string jStr = JsonConvert.SerializeObject(jsonObj);
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {apiKey}");
                    // request.Content = new StringContent($"{{ \"description\": \"This list is a list for new subscribers\",  \"name\": \"{name}\", \"publicDescription\": \"Public name - This list is a list for new subscribers\",  \"permissions\": {{    \"isPublic\": true,    \"allowsUsersToSubscribe\": true,    \"allowsUsersToUnsubscribe\": true,    \"isPortal\": false  }},  \"publicName\": \"{publicName}\"}}");
                    request.Content = new StringContent($"{jStr}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");


                    var response = await httpClient.SendAsync(request);

                    return response.StatusCode;
                }
            }
        }

        public async Task<HttpStatusCode> AddToList(string apiKeyAdd, string email, string phone, string list, string fName, string lName)
        {
            using (var httpClient = new HttpClient())
            {

                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://rest.smoove.io/v1/Contacts?updateIfExists=true&restoreIfDeleted=true&restoreIfUnsubscribed=true&overrideNullableValue=false"))
                {
                    
                    var jsonObj = new
                    {
                        company = "My Company",
                        email = $"{email}",
                        phone = $"{phone}" ,
                        lists_ToSubscribe = new string[] {$"{list}"},
                        lastName = $"{lName}",
                        address = "Wellfield Road",
                        firstName = $"{fName}",
                        dateOfBirth = "2023-04-23T09:50:36.8943427Z"
                    };
                    string jStr = JsonConvert.SerializeObject(jsonObj);
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {apiKeyAdd}");
                    //request.Content = new StringContent($"{{ \"company\": \"My Company\",  \"email\": \"{email}\",\"phone\": \"{phone}\",\"lists_ToSubscribe\": [\"{list}\"],  \"lastName\": \"{lName}\",\"canReceiveSmsMessages\": true,\"canReceiveEmails\": true,  \"address\": \"Wellfield Road\",  \"firstName\": \"{fName}\",  \"dateOfBirth\": \"2023-04-21T16:53:48.9519144Z\"}}");
                    request.Content = new StringContent($"{jStr}"); 
                   request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");


                    var response = await httpClient.SendAsync(request);
                    return response.StatusCode;
                }
        }
    }

    public async Task<HttpStatusCode> SendMessage(string apiKeyMsg, string reciever, string sender, string msg)
    {
        using (var httpClient = new HttpClient())
        {

            using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://rest.smoove.io/v1/Messages?sendNow=true"))
            {
                    var jsonObj = new
                    {
                        toMembersByCell = new string[] { $"{reciever}" },
                        body = $"{msg}",
                        fromNumber = $"{sender}"
                    };
                    string jStr = JsonConvert.SerializeObject(jsonObj);
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {apiKeyMsg}");
                    //request.Content = new StringContent($"{{ \"toMembersByCell\": [\"{reciever}\"],\"body\": \"{msg}\",\"fromNumber\": \"{sender}\"}}");
                    request.Content = new StringContent($"{jStr}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");



                    var response = await httpClient.SendAsync(request);
                    return response.StatusCode;
                }
        }
    }

    public async Task<HttpStatusCode> GetLists(string apiKeyList)
    {
        using (var httpClient = new HttpClient())
        {

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://rest.smoove.io/v1/Lists?fields=id%2Cname&page=1&itemsPerPage=100&sort=name"))
            {
                request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {apiKeyList}");

                var response = await httpClient.SendAsync(request);
                    return response.StatusCode;
                }
        }
    }
}
}
