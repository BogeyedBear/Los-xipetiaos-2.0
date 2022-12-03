using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaPanel : MonoBehaviour
{
    public GameObject pieza;
    public GameObject minijuego;
    public GameObject minijuegowin;
    public GameObject guion;
    public GameObject guionwin;
    public bool fin = false;
    // Start is called before the first frame update
    void Start()
    {
        pieza.SetActive(false);
    }

    // Update is called once per frame
    public void PiezaAparecer()
    {
        if(pieza != null)
        {
            bool IsActive = pieza.activeSelf;
            pieza.SetActive(!IsActive);
            fin = true;
            this.minijuego.SetActive(false);
            this.minijuegowin.SetActive(true);
            this.guion.SetActive(false);
            this.guionwin.SetActive(true);

        }
    }
}
