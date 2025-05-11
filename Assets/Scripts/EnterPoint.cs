using System;
using Ads;
using Locator;
using UI;
using UnityEngine;
using WindowManager;
using WindowManager.Dialogs;

public class EnterPoint : MonoBehaviour,IDisposable
{
    [SerializeField] private GUIHolder guiHolder;
    [SerializeField] private AdsInitializer  adsInitializer;
    [SerializeField] private InterstitialAd interstitialAd;
    
    private MainScreenDialog _mainScreenDialog;
    private void Start()
    {
        Register();
        CreateMainScreenDialog();
        Initialize();
    }
    
    private void CreateMainScreenDialog()
    {
        _mainScreenDialog = DialogManager.ShowDialog<MainScreenDialog>();
        _mainScreenDialog.Initialize();
    }

    private void Register()
    {
        ServiceLocator.Initialize();
        
        ServiceLocator.Current.Register<GUIHolder>(guiHolder);
        ServiceLocator.Current.Register<AdsInitializer>(adsInitializer);
        ServiceLocator.Current.Register<InterstitialAd>(interstitialAd);
    }

    private void Initialize()
    {
        adsInitializer.Initialize();
        interstitialAd.Initialize();
    }

    private void OnDisable() => Dispose();

    public void Dispose()
    {
        _mainScreenDialog.Dispose();
    }
}
