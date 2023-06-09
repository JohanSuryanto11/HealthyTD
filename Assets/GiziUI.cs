using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GiziUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    Vector2 position = new Vector2(1249, 240);
    private bool showUI;

    public Color low;
    public Color high;
    public float jKalori;
    public float jprotein;
    public float jkarbohidrat;
    public float jlemak;
    public float jVitA;
    public float jVitB1;
    public float jvitB2;
    public float jvitB3;
    public float jvitB6;
    public float jvitB12;
    public float jvitC;
    public float jvitD;
    public float jvitE;
    public float jvitK;
    public float jkalsium;
    public float jfosfor;
    public float jbesi;
    public float jnatrium;
    public float jkalium;
    public float jtembaga;
    public float jseng;
    public TextMeshProUGUI Kalori;
    public TextMeshProUGUI protein;
    public TextMeshProUGUI karbohidrat;
    public TextMeshProUGUI lemak;
    public TextMeshProUGUI VitA;
    public TextMeshProUGUI VitB1;
    public TextMeshProUGUI vitB2;
    public TextMeshProUGUI vitB3;
    public TextMeshProUGUI vitB6;
    public TextMeshProUGUI vitB12;
    public TextMeshProUGUI vitC;
    public TextMeshProUGUI vitD;
    public TextMeshProUGUI vitE;
    public TextMeshProUGUI vitK;
    public TextMeshProUGUI kalsium;
    public TextMeshProUGUI fosfor;
    public TextMeshProUGUI besi;
    public TextMeshProUGUI natrium;
    public TextMeshProUGUI kalium;
    public TextMeshProUGUI tembaga;
    public TextMeshProUGUI seng;
    public Slider sKalori;
    public Slider sprotein;
    public Slider skarbohidrat;
    public Slider slemak;
    public Slider sVitA;
    public Slider sVitB1;
    public Slider svitB2;
    public Slider svitB3;
    public Slider svitB6;
    public Slider svitB12;
    public Slider svitC;
    public Slider svitD;
    public Slider svitE;
    public Slider svitK;
    public Slider skalsium;
    public Slider sfosfor;
    public Slider sbesi;
    public Slider snatrium;
    public Slider skalium;
    public Slider stembaga;
    public Slider sseng;
    void Start()
    {
        jKalori = 0;
        jprotein = 0;
        jkarbohidrat = 0;
        jlemak = 0;
        jVitA = 0;
        jVitB1 = 0;
        jvitB2 = 0;
        jvitB3 = 0;
        jvitB6 = 0;
        jvitB12 = 0;
        jvitC = 0;
        jvitD = 0;
        jvitE = 0;
        jvitK = 0;
        jkalsium = 0;
        jfosfor = 0;
        jbesi = 0;
        jnatrium = 0;
        jkalium = 0;
        jtembaga = 0;
        jseng = 0;
    }
    private void Awake()
    {
        sKalori.maxValue = 2650;
        sprotein.maxValue = 65;
        skarbohidrat.maxValue = 430;
        slemak.maxValue = 75;
        sVitA.maxValue = 650;
        sVitB1.maxValue = 1.2f;
        svitB2.maxValue = 1.3f;
        svitB3.maxValue = 16;
        svitB6.maxValue = 1.3f;
        svitB12.maxValue = 4;
        svitC.maxValue = 90;
        svitD.maxValue = 15;
        svitE.maxValue = 15;
        svitK.maxValue = 65;
        skalsium.maxValue = 1000;
        sfosfor.maxValue = 700;
        sbesi.maxValue = 9;
        snatrium.maxValue = 1500;
        skalium.maxValue = 4700;
        stembaga.maxValue = 900;
        sseng.maxValue = 11;
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(GetComponent<RectTransform>().anchoredPosition, position, 600 * Time.deltaTime);
    }
    public void HideShow()
    {
        if (showUI)
        {
            position = new Vector2(1249, 240);
            text.transform.eulerAngles = new Vector3(0f, 0f, 90f);
            showUI = false;
        }
        else
        {
            position = new Vector2(671.54f, 240);
            text.transform.eulerAngles = new Vector3(0f, 0f, -90f);
            showUI = true;
        }
    }
    public void UpdateGizi()
    {
        jKalori = ((jkarbohidrat * 4)+(jprotein*4)+(jlemak*9));

        sKalori.value = jKalori;
        Kalori.text = jKalori.ToString() + "kkal";
        sKalori.fillRect.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.Lerp(low, high, sKalori.normalizedValue);

        sprotein.value = jprotein;
        protein.text = jprotein.ToString() + "g";
        sprotein.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, sprotein.normalizedValue);

        skarbohidrat.value = jkarbohidrat;
        karbohidrat.text = jkarbohidrat.ToString() + "g";
        skarbohidrat.fillRect.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.Lerp(low, high, skarbohidrat.normalizedValue);

        slemak.value = jlemak;
        lemak.text = jlemak.ToString() + "g";
        slemak.fillRect.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.Lerp(low, high, slemak.normalizedValue);

        sVitA.value = jVitA;
        VitA.text = jVitA.ToString() + "IU";
        sVitA.fillRect.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.Lerp(low, high, sVitA.normalizedValue);

        sVitB1.value = jVitB1;
        VitB1.text = jVitB1.ToString() + "mg";
        sVitB1.fillRect.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.Lerp(low, high, sVitB1.normalizedValue);

        svitB2.value = jvitB2;
        vitB2.text = jvitB2.ToString() + "mg";
        svitB2.fillRect.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.Lerp(low, high, svitB2.normalizedValue);

        svitB3.value = jvitB3;
        vitB3.text = jvitB3.ToString() + "mg";
        svitB3.fillRect.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.Lerp(low, high, svitB3.normalizedValue);

        svitB6.value = jvitB6;
        vitB6.text = jvitB6.ToString() + "mg";
        svitB6.fillRect.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.Lerp(low, high, svitB6.normalizedValue);

        svitB12.value = jvitB12;
        vitB12.text = jvitB12.ToString() + "mcg";
        svitB12.fillRect.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.Lerp(low, high, svitB12.normalizedValue);

        svitC.value = jvitC;
        vitC.text = jvitC.ToString() + "mg";
        svitC.fillRect.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.Lerp(low, high, svitC.normalizedValue);

        svitD.value = jvitD;
        vitD.text = jvitD.ToString() + "mcg";
        svitD.fillRect.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.Lerp(low, high, svitD.normalizedValue);

        svitE.value = jvitE;
        vitE.text = jvitE.ToString() + "mg";
        svitE.fillRect.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.Lerp(low, high, svitE.normalizedValue);

        svitK.value = jvitK;
        vitK.text = jvitK.ToString() + "mg";
        svitK.fillRect.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.Lerp(low, high, svitK.normalizedValue);

        skalsium.value = jkalsium;
        kalsium.text = jkalsium.ToString() + "mg";
        skalsium.fillRect.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.Lerp(low, high, skalsium.normalizedValue);

        sfosfor.value = jfosfor;
        fosfor.text = jfosfor.ToString() + "mg";
        sfosfor.fillRect.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.Lerp(low, high, sfosfor.normalizedValue);

        sbesi.value = jbesi;
        besi.text = jbesi.ToString() + "mg";
        sbesi.fillRect.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.Lerp(low, high, sbesi.normalizedValue);

        snatrium.value = jnatrium;
        natrium.text = jnatrium.ToString() + "mg";
        snatrium.fillRect.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.Lerp(low, high, snatrium.normalizedValue);

        skalium.value = jkalium;
        kalium.text = jkalium.ToString() + "mg";
        skalium.fillRect.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.Lerp(low, high, skalium.normalizedValue);

        stembaga.value = jtembaga;
        tembaga.text = jtembaga.ToString() + "mg";
        stembaga.fillRect.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.Lerp(low, high, stembaga.normalizedValue);

        sseng.value = jseng;
        seng.text = jseng.ToString() + "mg";
        sseng.fillRect.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.Lerp(low, high, sseng.normalizedValue);
    }
    public void setkarbo(float karbo)
    {
        jkarbohidrat += karbo;
        UpdateGizi();
    }
    public void setprotein(float protein)
    {
        jprotein += protein;
        UpdateGizi();
    }
    public void setlemak(float lemak)
    {
        jlemak += lemak;
        UpdateGizi();
    }
    public void setvita(float vita)
    {
        jVitA += vita;
        UpdateGizi();
    }
    public void setvitb1(float vitb1)
    {
        jVitB1 += vitb1;
        UpdateGizi();
    }
    public void setvitb2(float vitb2)
    {
        jvitB2 += vitb2;
        UpdateGizi();

    }
    public void setvitb3(float vitb3)
    {
        jvitB3 += vitb3;
        UpdateGizi();
    }
    public void setvitb6(float vitb6)
    {
        jvitB6 += vitb6;
        UpdateGizi();
    }
    public void setvitb12(float vitb12)
    {
        jvitB12 += vitb12;
        UpdateGizi();

    }
    public void setvitC(float vitc)
    {
        jvitC += vitc;
        UpdateGizi();
    }
    public void setvitD(float vitd)
    {
        jvitD += vitd;
        UpdateGizi();

    }
    public void setvitE(float vite)
    {
        jvitE += vite;
        UpdateGizi();

    }
    public void setvitK(float vitk)
    {
        jvitK += vitk;
        UpdateGizi();
    }
    public void setfosfor(float fosfor)
    {
        jfosfor += fosfor;
        UpdateGizi();
    }
    public void setkalium(float kalium)
    {
        jkalium += kalium;
        UpdateGizi();
    }
    public void setkalsium(float kalsium)
    {
        jkalsium += kalsium;
        UpdateGizi();

    }
    public void settembaga(float tembaga)
    {
        jtembaga += tembaga;
        UpdateGizi();
    }
    public void setseng(float seng)
    {
        jseng += seng;
        UpdateGizi();
    }
    public void setbesi(float besi)
    {
        jbesi += besi;
        UpdateGizi();
    }
    public void setnatrium(float natrium)
    {
        jnatrium += natrium;
        UpdateGizi();
    }
    public int kalkulasigizi()
    {
        float score=0;

        score += 10000 * sKalori.normalizedValue;
        score += 10000 * sprotein.normalizedValue;
        score += 10000 * skarbohidrat.normalizedValue;
        score += 10000 * slemak.normalizedValue;
        score += 10000 * sVitA.normalizedValue;
        score += 10000 * sVitB1.normalizedValue;
        score += 10000 * svitB2.normalizedValue;
        score += 10000 * svitB3.normalizedValue;
        score += 10000 * svitB6.normalizedValue;
        score += 10000 * svitB12.normalizedValue;
        score += 10000 * svitC.normalizedValue;
        score += 10000 * svitD.normalizedValue;
        score += 10000 * svitE.normalizedValue;
        score += 10000 * svitK.normalizedValue;
        score += 10000 * skalsium.normalizedValue;
        score += 10000 * sfosfor.normalizedValue;
        score += 10000 * sbesi.normalizedValue;
        score += 10000 * snatrium.normalizedValue;
        score += 10000 * skalium.normalizedValue;
        score += 10000 * stembaga.normalizedValue;
        score += 10000 * sseng.normalizedValue;
        return (int)score;
    }
}
