using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItems : MonoBehaviour
{
    public int total = 7;
    public Text itemText;

    void Update() {
        itemText.text = current.ToString() + "x";
    }

    int current = 0;

    public int getCurrentItems()
    {
        return current;
    }

    public void AddItem()
    {
        current = Mathf.Clamp(current + 1, 0, total);
    }

    public void RemoveItem()
    {
        current = Mathf.Clamp(current - 1, 0, total);
    }

}