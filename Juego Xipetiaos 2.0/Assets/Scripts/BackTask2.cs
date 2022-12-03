using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTask2 : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject maquina;
    public GameObject maquinaPanel;
    public Maquinaexp movimientoNull;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ButtonBack()
    {
        this.mainPanel.SetActive(false);
        this.maquina.SetActive(false);
        this.maquinaPanel.SetActive(false);
        Time.timeScale = 1f;
        movimientoNull.movimiento = true;
    }
}
