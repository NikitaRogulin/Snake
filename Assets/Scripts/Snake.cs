﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField]
    float speed = 2.5f;
    [SerializeField]
    float distance = 1.8f;
    [SerializeField]
    List<Transform> body;
    Vector3 direction = new Vector3(0, 1, 0);
    [SerializeField]
    GameObject prefabBone;

    void Update()
    {
        transform.position = transform.position + direction * Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.W))
        {
            direction = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction = Vector3.down;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction = Vector3.right;
        }

        Vector3 oldPosition = transform.position;

        foreach (Transform bone in body)
        {
            if ((bone.position - oldPosition).magnitude > distance)
            {
                bone.position = bone.position + (oldPosition - bone.position) * Time.deltaTime * speed;
                oldPosition = bone.position;
            }
            else
            {
                break;
            }
        }
    }
    private void OnCollision(Collision2D collision)
    {
        if (collision.gameObject.tag == "Food")
            GrowUp();
        //else if (collision.gameObject.tag == "Bone")
        //{
        //    Destroy(gameObject);
        //    for(int i = 0; i < body.Count; i++)
        //    {
        //        Destroy(body[i]);
        //    }
        //}
    }

    void GrowUp()
    {
        GameObject newBone = Instantiate(prefabBone, body[body.Count - 1].position,Quaternion.identity);
        speed += 1f; 
        body.Add(newBone.transform);
    }
}