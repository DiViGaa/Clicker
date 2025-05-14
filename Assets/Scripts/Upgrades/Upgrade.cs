using UnityEngine;

namespace Upgrades
{
    [System.Serializable]
    public class Upgrade : MonoBehaviour
    {
        public string Name {get; private set;}
        public string Description{get; private set;}
        public int Id {get; private set;}
        public int Cost {get; private set;}
        public int MinLevel {get; private set;}
        public int MaxLevel {get; private set;}
        public int CurrentLevel {get; private set;}
        public bool IsBuyed {get; private set;}
        public string ImagePath {get; private set;}

    }
}
