using System.Collections.Generic;
using JSON;
using UnityEngine;

namespace Upgrades
{
    public class UpgradeCreator: IService
    {
        private List<Upgrade> upgrades =  new List<Upgrade>();
        private string UpgradesPath => "Prefabs/UpdateButton/UpdateButton";

        public void Initialize()
        {
            var upgrades = JsonUpgradeReader.LoadJson("Upgrades.json");

            foreach (var upgrade in upgrades)
                this.upgrades.Add(upgrade);
        }

        public void CreateUpgradeButtons(GameObject  upgradeParent)
        {
            foreach (var upgrade in upgrades)
            {
                var prefab = Resources.Load<GameObject>(UpgradesPath);
                var upgradeButton = prefab.GetComponent<UpgradeButton>();
                var upgradeButtonInstantiate = GameObject.Instantiate(upgradeButton, upgradeParent.transform);
                upgradeButtonInstantiate.name = "UpgradeButton " + upgrade.Name;
                upgradeButtonInstantiate.Initialize(upgrade);
            }
        }
    }
}
