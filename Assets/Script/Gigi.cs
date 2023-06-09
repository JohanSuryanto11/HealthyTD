using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gigi : MonoBehaviour
{

    public float m_startingMinutes = 10.0f; //in seconds
    public bool m_startTimer = false;
    public TextMeshProUGUI m_timerLabel;

    private MenuMakanan menu;

    private float m_miliseconds;
    private float m_seconds;
    private float m_mins;
    private float m_totalmiliseconds;
    private GameController gameController;
    Vector3 target;
    Vector3 posisiawal;
    bool posisi;
    void Start()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
        posisiawal = transform.position;
        target = posisiawal;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position != target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, 5f * Time.deltaTime);
        }
        else target = posisiawal;

        Timer(m_startTimer);
    }


    public void anim(Vector2 target)
    {
        this.target = target;
    }

    public void Timer(bool start)
    {
        if (m_startTimer)
        {
            if (m_totalmiliseconds >= 2)
            {
                if (m_miliseconds <= 0)
                {
                    if (m_seconds <= 0)
                    {
                        m_mins--;
                        m_seconds = 59;
                    }
                    else
                    {
                        m_seconds--;
                    }
                    m_miliseconds = 99;
                }

                m_miliseconds -= Time.deltaTime * 100;
                m_totalmiliseconds -= Time.deltaTime * 100;
            }
            else if (m_totalmiliseconds <= 2)
            {
                gameController.Terkunyah();
                m_startTimer = false;
                menu.hancur = true;
            }

            if ((int)m_miliseconds > 9)
            {
                m_timerLabel.text = string.Format("{0}:{1}:{2}", m_mins, m_seconds, (int)m_miliseconds);
            }
            else
            {
                m_timerLabel.text = string.Format("{0}:{1}:0{2}", m_mins, m_seconds, (int)m_miliseconds);
            }
        }
    }
    public void MulaiTimerKunyah(float p_startingTimeM, float p_startingTimeS, float p_startingTimems)
    {
        m_totalmiliseconds = (p_startingTimeM * 6000) + (p_startingTimeS * 100) + (p_startingTimems * 100/*miliseconds*/);
        m_mins = p_startingTimeM;
        m_seconds = p_startingTimeS;
        m_miliseconds = p_startingTimems;
        m_startTimer = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out MenuMakanan menumakanan))
        {
            menumakanan.gameObject.GetComponent<Musuh>().speed = 0;
            gameController.ShowKunyahButton();
            menu = menumakanan;
            MulaiTimerKunyah(0f, 10f, 0f);
        }
    }
    
}
