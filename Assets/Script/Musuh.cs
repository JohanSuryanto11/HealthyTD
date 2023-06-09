using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Musuh : MonoBehaviour
{
    public string nama;
    public GameObject[] hasil;

    private ListMusuh listMusuh;
    private WaypointsHolder waypoints;
    public  int currentWaypoint;
    public float hp;
    public float maxHp;
    public float speed;
    private int currentPutaran;
    private int putaranLambung;
    private float breakDelay;
    
    public float gizi;
    private Slider uiHp;
    private Color lowHp;
    private Color highHp;
    private Vector3 offsetUiHp;
    private GameController gameController;
    private Vector3 target;
    private GiziUI Gizi;
    public bool stop ; //buat musuh berhenti jika sudah sampai di akhir waypointstage
    private int indexHasil;
    public bool doonce; //gizi

    void Start()
    {
        breakDelay = 0.5f;
        indexHasil = 0;
        speed = 1f;
        putaranLambung = 2;
        uiHp = this.gameObject.GetComponentInChildren<Slider>();
        lowHp = Color.red;
        highHp = Color.green;
        offsetUiHp = new Vector3(0, 0.5f, 0);
        
        
    }
    private void Awake()
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
        waypoints = GameObject.Find("WaypointsHolder").GetComponent<WaypointsHolder>();
        listMusuh = GameObject.Find("ListMusuh").GetComponent<ListMusuh>();
        Gizi = GameObject.FindObjectOfType<GiziUI>();
        listMusuh.AddEnemy(nama, this);
    }
    // Update is called once per frame
    void Update()
    {
        MovementUiHp();
        SetHealth();
        if (hp < 1) {
            if (nama.Equals("Feses"))
            {
                listMusuh.RemoveEnemy(nama,this);
                uiHp.gameObject.SetActive(false);
            }
            else
            {
                BreakBehaviour();
            }
            
        }
        if (!stop)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        MovementBehaviour();

    }

    private void BreakBehaviour()
    {
        breakDelay -= Time.deltaTime;
        speed = 0;
        if (breakDelay <= 0f)
        {
            if (hasil.Length > indexHasil)
            {
                GameObject jadi = Instantiate(hasil[indexHasil]);
                jadi.gameObject.GetComponent<Musuh>().putaranLambung = putaranLambung;
                jadi.gameObject.GetComponent<Musuh>().currentWaypoint = currentWaypoint;
                jadi.gameObject.GetComponent<Musuh>().spawned();
                jadi.gameObject.GetComponent<Musuh>().gizi = gizi / this.hasil.Length;
                jadi.gameObject.transform.position = this.gameObject.transform.position;

                indexHasil++;
                breakDelay = 0.5f;
            }
            else
            {
                gameController.TambahScore(1000);
                gameController.TambahPoint(10);
                listMusuh.RemoveEnemy(nama, this); 
                GiziTerserap();
                Destroy(this.gameObject);
            }
        }
    }

    private void CekMusuh()
    {
        if (gameController.wave == 3)
        {
            bool checkwaypoints = false;
            foreach (Musuh musuh in GameObject.FindObjectsOfType<Musuh>())
            {
                if (musuh.currentWaypoint == gameController.waypointStage[gameController.stage])
                {
                    checkwaypoints = true;
                }
                else
                {
                    checkwaypoints = false;
                    break;
                }
            }
            if (checkwaypoints) gameController.NextStage();
        }
    }

    public void SetHealth()
    {
        uiHp.enabled = true;
        uiHp.gameObject.SetActive(hp < maxHp);
        uiHp.value = hp;
        uiHp.maxValue = maxHp;
        uiHp.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(lowHp, highHp, uiHp.normalizedValue);
    }
    private void MovementUiHp()
    {
        uiHp.transform.position = Camera.main.WorldToScreenPoint(transform.position + offsetUiHp);
    }

    public void GotHit(float dmg)
    {
        hp -= dmg;
        if (nama.Equals("Feses"))
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, new Color(0,255,255), hp/maxHp);
        }
    }

    public void spawned()
    {
        target = waypoints.Waypoints[currentWaypoint].position;
    }

    public void QueuMovement()
    {
        gameObject.transform.position = waypoints.Waypoints[currentWaypoint].position;
        currentWaypoint++;
        target = waypoints.Waypoints[currentWaypoint].position;
    }

    private void MovementBehaviour()
    {
        if (gameController.waypointStage[gameController.stage] == currentWaypoint&&!stop)
        {
            stop = true;
            gameController.AddQueu(this);
            CekMusuh();
        }
        if (gameController.stage == 2)
        {
            if (putaranLambung >= currentPutaran&&currentWaypoint==23)
            {
                currentWaypoint = 15;
                currentPutaran++;
                target = waypoints.Waypoints[currentWaypoint].position;
            }else if( currentWaypoint == 20)
            {
                currentWaypoint = 23;
                target = waypoints.Waypoints[currentWaypoint].position;
            }

        }
        if (Vector2.Distance(this.transform.position, waypoints.Waypoints[currentWaypoint].position) < 0.1f&&!stop)
        {
            if (currentWaypoint < waypoints.Waypoints.Length - 1)
            {
                currentWaypoint += 1;
                target = waypoints.Waypoints[currentWaypoint].position;
            }
            else
            {
                if (nama.Equals("Feses"))
                {
                    if (hp < 1)
                    {
                        gameController.TambahScore(1000);
                    }
                }
                else
                {
                    gameController.TambahScore(-1000);
                }
                listMusuh.RemoveEnemy(nama, this);
                if (GameObject.FindObjectsOfType<Musuh>().Length == 1)
                {
                    gameController.makanKe++;
                    if (gameController.makanKe >= 2)
                    {
                        gameController.GameOver();
                    }
                    else
                    {
                        gameController.stageBehavior(0);
                        PlayerPrefs.SetInt("ususbesar", 1);
                    }
                }
                Destroy(gameObject);
            }
        }
    }

    private void GiziTerserap()
    {
        if (!doonce)
        {
            doonce = true;
            switch (nama)
            {
                case "AsamLemak":
                    {
                        Gizi.setlemak(gizi);
                        break;
                    }
                case "Gliserol":
                    {
                        Gizi.setlemak(gizi);
                        break;
                    }
                case "Fruktosa":
                    {
                        Gizi.setkarbo(gizi);
                        break;
                    }
                case "Galaktosa":
                    {
                        Gizi.setkarbo(gizi);
                        break;
                    }
                case "Glukosa":
                    {
                        Gizi.setkarbo(gizi);
                        break;
                    }
                case "Asamamino":
                    {
                        Gizi.setprotein(gizi);
                        break;
                    }
                case "Besi":
                    {
                        Gizi.setbesi(gizi);
                        break;
                    }
                case "Fosfor":
                    {
                        Gizi.setfosfor(gizi);
                        break;
                    }
                case "Kalium":
                    {
                        Gizi.setkalium(gizi);
                        break;
                    }
                case "Kalsium":
                    {
                        Gizi.setkalsium(gizi);
                        break;
                    }
                case "Natrium":
                    {
                        Gizi.setnatrium(gizi);
                        break;
                    }
                case "Seng":
                    {
                        Gizi.setseng(gizi);
                        break;
                    }
                case "Tembaga":
                    {
                        Gizi.settembaga(gizi);
                        break;
                    }
                case "VitA":
                    {
                        Gizi.setvita(gizi);
                        break;
                    }
                case "VitB1":
                    {
                        Gizi.setvitb1(gizi);
                        break;
                    }
                case "VitB2":
                    {
                        Gizi.setvitb2(gizi);
                        break;
                    }
                case "VitB3":
                    {
                        Gizi.setvitb3(gizi);
                        break;
                    }
                case "VitB6":
                    {
                        Gizi.setvitb6(gizi);
                        break;
                    }
                case "VitB12":
                    {
                        Gizi.setvitb12(gizi);
                        break;
                    }
                case "VitC":
                    {
                        Gizi.setvitC(gizi);
                        break;
                    }
                case "VitD":
                    {
                        Gizi.setvitD(gizi);
                        break;
                    }
                case "VitE":
                    {
                        Gizi.setvitE(gizi);
                        break;
                    }
                case "VitK":
                    {
                        Gizi.setvitK(gizi);
                        break;
                    }
                default:
                    {

                        break;
                    }
            }
        }
    }
}
