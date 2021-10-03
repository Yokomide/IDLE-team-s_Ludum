using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetProviders : MonoBehaviour
{
 public void OnClick()
    {
        ProviderMenuClass.current.CreateList();
    }
}
