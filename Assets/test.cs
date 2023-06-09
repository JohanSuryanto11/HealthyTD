using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public Slider slider;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(slider.normalizedValue);
    }
}
