using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] private View view;
    [SerializeField] private Button clickButton;

    private void Start()
    {
        AbstractModel model = new Model(view);
        AbstractController controller = new Controller(view, model);
        
        clickButton.onClick.AddListener(()=>
        {
            controller.Click();
        });
    }
}
