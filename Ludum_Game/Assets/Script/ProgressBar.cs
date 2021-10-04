using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    public Text FoodQuality;
    public Text status;
    public Slider slider;
    public Vector3 offsetSlider;
    public Vector3 offsetStatus;
    public Vector3 offsetMessage;
    public Image fill;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offsetSlider);
        status.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offsetStatus);
        FoodQuality.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offsetMessage);
    }
    public void FillSlider(float a)
    {
        slider.value = a * 0.1f;
    }
}
