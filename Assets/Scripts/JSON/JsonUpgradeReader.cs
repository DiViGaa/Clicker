using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using Upgrades;
using File = System.IO.File;

namespace JSON
{
    public static class JsonUpgradeReader
    {
        public static List<Upgrade> LoadJson(string fileName)
        {
            string url = string.Empty;
            url = Application.dataPath + "/Resources/JSON/" + fileName;

            string json = File.ReadAllText(url);
            
            List<Upgrade> upgrades = JsonConvert.DeserializeObject<List<Upgrade>>(json);
            return upgrades;
        }
    }
}
