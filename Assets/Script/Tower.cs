using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private int lvl;
    private float atk;
    private float range;
    private float shootDelay;
    private float shootTimer;
    

    public string namaTower;

    public Sprite[] lvlTower;
    public AnimationClip show;
    public AnimationClip hide;

    public GameObject enzime;
    private Musuh target;
    private GameObject ui;
    private ListMusuh listMusuh;
    private GameController gameController;
    
    void Start()
    {
        atk = 20;
        range = 3;
        shootDelay = 1f;
        
        
    }
    private void Awake()
    {
        ui = this.transform.Find("UI").gameObject;
        listMusuh = GameObject.Find("ListMusuh").GetComponent<ListMusuh>();
        gameController = GameObject.FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectMusuh();
        if (target != null && target.gameObject.scene.IsValid())
        {
            Shoot();
        }
    }

    public void Build()
    {
        if (gameController.point >= 10)
        {
            gameController.TambahPoint(-10);
            lvl = 1;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = lvlTower[lvl];
        }
    }

    public void UpgradeAtk()
    {
        if (gameController.point >= 5)
        {
            gameController.TambahPoint(-5);
            if (lvl < 3)
            {
                atk += 5; 
                lvl++; 
                this.gameObject.GetComponent<SpriteRenderer>().sprite = lvlTower[lvl];
            }
        }
    }

    public void UpgradeRange()
    {
        if (gameController.point >= 5)
        {
            gameController.TambahPoint(-5);
            range += 0.5f;
        }
    }

    public void Sell()
    {
        if (lvl > 0)
        {
            lvl = 0;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = lvlTower[0];
            range = 3;
            gameController.TambahPoint(5);
        }
        
    }

    public void TutupUi()
    {
        this.gameObject.GetComponent<Animation>().clip = hide;
        this.gameObject.GetComponent<Animation>().Play();
        ui.SetActive(false);
    }

    public void BukaUi()
    {
        ui.SetActive(true);
        this.gameObject.GetComponent<Animation>().clip = show;
        this.gameObject.GetComponent<Animation>().Play();
    }
    public void Shoot()
    {
        if(lvl > 0 && target != null && target.gameObject.scene.IsValid())
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0f)
            {
                shootTimer = shootDelay;
                GameObject peluru = Instantiate(enzime);
                peluru.transform.position = this.transform.position;
                peluru.GetComponent<Enzime>().target = target.nama;
                peluru.gameObject.GetComponent<Enzime>().setTarget(target, atk);
            } 
        }
    }
    public void DetectMusuh()
    {
        if (listMusuh.getMusuh(namaTower).Count >= 1)
        {
            float closest=100;
            foreach(Musuh musuh in listMusuh.getMusuh(namaTower)){
                if(closest > Vector3.Distance(transform.position, musuh.transform.position))
                {
                    closest = Vector3.Distance(transform.position, musuh.transform.position);
                    target = musuh;
                }
            }
            if(Vector3.Distance(transform.position, target.transform.position) > range)
            {
                target = null;
            }

            /*foreach (Musuh musuh in listMusuh.getMusuh(namaTower))
            {
                if (Vector3.Distance(transform.position, musuh.transform.position) < this.range && Vector3.Distance(transform.position, musuh.transform.position) < range)
                {
                    range = Vector3.Distance(transform.position, musuh.transform.position);
                    target = musuh;
                    Debug.Log(Vector3.Distance(transform.position, target.transform.position));
                }
                else target = null;
            }*/
        }
        
    }
}
