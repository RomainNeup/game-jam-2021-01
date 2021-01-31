using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject GOPanel;

    void Start()
    {
        GOPanel.SetActive(false);
    }

    void GameOver()
    {
        GOPanel.SetActive(true);
    }

    void Update()
    {

    }

}