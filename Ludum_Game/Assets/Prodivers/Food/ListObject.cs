using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "List", menuName = "ListObject/List")]
public class ListObject : ScriptableObject
{

    public List<FoodScriptableObject> list = new List<FoodScriptableObject>();

}
