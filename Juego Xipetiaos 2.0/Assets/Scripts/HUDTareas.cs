using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDTareas : MonoBehaviour
{
    public GameObject hudtareas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            this.hudtareas.SetActive(true);
        }
        else
        {
            this.hudtareas.SetActive(false);
        }
    }
}
    