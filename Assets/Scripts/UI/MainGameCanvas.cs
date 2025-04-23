using UnityEngine;

namespace UI
{
    public class MainGameCanvas : MonoBehaviour
    {
        [SerializeField] private MainGameScreen mainScreen;
        [SerializeField] private GameObject shopScreen;
        [SerializeField] private GameObject menuScreen;

        private void OnEnable()
        {
            mainScreen.OnClickMenuButton += ChangeMainScreenToMenuScreen;
            mainScreen.OnClickShopButton += ChangeMenuScreenToShopScreen;
        }

        private void ChangeMenuScreenToShopScreen()
        {
            mainScreen.gameObject.SetActive(false);
            shopScreen.SetActive(true);
        }

        private void ChangeMainScreenToMenuScreen()
        {
            mainScreen.gameObject.SetActive(false);
            menuScreen.SetActive(true);
        }
        
    }
}
