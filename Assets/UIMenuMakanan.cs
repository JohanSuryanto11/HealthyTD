using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuMakanan : MonoBehaviour
{
    public List<TextMeshProUGUI> text = new List<TextMeshProUGUI>();
    public List<GameObject> menu = new List<GameObject>();
    public List<GameObject> gizi = new List<GameObject>();
    public List<Sprite> smenu = new List<Sprite>();
    public List<Sprite> sgizi = new List<Sprite>();
    private GameObject uimenu;
    void Start()
    {
        
    }
    private void Awake()
    {
        uimenu = GameObject.Find("BG");
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void gantimenu(int makanke)
    {
        switch (makanke)
        {
            case 0:
                {
                    text[0].text = "Bubur Ayam";
                    text[1].text = "Nasi Telur";
                    text[2].text = "Nasi Tahu Tempe";
                    menu[0].GetComponent<Image>().sprite = smenu[0];
                    menu[1].GetComponent<Image>().sprite = smenu[1];
                    menu[2].GetComponent<Image>().sprite = smenu[2];
                    gizi[0].GetComponent<Image>().sprite = sgizi[0];
                    gizi[1].GetComponent<Image>().sprite = sgizi[1];
                    gizi[2].GetComponent<Image>().sprite = sgizi[2];
                    break;
                }
            case 1:
                {
                    text[0].text = "Nasi Ayam Goreng";
                    text[1].text = "Mie Bakso";
                    text[2].text = "Karedok";
                    menu[0].GetComponent<Image>().sprite = smenu[3];
                    menu[1].GetComponent<Image>().sprite = smenu[4];
                    menu[2].GetComponent<Image>().sprite = smenu[5];
                    gizi[0].GetComponent<Image>().sprite = sgizi[3];
                    gizi[1].GetComponent<Image>().sprite = sgizi[4];
                    gizi[2].GetComponent<Image>().sprite = sgizi[5];
                    break;
                }
            case 2:
                {
                    text[0].text = "Nasi Goreng";
                    text[1].text = "Nasi Bandeng";
                    text[2].text = "Buah Buahan";
                    menu[0].GetComponent<Image>().sprite = smenu[6];
                    menu[1].GetComponent<Image>().sprite = smenu[7];
                    menu[2].GetComponent<Image>().sprite = smenu[8];
                    gizi[0].GetComponent<Image>().sprite = sgizi[6];
                    gizi[1].GetComponent<Image>().sprite = sgizi[7];
                    gizi[2].GetComponent<Image>().sprite = sgizi[8];
                    break;
                }
        }

    }

    public void hidemenu()
    {
        uimenu.SetActive(false);
    }

    public void showmenu()
    {
        uimenu.SetActive(true);
    }


}
