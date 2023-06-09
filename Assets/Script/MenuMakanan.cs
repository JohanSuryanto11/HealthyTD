using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMakanan : MonoBehaviour
{
    private GameController gameController;
    public string NamaMakanan;
    public int spawn;

    public float[] gizi;

    public float energi;
    public float karbo;
    public float protein;
    public float lemak;
    public float serat;
    public float vitA;
    public float vitB1;
    public float vitB2;
    public float vitB3;
    public float vitB6;
    public float vitB12;
    public float vitC;
    public float vitD;
    public float vitE;
    public float vitK;
    public float Kalsium;
    public float Fosfor;
    public float Besi;
    public float Natrium;
    public float Kalium;
    public float Tembaga;
    public float Seng;

    public float delayrespawn;

    public GameObject[] musuh;

    float timer = 0f;
    public float multiply;
    public int index;
    public bool hancur;

    private void Start()
    {
        index = 0;
        
    }
    private void Awake()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
    }
    private void Update()
    {
        if (timer <= delayrespawn)
        {
            timer += Time.deltaTime;
        }
        else if (hancur && index <= spawn)
        {
            timer = 0;
            SpawnEnemy(index);
            index++;
        }
        else if(index >= spawn+1)
        {
            gameController.SpawnWave();
            Destroy(this.gameObject);
        }
    }
    private void SpawnEnemy(int index)
    {
        if (gizi[index] != 0)
        {
            GameObject gameObject = Instantiate(this.musuh[index]);
            Musuh musuh = gameObject.GetComponent<Musuh>();
            gameObject.transform.position = this.gameObject.transform.position;
            musuh.currentWaypoint = this.gameObject.GetComponent<Musuh>().currentWaypoint + 1;
            musuh.spawned();
            musuh.gizi = gizi[index]/3;
            musuh.maxHp = 100 * multiply;
            musuh.hp = musuh.maxHp;
        }
        else
        {
            SpawnEnemy(index + 1);
            this.index++;
        }
    }

    public void setmenumakanan(int menu)
    {
        switch (gameController.makanKe)
        {
            case 0:
                {
                    switch (menu)
                    {
                        case 0:
                            {
                                energi = 527.8f;
                                gizi[0] = 65.3f;
                                gizi[1] = 13.1f;
                                gizi[2] = 23.8f;
                                gizi[3] = 100f;
                                gizi[4] = 141.7f;
                                gizi[5] = 0.1f;
                                gizi[6] = 0.2f;
                                gizi[7] = 4.6f;
                                gizi[8] = 0;
                                gizi[9] = 0;
                                gizi[10] = 0.4f;
                                gizi[11] = 0;
                                gizi[12] = 0;
                                gizi[13] = 0;
                                gizi[14] = 118.4f;
                                gizi[15] = 152.5f;
                                gizi[16] = 2.1f;
                                gizi[17] = 1136.9f;
                                gizi[18] = 1107.9f;
                                gizi[19] = 2.3f;
                                gizi[20] = 5.7f;
                                break;
                            }
                        case 1:
                            {
                                energi = 334;
                                gizi[0] = 40.5f;
                                gizi[1] = 15.4f;
                                gizi[2] = 11.1f;
                                gizi[3] = 100f;
                                gizi[4] = 61;
                                gizi[5] = 0.17f;
                                gizi[6] = 0.48f;
                                gizi[7] = 2.8f;
                                gizi[8] = 0.22f;
                                gizi[9] = 0.89f;
                                gizi[10] = 0.4f;
                                gizi[11] = 2;
                                gizi[12] = 1.05f;
                                gizi[13] = 0.3f;
                                gizi[14] = 111;
                                gizi[15] = 285;
                                gizi[16] = 3.4f;
                                gizi[17] = 143;
                                gizi[18] = 156.5f;
                                gizi[19] = 0.26f;
                                gizi[20] = 1.6f;
                                break;
                            }
                        case 2:
                            {
                                energi = 405;
                                gizi[0] = 44.95f;
                                gizi[1] = 4.85f;
                                gizi[2] = 18.5f;
                                gizi[3] = 100f;
                                gizi[4] = 0.2f;
                                gizi[5] = 0.1f;
                                gizi[6] = 0.47f;
                                gizi[7] = 4.1f;
                                gizi[8] = 0.1f;
                                gizi[9] = 0;
                                gizi[10] = 0;
                                gizi[11] = 0;
                                gizi[12] = 0.02f;
                                gizi[13] = 3.9f;
                                gizi[14] = 217.5f;
                                gizi[15] = 302;
                                gizi[16] = 3.9f;
                                gizi[17] = 14;
                                gizi[18] = 355;
                                gizi[19] = 0.54f;
                                gizi[20] = 2.4f;
                                break;
                            }
                    }
                    break;
                }
            case 1:
                {
                    switch (menu)
                    {
                        case 0:
                            {
                                energi = 478;
                                gizi[0] = 39.9f;
                                gizi[1] = 37.2f;
                                gizi[2] = 17.1f;
                                gizi[3] = 100f;
                                gizi[4] = 36;
                                gizi[5] = 0.24f;
                                gizi[6] = 0.1f;
                                gizi[7] = 2.6f;
                                gizi[8] = 0.69f;
                                gizi[9] = 0.37f;
                                gizi[10] = 0;
                                gizi[11] = 0.1f;
                                gizi[12] = 0.42f;
                                gizi[13] = 2.4f;
                                gizi[14] = 115;
                                gizi[15] = 311;
                                gizi[16] = 5.9f;
                                gizi[17] = 742;
                                gizi[18] = 380;
                                gizi[19] = 0.17f;
                                gizi[20] = 1.6f;
                                break;
                            }
                        case 1:
                            {
                                energi = 342;
                                gizi[0] = 49.2f;
                                gizi[1] = 15.9f;
                                gizi[2] = 9;
                                gizi[3] = 100f;
                                gizi[4] = 51;
                                gizi[5] = 0.48f;
                                gizi[6] = 0;
                                gizi[7] = 0;
                                gizi[8] = 0;
                                gizi[9] = 0;
                                gizi[10] = 0;
                                gizi[11] = 0;
                                gizi[12] = 0;
                                gizi[13] = 0;
                                gizi[14] = 858;
                                gizi[15] = 159;
                                gizi[16] = 7.7f;
                                gizi[17] = 2280;
                                gizi[18] = 0;
                                gizi[19] = 0;
                                gizi[20] = 0;
                                break;
                            }
                        case 2:
                            {
                                energi = 276;
                                gizi[0] = 42.3f;
                                gizi[1] = 6.6f;
                                gizi[2] = 9.9f;
                                gizi[3] = 100f;
                                gizi[4] = 0;
                                gizi[5] = 0.24f;
                                gizi[6] = 0;
                                gizi[7] = 0;
                                gizi[8] = 0;
                                gizi[9] = 0;
                                gizi[10] = 9;
                                gizi[11] = 0;
                                gizi[12] = 0;
                                gizi[13] = 0;
                                gizi[14] = 522;
                                gizi[15] = 255;
                                gizi[16] = 7.2f;
                                gizi[17] = 0;
                                gizi[18] = 0;
                                gizi[19] = 0;
                                gizi[20] = 0;
                                break;
                            }
                    }
                    break;
                }
            case 2:
                {
                    switch (menu)
                    {
                        case 0:
                            {
                                energi = 881;
                                gizi[0] = 81.2f;
                                gizi[1] = 17.3f;
                                gizi[2] = 54.1f;
                                gizi[3] = 100f;
                                gizi[4] = 447.5f;
                                gizi[5] = 0.3f;
                                gizi[6] = 0.2f;
                                gizi[7] = 5.6f;
                                gizi[8] = 0;
                                gizi[9] = 0;
                                gizi[10] = 4.8f;
                                gizi[11] = 0;
                                gizi[12] = 0;
                                gizi[13] = 0;
                                gizi[14] = 109.3f;
                                gizi[15] = 213.2f;
                                gizi[16] = 3.1f;
                                gizi[17] = 1592;
                                gizi[18] = 184.5f;
                                gizi[19] = 350.5f;
                                gizi[20] = 1.3f;
                                break;
                            }
                        case 1:
                            {
                                energi = 303;
                                gizi[0] = 29.8f;
                                gizi[1] = 23;
                                gizi[2] = 5.1f;
                                gizi[3] = 100f;
                                gizi[4] = 45;
                                gizi[5] = 0.1f;
                                gizi[6] = 0.2f;
                                gizi[7] = 8.6f;
                                gizi[8] = 0.47f;
                                gizi[9] = 3.4f;
                                gizi[10] = 0;
                                gizi[11] = 0;
                                gizi[12] = 0;
                                gizi[13] = 0;
                                gizi[14] = 309.1f;
                                gizi[15] = 177;
                                gizi[16] = 2.4f;
                                gizi[17] = 68;
                                gizi[18] = 309.1f;
                                gizi[19] = 0.1f;
                                gizi[20] = 1.5f;
                                break;
                            }
                        case 2:
                            {
                                energi = 218;
                                gizi[0] = 51;
                                gizi[1] = 2;
                                gizi[2] = 2.3f;
                                gizi[3] = 100f;
                                gizi[4] = 57;
                                gizi[5] = 0.12f;
                                gizi[6] = 0.15f;
                                gizi[7] = 0.5f;
                                gizi[8] = 0.15f;
                                gizi[9] = 0;
                                gizi[10] = 26;
                                gizi[11] = 0;
                                gizi[12] = 1.08f;
                                gizi[13] = 6.4f;
                                gizi[14] = 4.6f;
                                gizi[15] = 56;
                                gizi[16] = 1.5f;
                                gizi[17] = 15;
                                gizi[18] = 270;
                                gizi[19] = 124.7f;
                                gizi[20] = 0.5f;
                                break;
                            }
                    }
                    break;
                }
        }
    }
}
