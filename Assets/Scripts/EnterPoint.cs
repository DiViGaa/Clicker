using Locator;
using UI;
using UnityEngine;
using WindowManager;
using WindowManager.Dialogs;

public class EnterPoint : MonoBehaviour
{
    [SerializeField] private GUIHolder guiHolder;
    
    private void Start()
    {
        Register();
        CreateMainScreenDialog();
    }
    
    private void CreateMainScreenDialog()
    {
        var dialog = DialogManager.ShowDialog<MainScreenDialog>();
        dialog.Init();
    }

    private void Register()
    {
        ServiceLocator.Initialize();
        
        ServiceLocator.Current.Register<GUIHolder>(guiHolder);
    }
    
}
