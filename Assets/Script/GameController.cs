using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class GameController : MonoBehaviour
{
    private GameObject mainCamera;
    public int menu;
    public int kesulitan;
    public int score;
    public int point;
    public int stage;
    public int makanKe;
    public GameObject kunyahButton;
    public int kunyahTotal;
    public bool start;
    private bool queuState;
    public  int wave;
    private int queuIndex;
    private MenuMakanan menuMakanan;
    private float queuTimer;
    private GameObject mulai;
    private UIMenuMakanan uIMenuMakanan;
    public GameObject gameOver;
    
    public int[] waypointStage;
    private WaypointsHolder waypoints;
    public List<Musuh> queu = new List<Musuh> ();
    public List<Musuh> queu2 = new List<Musuh>();
    public List<Musuh> queu3 = new List<Musuh>();
    public List<Musuh> queu4 = new List<Musuh>();

    public TextMeshProUGUI tPoint;
    public TextMeshProUGUI tScore;

    public GameObject[] gigi;

    public GameObject makanan;

    public GameObject keMainMenu;
    public TextMeshProUGUI fscoreGO;
    public TMP_InputField nama;
    public GiziUI giziUI;

    void Start()
    {
        queuTimer = 2;
        queuIndex = 0;
        queuState = false;
        TambahPoint(80);
        stageBehavior(stage);
        
    }
    private void Awake()
    {
        mainCamera = GameObject.FindObjectOfType<Camera>().gameObject;
        kesulitan = PlayerPrefs.GetInt("kesulitan");
        waypoints = GameObject.FindObjectOfType<WaypointsHolder>();
        uIMenuMakanan = GameObject.FindObjectOfType<UIMenuMakanan>();
        mulai = GameObject.Find("Mulai");
        
    }

    // Update is called once per frame
    void Update()
    {
        ClickBehavior();
        QueuBehavior(queuState);
    }

    public void ShowKunyahButton()
    {
        kunyahButton.gameObject.SetActive(true);
    }
    public void Kunyah()
    {
        kunyahTotal++;
        GameObject.Find("Jumlah Kunyah").GetComponent<TextMeshProUGUI>().text = "Kunyah " + kunyahTotal + " X";
        GameObject.Find("Jumlah Kunyah").GetComponent<Animation>().Play();
        gigi[0].GetComponent<Gigi>().anim(new Vector2(-7.368f, -1.92f));
        gigi[1].GetComponent<Gigi>().anim(new Vector2(-7.176f, -2.545f));
    }

    public void Terkunyah()
    {
        if (kunyahTotal > 31 && kunyahTotal < 34)
        {
            GameObject.FindObjectOfType<MenuMakanan>().multiply = 1;
            TambahScore(10000);
            TambahPoint(10);
        }
        else if (kunyahTotal < 31 & kunyahTotal > 20)
        {
            GameObject.FindObjectOfType<MenuMakanan>().multiply = 1.3f;
            TambahScore(5000);
        }
        else if (kunyahTotal < 20 && kunyahTotal > 10)
        {
            GameObject.FindObjectOfType<MenuMakanan>().multiply = 1.5f;
            TambahScore(1000);
        }
        else if (kunyahTotal < 10)
        {
            GameObject.FindObjectOfType<MenuMakanan>().multiply = 2;
        }
        kunyahTotal = 0;
        GameObject.Find("Jumlah Kunyah").GetComponent<TextMeshProUGUI>().text = "Kunyah " + kunyahTotal + " X";
        kunyahButton.SetActive(false);
        //spawnenemy
    }

    public void SpawnWave()
    {
        if (wave < 3)
        {
            GameObject gameObject = Instantiate(makanan);
            if (kesulitan == 1)
            {
                gameObject.GetComponent<MenuMakanan>().spawn = 20;
            }
            else gameObject.GetComponent<MenuMakanan>().spawn = 3;
            gameObject.GetComponent<MenuMakanan>().setmenumakanan(this.menu);
            gameObject.transform.position = waypoints.Waypoints[0].position;
            wave++;
        }
    }
    public void AddQueu(Musuh musuh)
    {
        switch (stage) {

            case 1:
                {
                    queu.Add(musuh);
                    break;
                }
            case 2:
                {
                    queu2.Add(musuh);
                    break;
                }
            case 3:
                {
                    queu3.Add(musuh);
                    break;
                }
            case 4:
                {
                    queu4.Add(musuh);
                    break;
                }
            case 5:
                {
                    
                    break;
                }
        }
    }

    

    public void PilihMenuMakanan(int menu)
    {
        this.menu = menu;
        mulai.SetActive(true);
        mainCamera.transform.position = new Vector3(0, 0, -10);
        uIMenuMakanan.gameObject.SetActive(false);
    }
    private void QueuBehavior(bool state)
    {
        if (state)
        {
            queuTimer -= Time.deltaTime;
            if (queuTimer <= 0f)
            {
                switch (stage)
                {
                    case 2:
                        {
                            if (queu.Count != queuIndex)
                            {
                                queu[queuIndex].stop = false;
                                queu[queuIndex].QueuMovement();
                                queuTimer = 2;
                                queuIndex++;
                            }
                            else
                            {
                                queuState = false;
                                queuIndex = 0;
                                queu.Clear();
                            }
                            break;
                        }
                    case 3:
                        {
                            if (queu2.Count != queuIndex)
                            {
                                queu2[queuIndex].stop = false;
                                queu2[queuIndex].QueuMovement();
                                queuTimer = 2;
                                queuIndex++;
                            }
                            else
                            {
                                queuState = false;
                                queuIndex = 0;
                                queu2.Clear();
                            }
                            break;
                        }
                    case 4:
                        {
                            if (queu3.Count != queuIndex)
                            {
                                queu3[queuIndex].stop = false;
                                queu3[queuIndex].QueuMovement();
                                queuTimer = 2;
                                queuIndex++;
                            }
                            else
                            {
                                queuState = false;
                                queuIndex = 0;
                                queu3.Clear();
                            }
                            break;
                        }
                    case 5:
                        {
                            if (queu4.Count != queuIndex)
                            {
                                queu4[queuIndex].stop = false;
                                queu4[queuIndex].QueuMovement();
                                queuTimer = 2;
                                queuIndex++;
                            }
                            else
                            {
                                queuState = false;
                                queuIndex = 0;
                                queu4.Clear();
                            }
                            break;
                        }
                }
                Debug.Log("queu");
                
            }
        }
    }

    public void stageBehavior(int stage)
    {
        switch (stage)
        {
            case 0:
                {
                    mulai.GetComponent<RectTransform>().anchoredPosition = new Vector3(-870.2f, -215.6f, 0);
                    uIMenuMakanan.gameObject.SetActive(true);
                    uIMenuMakanan.gantimenu(makanKe);
                    this.stage++;
                    break;
                }
            case 1:
                {
                    mulai.GetComponent<RectTransform>().anchoredPosition = new Vector3(-870.2f, -215.6f, 0);
                    mainCamera.transform.position = new Vector3(0, 0, -10);
                    break;
                }
            case 2:
                {
                    mulai.GetComponent<RectTransform>().anchoredPosition = new Vector3(91f, 422, 0);
                    mainCamera.transform.position = new Vector3(27.21f, 0,-10);
                    PlayerPrefs.SetInt("mulut", 1);
                    break;
                }
            case 3:
                {
                    mulai.GetComponent<RectTransform>().anchoredPosition = new Vector3(-910, 184, 0);
                    mainCamera.transform.position = new Vector3(54.82f, 0, -10);
                    PlayerPrefs.SetInt("lambung", 1);
                    break;
                }
            case 4:
                {
                    mulai.GetComponent<RectTransform>().anchoredPosition = new Vector3(40, 490f, 0);
                    mainCamera.transform.position = new Vector3(79.7f, 0, -10);
                    PlayerPrefs.SetInt("ususduabelasjari", 1);
                    break;
                }
            case 5:
                {
                    mulai.GetComponent<RectTransform>().anchoredPosition = new Vector3(-285, -268, 0);
                    mainCamera.transform.position = new Vector3(105.1f, 0, -10);
                    PlayerPrefs.SetInt("ususkecil", 1);
                    break;
                }

        }
    }

    
    public void NextStage()
    {
        stage++;
        mulai.SetActive(true);
        
        stageBehavior(stage);
    }

    public void Mulai()
    {
        if (stage == 1)
        {
            SpawnWave();
        }else
        {
            queuState = true;
            //mulaiqueu
        }
        mulai.SetActive(false);
    }

    private void ClickBehavior()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.transform.root.TryGetComponent(out Tower tower))
                {
                    switch (hit.collider.name)
                    {
                        case "Build":
                            {
                                hit.collider.transform.root.GetComponent<Tower>().Build();
                                break;
                            }
                        case "UpgradeAtk":
                            {
                                hit.collider.transform.root.GetComponent<Tower>().UpgradeAtk();
                                break;
                            }
                        case "UpgradeRange":
                            {
                                hit.collider.transform.root.GetComponent<Tower>().UpgradeRange();
                                break;
                            }
                        case "Sell":
                            {
                                hit.collider.transform.root.GetComponent<Tower>().Sell();
                                break;
                            }
                        default:
                            {
                                hit.collider.GetComponent<Tower>().BukaUi();
                                break;
                            }
                    }
                }
            }
            else
            {
                foreach (Tower alltower in (Tower[])GameObject.FindObjectsOfType(typeof(Tower)))
                {
                    alltower.TutupUi();
                }
            }
        }
    }
    public void test()
    {
        makanKe++;
        uIMenuMakanan.gantimenu(makanKe);
    }

    public void TambahScore(int score)
    {
        this.score += score;
        tScore.text = this.score.ToString();
    }
    
    public void TambahPoint(int point)
    {
        this.point += point;
        tPoint.text = this.point.ToString();
    }

    public void GameOver()
    {
        score += giziUI.kalkulasigizi();
        fscoreGO.text = "Score : " + score;
        gameOver.SetActive(true);
    }
    public void KeMainMenu()
    {
        //highscore
        int[] score = new int[5];
        string[] nama = new string[5];
        score[0] = PlayerPrefs.GetInt("score1");
        score[1] = PlayerPrefs.GetInt("score2");
        score[2] = PlayerPrefs.GetInt("score3");
        score[3] = PlayerPrefs.GetInt("score4");
        score[4] = PlayerPrefs.GetInt("score5");
        nama[0] = PlayerPrefs.GetString("nama1");
        nama[1] = PlayerPrefs.GetString("nama2");
        nama[2] = PlayerPrefs.GetString("nama3");
        nama[3] = PlayerPrefs.GetString("nama4");
        nama[4] = PlayerPrefs.GetString("nama5");


        for (int i = 0; i < score.Length; i++)
        {
            if (this.score > score[i])
            {
                for (int j = score.Length - 1; j > i; j--)
                {
                    score[j] = score[j - 1];
                    nama[j] = nama[j - 1];
                }
                score[i] = this.score;
                nama[i] = this.nama.text;
                break;
            }
        }
        PlayerPrefs.SetInt("score1", score[0]);
        PlayerPrefs.SetInt("score2", score[1]);
        PlayerPrefs.SetInt("score3", score[2]);
        PlayerPrefs.SetInt("score4", score[3]);
        PlayerPrefs.SetInt("score5", score[4]);
        PlayerPrefs.SetString("nama1", nama[0]);
        PlayerPrefs.SetString("nama2", nama[1]);
        PlayerPrefs.SetString("nama3", nama[2]);
        PlayerPrefs.SetString("nama4", nama[3]);
        PlayerPrefs.SetString("nama5", nama[4]);
        SceneManager.LoadScene("Main Menu");
    }
}

