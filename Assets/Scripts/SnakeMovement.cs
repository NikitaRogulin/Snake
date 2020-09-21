using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float speed = 2f;
    public float distance = -0.5f;
    public float speedRotate = 150f;
    public List<GameObject> tails;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0,0,1) * speedRotate * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0, -1) * speedRotate * Time.deltaTime);
        }
    }
}
