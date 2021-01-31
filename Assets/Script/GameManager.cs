using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject GOPanel;
    public GameObject StartPanel;
    public GameObject GameOverlay;

    void Start()
    {
        CleanScreen();
        StartMenu();
    }

    void CleanScreen()
    {
        GOPanel.SetActive(false);
        StartPanel.SetActive(false);
        GameOverlay.SetActive(false);
    }
    void GameOver()
    {
        CleanScreen();
        GOPanel.SetActive(true);
    }

    void StartMenu()
    {
        CleanScreen();
        StartPanel.SetActive(true);
    }

    void Game()
    {
        CleanScreen();
        GameOverlay.SetActive(true);
    }

    void Update()
    {

    }

}