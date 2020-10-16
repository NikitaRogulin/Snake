using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextListener : MonoBehaviour
{
    public void OnValueChange(string text)
    {
        GetComponent<Text>().text = text;
    }
}
