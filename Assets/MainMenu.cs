using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject caraBermain;

    public GameObject scoreBoards;
    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI score3;
    public TextMeshProUGUI score4;
    public TextMeshProUGUI score5;

    public GameObject achievements;
    public Image acievement1;
    public Image acievement2;
    public Image acievement3;
    public Image acievement4;
    public Image acievement5;
    public Image acievement6;

    public GameObject pilihKesulitan;

    private int score;
    void Start()
    {
        caraBermain.SetActive(false);
        scoreBoards.SetActive(false);
        achievements.SetActive(false);
        mainMenu.SetActive(true);

        this.score = 1600;

        
    }
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MulaiPermainan()
    {

    }
    public void CaraBermain()
    {
        caraBermain.SetActive(true);
    }

    public void ScoreBoards()
    {
        scoreBoards.SetActive(true);
        mainMenu.SetActive(false);
        score1.text = PlayerPrefs.GetString("nama1") +" "+ PlayerPrefs.GetInt("score1");
        score2.text = PlayerPrefs.GetString("nama2") + " " + PlayerPrefs.GetInt("score2");
        score3.text = PlayerPrefs.GetString("nama3") + " " + PlayerPrefs.GetInt("score3");
        score4.text = PlayerPrefs.GetString("nama4") + " " + PlayerPrefs.GetInt("score4");
        score5.text = PlayerPrefs.GetString("nama5") + " " + PlayerPrefs.GetInt("score5");
    }

    public void Achievement()
    {
        achievements.SetActive(true);
        if (PlayerPrefs.GetInt("mulut") == 1)
        {
            acievement1.color = Color.white;
        }
        if (PlayerPrefs.GetInt("lambung") == 1)
        {
            acievement2.color = Color.white;
        }
        if (PlayerPrefs.GetInt("ususduabelasjari") == 1)
        {
            acievement3.color = Color.white;
        }
        if (PlayerPrefs.GetInt("ususkecil") == 1)
        {
            acievement4.color = Color.white;
        }
        if (PlayerPrefs.GetInt("ususbesar") == 1)
        {
            acievement5.color = Color.white;
        }
        if (PlayerPrefs.GetInt("4sehat5sempurna") == 1)
        {
            acievement6.color = Color.white;
        }

    }

    public void Sulit()
    {
        PlayerPrefs.SetInt("kesulitan", 1);
        SceneManager.LoadScene("Main Scene");
    }
    public void Sedang()
    {
        PlayerPrefs.SetInt("kesulitan", 0);
        SceneManager.LoadScene("Main Scene");
    }
    public void PilihKesulitan()
    {
        pilihKesulitan.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void KembaliKeMainMenu()
    {
        caraBermain.SetActive(false);
        scoreBoards.SetActive(false);
        achievements.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void Keluar()
    {
        Application.Quit();
    }
}
