using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public GameObject prefabFood;
    private float hightBorder = 14f;
    private float widthBorder = 17f;
    public GameObject currentFood;
    public Vector3 currentPositionFood;

    void Start()
    {
        MakeFood();
    }

    void RandomPosition()
    {
        currentPositionFood = new Vector2(Random.Range(-widthBorder, widthBorder), Random.Range(-hightBorder, hightBorder));
    }
    void MakeFood()
    {
        RandomPosition();
        currentFood = Instantiate(prefabFood, currentPositionFood, Quaternion.identity);
    }
    void Update()
    {
        if(currentFood == null)
        {
            MakeFood();
        }
    }
}
