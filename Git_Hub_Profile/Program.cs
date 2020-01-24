using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.Text;

namespace Git_Hub_Profile
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://api.github.com/users/anniks2010?client_id=6031e0d559160618be74&client_secret=ecac0f6e3c0a0964f53d4022645ba4ea887f3d88";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            request.UserAgent = "Foo";
            request.Accept = "*/*";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            using (var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd(); ////panen valmis koha, kuhu maha lugeda, mis on olemas vastuses
                ProfileData profileData = JsonConvert.DeserializeObject<ProfileData>(response);
                Console.WriteLine($"Login: {profileData.Login}");
                Console.WriteLine($"Public repos:{profileData.Public_repos}");
                Console.WriteLine($"Followers:{profileData.Followers}");
                Console.WriteLine($"Following:{profileData.Following}");
                Console.WriteLine($"Avatar url:{profileData.Avatar_url}");


            }
        }
    }
}
