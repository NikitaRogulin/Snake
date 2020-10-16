using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Food : MonoBehaviour
{
    public UnityEvent Eaten;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Head")
        {
            Eaten.Invoke();
            Destroy(gameObject);
        }
    }
}
