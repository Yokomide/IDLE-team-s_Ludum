using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action OnSchizoRise;
    public event Action OnSchizoDecrease;
    public event Action OnSchizoAction;

    public void SchizoRise() => OnSchizoRise?.Invoke();
    public void SchizoDecrease() => OnSchizoDecrease?.Invoke();
    public void SchizoAction() => OnSchizoAction?.Invoke();
}
