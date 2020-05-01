using System;
using System.Net;
using Newtonsoft.Json;

namespace CTeleportTest.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly WebClient client;

        public GenericRepository()
        {
            client = new WebClient();
        }

        public T DownloadSerializedJsonData<T>(string url) where T : new()
        {
            var jsonData = string.Empty;
            // attempt to download JSON data as a string
            try
            {
                jsonData = client.DownloadString(url);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // if string with JSON data is not empty, deserialize it to class and return its instance 
            return !string.IsNullOrEmpty(jsonData) ? JsonConvert.DeserializeObject<T>(jsonData) : new T();
        }
    }
}
