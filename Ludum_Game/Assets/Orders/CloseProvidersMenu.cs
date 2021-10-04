using UnityEngine;
using UnityEngine.UI;

public class CloseProvidersMenu : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.current.foodCanvas.GetComponent<Canvas>().targetDisplay = 1;
        GameManager.current.orderCanvas.GetComponent<Canvas>().targetDisplay = 1;
        GameManager.current.foodCanvas.GetComponent<GraphicRaycaster>().enabled = false;
        GameManager.current.orderCanvas.GetComponent<GraphicRaycaster>().enabled = false;
    }
}
