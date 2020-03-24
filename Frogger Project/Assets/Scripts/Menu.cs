using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	[SerializeField]
    private GameObject Choose;
    [SerializeField]
    private GameObject Basic;

    // Wczytanie nazw poziomow 
    public string level1, level2, level3;

    // Trzy funcje wczytujace poszczegolne poziomy
    public void LevelOpen1()
    {
        SceneManager.LoadScene(level1);
        Time.timeScale = 1;
        Score.totallPointAmount = 0;
        Score.pointAmount = 0;
    }
    public void LevelOpen2()
    {
        SceneManager.LoadScene(level2);
        Time.timeScale = 1;
        Score.totallPointAmount = 0;
        Score.pointAmount = 0;
    }
    public void LevelOpen3()
    {
        SceneManager.LoadScene(level3);
        Time.timeScale = 1;
        Score.totallPointAmount = 0;
        Score.pointAmount = 0;
    }

    // Funkcja zamykająca aplikacje
    public void Quit()
    {
        Debug.Log("zamykanie aplikacji");
        Application.Quit();
    }

    // Dwie funcje aktywujace i dezaktywujące panel wyboru poziomow
    public void ChooseLevel()
    {
        Choose.SetActive(true);
        Basic.SetActive(false);
    }
    public void ChooseLevelExit()
    {
        Choose.SetActive(false);
        Basic.SetActive(true);
    }
}
