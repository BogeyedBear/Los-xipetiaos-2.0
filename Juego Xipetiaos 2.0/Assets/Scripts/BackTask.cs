using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTask : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject panel;
    public CajaFuerte movimientoNull;

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
        this.panel.SetActive(false);
        Time.timeScale = 1f;
        movimientoNull.movimiento = true;
    }
}
