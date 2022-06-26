using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.Client.Models
{
    public class Config
    {
        public string Host { get; set; }


        internal static async Task<Config> LoadConfig()
        {

            using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync("config.json");
            using StreamReader reader = new StreamReader(fileStream);

            string config = await reader.ReadToEndAsync();

            var configObject = JsonConvert.DeserializeObject<Config>(config);

            return configObject;
        }
    }
}
