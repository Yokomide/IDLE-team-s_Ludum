using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "food", menuName = "FoodObject/Food")]
public class FoodScriptableObject : ScriptableObject
{
    public string foodName;
    public bool isRotten;
    public Sprite sprite;

}
