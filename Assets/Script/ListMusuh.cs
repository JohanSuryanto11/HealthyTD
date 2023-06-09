using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ListMusuh : MonoBehaviour
{
    private static List<Musuh> kaseinogen = new List<Musuh>();
    public List<Musuh> amilum = new List<Musuh>();
    private static List<Musuh> bakteri = new List<Musuh>();
    private static List<Musuh> besi = new List<Musuh>();
    private static List<Musuh> fosfor = new List<Musuh>();
    private static List<Musuh> kalium = new List<Musuh>();
    private static List<Musuh> kalsium = new List<Musuh>();
    private static List<Musuh> lemak = new List<Musuh>();
    private static List<Musuh> makanan = new List<Musuh>();
    private static List<Musuh> natrium = new List<Musuh>();
    private static List<Musuh> protein = new List<Musuh>();
    private static List<Musuh> seng = new List<Musuh>();
    private static List<Musuh> tembaga = new List<Musuh>();
    private static List<Musuh> vita = new List<Musuh>();
    private static List<Musuh> vitb1 = new List<Musuh>();
    private static List<Musuh> vitb2 = new List<Musuh>();
    private static List<Musuh> vitb3 = new List<Musuh>();
    private static List<Musuh> vitb6 = new List<Musuh>();
    private static List<Musuh> vitb12 = new List<Musuh>();
    private static List<Musuh> vitc = new List<Musuh>();
    private static List<Musuh> vitd = new List<Musuh>();
    private static List<Musuh> vite = new List<Musuh>();
    private static List<Musuh> vitk = new List<Musuh>();
    private static List<Musuh> asamlemak = new List<Musuh>();
    private static List<Musuh> gliserol = new List<Musuh>();
    private static List<Musuh> laktosa = new List<Musuh>();
    private static List<Musuh> maltosa = new List<Musuh>();
    private static List<Musuh> polipeptida = new List<Musuh>();
    private static List<Musuh> sukrosa = new List<Musuh>();
    private static List<Musuh> fruktosa = new List<Musuh>();
    private static List<Musuh> galaktosa = new List<Musuh>();
    private static List<Musuh> glukosa = new List<Musuh>();
    private static List<Musuh> peptida = new List<Musuh>();
    private static List<Musuh> asamamino = new List<Musuh>();
    private static List<Musuh> allenemy = new List<Musuh>();
    private static List<Musuh> stage3 = new List<Musuh>();
    private static List<Musuh> stage4 = new List<Musuh>();
    private static List<Musuh> stage5 = new List<Musuh>();
    private static List<Musuh> feses = new List<Musuh>();
    public List<Musuh> vitamins = new List<Musuh>();
    private static List<Musuh> minerals = new List<Musuh>();
    public void AddEnemy(string name,Musuh musuh)
    {
        switch (name)
        {
            case "Amilum":
                {
                    amilum.Add(musuh);
                    break;
                }
            case "Bakteri":
                {
                    bakteri.Add(musuh);
                    break;
                }
            case "Besi":
                {
                    minerals.Add(musuh);
                    break;
                }
            case "Fosfor":
                {
                    minerals.Add(musuh);
                    break;
                }
            case "Kalium":
                {
                    minerals.Add(musuh);
                    break;
                }
            case "Kalsium":
                {
                    minerals.Add(musuh);
                    break;
                }
            case "Lemak":
                {
                    lemak.Add(musuh);
                    break;
                }
            case "Makanan":
                {
                    makanan.Add(musuh);
                    break;
                }
            case "Natrium":
                {
                    minerals.Add(musuh);
                    break;
                }
            case "Protein":
                {
                    protein.Add(musuh);
                    break;
                }
            case "Seng":
                {
                    minerals.Add(musuh);
                    break;
                }
            case "Tembaga":
                {
                    minerals.Add(musuh);
                    break;
                }
            case "VitA":
                {
                    vitamins.Add(musuh);
                    break;
                }
            case "VitB1":
                {
                    vitamins.Add(musuh);
                    break;
                }
            case "VitB2":
                {
                    vitamins.Add(musuh);
                    break;
                }
            case "VitB3":
                {
                    vitamins.Add(musuh);
                    break;
                }
            case "VitB6":
                {
                    vitamins.Add(musuh);
                    break;
                }
            case "VitB12":
                {
                    vitamins.Add(musuh);
                    break;
                }
            case "VitC":
                {
                    vitamins.Add(musuh);
                    break;
                }
            case "VitD":
                {
                    vitamins.Add(musuh);
                    break;
                }
            case "VitE":
                {
                    vitamins.Add(musuh);
                    break;
                }
            case "VitK":
                {
                    vitamins.Add(musuh);
                    break;
                }
            case "AsamLemak":
                {
                    asamlemak.Add(musuh);
                    break;
                }
            case "Gliserol":
                {
                    gliserol.Add(musuh);
                    break;
                }
            case "Laktosa":
                {
                    laktosa.Add(musuh);
                    break;
                }
            case "Maltosa":
                {
                    maltosa.Add(musuh);
                    break;
                }
            case "Polipeptida":
                {
                    polipeptida.Add(musuh);
                    break;
                }
            case "Sukrosa":
                {
                    sukrosa.Add(musuh);
                    break;
                }
            case "Fruktosa":
                {
                    fruktosa.Add(musuh);
                    break;
                }
            case "Galaktosa":
                {
                    galaktosa.Add(musuh);
                    break;
                }
            case "Peptida":
                {
                    peptida.Add(musuh);
                    break;
                }

            case "Asamamino":
                {
                    asamamino.Add(musuh);
                    break;
                }
            case "Feses":
                {
                    feses.Add(musuh);
                    break;
                }
            case "Glukosa":
                {
                    glukosa.Add(musuh);
                    break;
                }
            default:
                {
                    Debug.Log("default");
                    break;
                }
        }
    }
    public List<Musuh> getMusuh(string Tower)
    {
        switch (Tower)
        {
            case "Ptialin":
                {
                    return amilum;
                    break;
                }
            case "HCL":
                {
                    return bakteri;
                    break;
                }
            case "Pepsin":
                {
                    return protein;
                    break;
                }
            case "Tripsinogen":
                {
                    return polipeptida;
                    break;
                }
            case "Renin":
                {
                    return kaseinogen;
                    break;
                }
            case "Amilase":
                {
                    return amilum;
                    break;
                }
            case "Lipase":
                {
                    return lemak;
                    break;
                }
            case "Laktase":
                {
                    return laktosa;
                    break;
                }
            case "Erepsin":
                {
                    return peptida;
                    break;
                }
            case "Maltase":
                {
                    return maltosa;
                    break;
                }
            case "Disakarase":
                {
                    List<Musuh> disakarida = new List<Musuh>();
                    foreach (Musuh suk in sukrosa)
                    {
                        disakarida.Add(suk);
                    }
                    foreach (Musuh mal in maltosa)
                    {
                        disakarida.Add(mal);
                    }
                    foreach (Musuh lak in laktosa)
                    {
                        disakarida.Add(lak);
                    }
                    return disakarida;
                    break;
                }
            case "Sukrase":
                {
                    return sukrosa;
                    break;
                }
            case "Limfa":
                {
                    List<Musuh> musuhlimfa = new List<Musuh>();
                    foreach(Musuh vitamin in vitamins)
                    {
                        musuhlimfa.Add(vitamin);
                    }
                    foreach(Musuh mineral in minerals)
                    {
                        musuhlimfa.Add(mineral);
                    }
                    foreach(Musuh fruk in fruktosa)
                    {
                        musuhlimfa.Add(fruk);
                    }
                    foreach (Musuh gal in galaktosa)
                    {
                        musuhlimfa.Add(gal);
                    }
                    foreach (Musuh glu in glukosa)
                    {
                        musuhlimfa.Add(glu);
                    }
                    foreach (Musuh asam in asamamino)
                    {
                        musuhlimfa.Add(asam);
                    }
                    foreach (Musuh asamle in asamlemak)
                    {
                        musuhlimfa.Add(asamle);
                    }
                    foreach (Musuh gli in gliserol)
                    {
                        musuhlimfa.Add(gli);
                    }
                    return musuhlimfa;
                    break;
                }
            case "E. Coli":
                {
                    return feses;
                    break;
                }
            default:
                {
                    return allenemy;
                    break;
                }
        }
    }
    public void RemoveEnemy(string name, Musuh musuh)
    {
        switch (name)
        {
            case "Amilum":
                {
                    amilum.Remove(musuh);
                    break;
                }
            case "Bakteri":
                {
                    bakteri.Remove(musuh);
                    break;
                }
            case "Besi":
                {
                    minerals.Remove(musuh);
                    break;
                }
            case "Fosfor":
                {
                    minerals.Remove(musuh);
                    break;
                }
            case "Kalium":
                {
                    minerals.Remove(musuh);
                    break;
                }
            case "Kalsium":
                {
                    minerals.Remove(musuh);
                    break;
                }
            case "Lemak":
                {
                    lemak.Remove(musuh);
                    break;
                }
            case "Makanan":
                {
                    makanan.Remove(musuh);
                    break;
                }
            case "Natrium":
                {
                    minerals.Remove(musuh);
                    break;
                }
            case "Protein":
                {
                    protein.Remove(musuh);
                    break;
                }
            case "Seng":
                {
                    minerals.Remove(musuh);
                    break;
                }
            case "Tembaga":
                {
                    minerals.Remove(musuh);
                    break;
                }
            case "VitA":
                {
                    vitamins.Remove(musuh);
                    break;
                }
            case "VitB1":
                {
                    vitamins.Remove(musuh);
                    break;
                }
            case "VitB2":
                {
                    vitamins.Remove(musuh);
                    break;
                }
            case "VitB3":
                {
                    vitamins.Remove(musuh);
                    break;
                }
            case "VitB6":
                {
                    vitamins.Remove(musuh);
                    break;
                }
            case "VitB12":
                {
                    vitamins.Remove(musuh);
                    break;
                }
            case "VitC":
                {
                    vitamins.Remove(musuh);
                    break;
                }
            case "VitD":
                {
                    vitamins.Remove(musuh);
                    break;
                }
            case "VitE":
                {
                    vitamins.Remove(musuh);
                    break;
                }
            case "VitK":
                {
                    vitamins.Remove(musuh);
                    break;
                }
            case "AsamLemak":
                {
                    asamlemak.Remove(musuh);
                    break;
                }
            case "Gliserol":
                {
                    gliserol.Remove(musuh);
                    break;
                }
            case "Laktosa":
                {
                    laktosa.Remove(musuh);
                    break;
                }
            case "Maltosa":
                {
                    maltosa.Remove(musuh);
                    break;
                }
            case "Polipeptida":
                {
                    polipeptida.Remove(musuh);
                    break;
                }
            case "Sukrosa":
                {
                    sukrosa.Remove(musuh);
                    break;
                }
            case "Fruktosa":
                {
                    fruktosa.Remove(musuh);
                    break;
                }
            case "Galaktosa":
                {
                    galaktosa.Remove(musuh);
                    break;
                }
            case "Peptida":
                {
                    peptida.Remove(musuh);
                    break;
                }

            case "Asamamino":
                {
                    asamamino.Remove(musuh);
                    break;
                }
            case "Feses":
                {
                    feses.Remove(musuh);
                    break;
                }
            case "Glukosa":
                {
                    glukosa.Remove(musuh);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

}
