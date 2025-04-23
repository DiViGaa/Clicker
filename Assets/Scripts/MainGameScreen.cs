using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainGameScreen : MonoBehaviour
{
    [SerializeField] private View view;
    [SerializeField] private Button clickButton;
    [SerializeField] private Button MenuButton;
    [SerializeField] private Button ShopButton;
    
    public event UnityAction OnClickMenuButton;
    public event UnityAction OnClickShopButton;
    
    private UnityAction _menuButtonCallback;
    private UnityAction _shopButtonCallback;
    
    private AbstractController _controller;

    private void OnEnable()
    {
        _menuButtonCallback = () => OnClickMenuButton?.Invoke();
        _shopButtonCallback = () => OnClickShopButton?.Invoke();
        clickButton.onClick.AddListener(ControllerClick);
        MenuButton.onClick.AddListener(_menuButtonCallback);
        ShopButton.onClick.AddListener(_shopButtonCallback);
    }

    private void OnDisable()
    {
        clickButton.onClick.RemoveAllListeners();
        MenuButton.onClick.RemoveAllListeners();
        ShopButton.onClick.RemoveAllListeners();
        _menuButtonCallback = null;
        _shopButtonCallback = null;
    }

    private void ControllerClick()
    {
        _controller.Click();
    }

    private void Start()
    {
        AbstractModel model = new Model(view);
        _controller = new Controller(view, model);
    }
}
