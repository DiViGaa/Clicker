using UnityEngine;

namespace Upgrades
{
    [System.Serializable]
    public class Upgrade
    {
        public string Name {get; set;}
        public string Description{get; set;}
        public int Id {get; set;}
        public int Cost {get; set;}
        public int MinLevel {get; set;}
        public int MaxLevel {get; set;}
        public int CurrentLevel {get; set;}
        public bool IsBuyed {get; set;}
        public string ImageName {get; set;}

        
        
    }
}
