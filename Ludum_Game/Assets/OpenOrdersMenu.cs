using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenOrdersMenu : MonoBehaviour
{

    public void OnClick()
    {
        GameManager.current.foodCanvas.GetComponent<Canvas>().targetDisplay = 1;
        GameManager.current.orderCanvas.GetComponent<Canvas>().targetDisplay = 0;
        GameManager.current.foodCanvas.GetComponent<GraphicRaycaster>().enabled = false;
        GameManager.current.orderCanvas.GetComponent<GraphicRaycaster>().enabled = true;
    }
}
