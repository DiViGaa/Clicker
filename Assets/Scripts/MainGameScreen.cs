using System;
using UnityEngine;
using UnityEngine.UI;

public class MainGameScreen : MonoBehaviour
{
    [SerializeField] private View view;
    [SerializeField] private Button clickButton;

    private AbstractController _controller;

    private void OnEnable()
    {
        clickButton.onClick.AddListener(ControllerClick);
    }

    private void OnDisable()
    {
        clickButton.onClick.RemoveAllListeners();
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
