using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject GOPanel;
    public GameObject StartPanel;
    public GameObject GameOverlay;
    public GameObject WinScreen;
    public enum STATES {
        INGAME,
        PAUSE,
        DEAD,
        START,
        WIN
    };
    public STATES GameState;

    public void setGameState(STATES state) {
        GameState = state;
    }

    void Start()
    {
        GameState = STATES.START;
    }

    void CleanScreen()
    {
        GOPanel.SetActive(false);
        StartPanel.SetActive(false);
        GameOverlay.SetActive(false);
        WinScreen.SetActive(false);
    }
    public void GameOver()
    {
        GOPanel.SetActive(true);
    }

    public void StartMenu()
    {
        StartPanel.SetActive(true);
    }

    public void WinGame()
    {
        WinScreen.SetActive(true);
    }

    void Game()
    {
        GameOverlay.SetActive(true);
    }

    void Update()
    {
        CleanScreen();
        if (GameState == STATES.START)
            StartMenu();
        if (GameState == STATES.DEAD)
            GameOver();
        if (GameState == STATES.INGAME)
            Game();
        if (GameState == STATES.WIN)
            WinGame();
    }

}