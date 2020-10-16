using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Snake : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float distance = 1.8f;
    [SerializeField] private List<Transform> body;
    Vector3 direction = new Vector3(0, 1, 0);
    [SerializeField]
    GameObject prefabBone;

    public UnityEvent EatFood;
    public UnityEvent SnakeIsDead;

    void Update()
    {
        transform.position = transform.position + direction * Time.deltaTime * speed;

        if (Input.GetAxis("Vertical") > 0)
        {
            direction = Vector3.up;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            direction = Vector3.down;
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            direction = Vector3.left;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            direction = Vector3.right;
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }

        Vector3 oldPosition = transform.position;

        foreach (Transform bone in body)
        {
            bone.rotation = Quaternion.LookRotation(Vector3.forward, oldPosition - bone.position);
            if ((bone.position - oldPosition).magnitude > distance)
            {
                bone.position = bone.position + (oldPosition - bone.position) * Time.deltaTime * speed;
                oldPosition = bone.position;
            }
            else
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            GrowUp();
            EatFood.Invoke();
        }
        else if (collision.gameObject.tag == "Bone" || collision.gameObject.tag == "Border")
        {
            StartCoroutine(BoneDestroy());
            SnakeIsDead.Invoke();
        }
    }

    void GrowUp()
    {
        GameObject newBone = Instantiate(prefabBone, body[body.Count - 1].position,Quaternion.identity);
        speed += 1f;
        body.Add(newBone.transform);
    }

    IEnumerator BoneDestroy()
    {
        speed = 0f;

        while (body.Count != 0)
        {
            Destroy(body[0].gameObject);
            body.RemoveAt(0);
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
    }
}
