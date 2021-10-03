using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float Money = 1000;
    public static float Reputation = 4.9f;
    public static float MindStatePoints = 25;
    public static bool isCrazy = false;
    [SerializeField] private float minNum;
    [SerializeField] private float maxNum;

    private float _timer = 0;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (Convert.ToInt32(_timer) / 3 >= 1)
        {
            //что-то происходит
            _timer = 0;
        }



    }

    public static void AddSchizo(float num)
    {

    }
    public static void AddSchizo()
    {
        float num = UnityEngine.Random.Range(10, 20);
    }

    public static void RemoveSchizo(float num)
    {

    }

    public static void RemoveSchizo()
    {
        float num = UnityEngine.Random.Range(10, 20);
    }

}
