using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelTask : MonoBehaviour
{
    public TextMeshProUGUI display;
    public TextMeshProUGUI papel;
    public int randNumber;
    public bool abierto;

    // Start is called before the first frame update
    void Start()
    {
        GeneratePassword();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddNumber(string number)
    {
        if (display.text.Length >= 4)
        {

            return;
        }
        display.text += number;
    }

    public void EraseDisplay()
    {
        display.text = "";
    }

    public void GeneratePassword()
    {
        papel.text = "";
        for (int i = 0; i < 4; i++)
        {
            randNumber = UnityEngine.Random.Range(0, 9);
            papel.text += randNumber;
        }
    }

    public void CheckPassword()
    {
        if (display.text.Equals(papel.text))
        {
            display.color = Color.green;
            display.text = "Granted";
            Destroy(gameObject, 1.0f);
            abierto = true;
        }
        else
        {
            display.text = "Denied";
        }
    }
}
