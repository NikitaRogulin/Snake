using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FoodSpawn : MonoBehaviour
{
    public Food prefabFood;
    private const float hightBorder = 14f;
    private const float widthBorder = 17f;

    private void Start()
    {
        MakeFood();
    }

    private Vector2 RandomPosition()
    {
        return new Vector2(Random.Range(-widthBorder, widthBorder), Random.Range(-hightBorder, hightBorder));
    }

    public void MakeFood()
    {
        RandomPosition();
        var food = Instantiate(prefabFood, RandomPosition(), Quaternion.identity);
        food.Eaten.AddListener(MakeFood);

    }
}
