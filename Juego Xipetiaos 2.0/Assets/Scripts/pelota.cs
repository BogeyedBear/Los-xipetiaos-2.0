using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    public int puntos = 0;
    [SerializeField] Rigidbody2D pelotaRigidbody2D;
    Vector2 posicion;
    public AudioSource fuente;
    public AudioClip clip;
    public GameObject pieza;
    public GameObject balon;
    public GameObject minijuego;
    public GameObject minijuegowin;
    // Start is called before the first frame update
    void Awake()
    {
        posicion = new Vector2(pelotaRigidbody2D.position.x, pelotaRigidbody2D.position.y);
        fuente.clip = clip;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("gool"))
        {
            puntos++;
            fuente.Play();
            StartCoroutine(Reset());
            if (puntos == 3)
            {
                this.pieza.SetActive(true);
                this.balon.SetActive(false);
                this.minijuego.SetActive(false);
                this.minijuegowin.SetActive(true);

            }
        }
    }

    IEnumerator Reset()
    {
        // Emitir el sonido
        // XD
        // Hacer que se espere la ejecución del sonido}
        yield return new WaitForSeconds(1f);

        // Cambias de escena
        pelotaRigidbody2D.position = posicion;
        pelotaRigidbody2D.velocity = new Vector2(0f, 0f);
    }
}
