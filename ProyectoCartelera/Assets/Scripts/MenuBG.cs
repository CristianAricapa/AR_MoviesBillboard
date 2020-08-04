using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBG : MonoBehaviour
{

    public GameObject landscape;
    public GameObject portrait;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool orientation = (Screen.width > Screen.height);

        landscape.SetActive(orientation); //Activa landscape cuando ancho > alto
        portrait.SetActive(!orientation); //Activa portrait cuando ancho < alto
    }
}
