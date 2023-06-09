using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enzime : MonoBehaviour
{
    public string target;
    public Musuh musuh;
    private float speed;
    private float dmg;
    void Start()
    {
        speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (musuh != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, musuh.transform.position, speed * Time.deltaTime);
        }
        else Destroy(this.gameObject);
    }

    public void setTarget(Musuh musuh, float dmg)
    {
        this.musuh = musuh;
        this.dmg = dmg;
    }

    /*void OnTriggerEnter2D(Collider2D collider)
    {
        bool state = true;
        switch (this.gameObject.name.Remove(this.gameObject.name.Length - 7))
        {
            case "Amilase":
                {
                    if (collider.gameObject.name.Remove(collider.gameObject.name.Length - 7).Equals("Amilum"))
                    {
                        state = true;
                    }
                    else state = false;
                    break;
                }
            case "Disakarase":
                {
                    if (collider.gameObject.name.Remove(collider.gameObject.name.Length - 7).Equals("Maltosa") || collider.gameObject.name.Remove(this.gameObject.name.Length - 7).Equals("Laktosa") || collider.gameObject.name.Remove(this.gameObject.name.Length - 7).Equals("Sukrosa"))
                    {
                        state = true;
                    }
                    else state = false;
                    break;
                }
            case "ePtialin":
                {
                    if (collider.gameObject.name.Remove(collider.gameObject.name.Length - 7).Equals("Amilum"))
                    {
                        state = true;
                    }
                    else state = false;
                    break;
                }
            case "Erepsin":
                {
                    if (collider.gameObject.name.Remove(collider.gameObject.name.Length - 7).Equals("Peptida"))
                    {
                        state = true;
                    }
                    else state = false;
                    break;
                }
            case "HCL":
                {
                    if (collider.gameObject.name.Remove(collider.gameObject.name.Length - 7).Equals("Bakteri"))
                    {
                        state = true;
                    }
                    else state = false;
                    break;
                }
            case "Laktase":
                {
                    if (collider.gameObject.name.Remove(collider.gameObject.name.Length - 7).Equals("Laktosa"))
                    {
                        state = true;
                    }
                    else state = false;
                    break;
                }
            case "Lipase":
                {
                    if (collider.gameObject.name.Remove(collider.gameObject.name.Length - 7).Equals("Lemak"))
                    {
                        state = true;
                    }
                    else state = false;
                    break;
                }
            case "Maltase":
                {
                    if (collider.gameObject.name.Remove(collider.gameObject.name.Length - 7).Equals("Maltosa"))
                    {
                        state = true;
                    }
                    else state = false;
                    break;
                }
            case "Pepsin":
                {
                    if (collider.gameObject.name.Remove(collider.gameObject.name.Length - 7).Equals("Protein"))
                    {
                        state = true;
                    }
                    else state = false;
                    break;
                }
            case "Peptidase":
                {
                    if (collider.gameObject.name.Remove(collider.gameObject.name.Length - 7).Equals("Polipeptida"))
                    {
                        state = true;
                    }
                    else state = false;
                    break;
                }
            case "Renin":
                {
                    if (collider.gameObject.name.Remove(collider.gameObject.name.Length - 7).Equals("Kaseinogen"))
                    {
                        state = true;
                    }
                    else state = false;
                    break;
                }
            case "Sukrase":
                {
                    if (collider.gameObject.name.Remove(collider.gameObject.name.Length - 7).Equals("Sukrosa"))
                    {
                        state = true;
                    }
                    else state = false;
                    break;
                }
            case "Tripsinogen":
                {
                    if (collider.gameObject.name.Remove(collider.gameObject.name.Length - 7).Equals("Polipeptida"))
                    {
                        state = true;
                    }
                    else state = false;
                    break;
                }
            default:
                {

                    break;
                }
        }
        if (collider.gameObject.TryGetComponent(out Musuh enemybehavior) && state)
        {
            enemybehavior.GotHit(dmg);
            Destroy(this.gameObject);
        }

    }*/

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Musuh musuh))
        {
            if (target.Equals(musuh.nama))
            {
                musuh.GotHit(dmg);
                Destroy(this.gameObject);
            }
        }
    }
}
