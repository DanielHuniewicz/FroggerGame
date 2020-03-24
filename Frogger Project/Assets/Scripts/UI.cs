using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    // Wczytanie obiektow gry
    [SerializeField]
    private GameObject WinGame;
    [SerializeField]
    private GameObject Pause;
    [SerializeField]
    private GameObject Lose;
    public string levelToLoad;
    [SerializeField]
    public string loadMenu;
    [SerializeField]

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Pause.activeSelf)
        {
            QuitPause();
        }
    }

    // Funkcja zaladowywujaca biezacy poziom na nowo z odpowiednio ustawionymi parametrami
    public void Retry()
    {
        Lose.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Score.totallPointAmount = 0;
        Score.pointAmount = 0;
    }

    // Funkcja przenoszaca do sceny menu
    public void Menu()
    {
        SceneManager.LoadScene(loadMenu);
    }

    // Funkcja zaladowywujaca wybrany poziom z odpowiednio ustawionymi parametrami
    public void NextLvl()
    {
        SceneManager.LoadScene(levelToLoad);
        Time.timeScale = 1;
        Score.totallPointAmount = 0;
        Score.pointAmount = 0;
    }

    // Trzy funkcje aktywacji paneli UI
    public void QuitPause()
    {
        Pause.SetActive(false);
        Time.timeScale = 1;
    }
    public void LosePanel() 
    {
        Lose.SetActive(true);
        Time.timeScale = 0;
    }
    public void WinGamePanel()
    {
        WinGame.SetActive(true);
        Time.timeScale = 0;
    }
}
