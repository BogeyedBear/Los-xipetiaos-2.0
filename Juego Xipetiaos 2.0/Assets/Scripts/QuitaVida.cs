using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitaVida : MonoBehaviour
{

    public GameObject died;
    public GameObject player;
    public GameObject Reset;
    public GameObject Negro;
    public GameObject Backmenu;
    public float hits = 0f;
    public bool animacionNull = true;
    public AudioSource fuente;
    public AudioSource fuente2;
    public AudioClip clip;
    public AudioClip clip2;

    void Awake()
    {
        fuente.clip = clip2;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asesino"))
        {
            //Destroy(collision.gameObject);
            /**Reset.gameObject.SetActive(true);
            Negro.gameObject.SetActive(true);
            died.gameObject.SetActive(true);
            Debug.Log("¡¡¡YOU DIED!!!");**/
            hits = hits + 1f;
            fuente.Play();
        }
        /**if (hits == 4f)
        {
            //Destroy(collision.gameObject);
            Reset.gameObject.SetActive(true);
            Negro.gameObject.SetActive(true);
            died.gameObject.SetActive(true);
            Debug.Log("¡¡¡YOU DIED!!!");
        }**/
    }

    // Update is called once per frame
    void Update()
    {
        if (hits == 4f)
        {
            //Destroy(collision.gameObject);
            player.gameObject.SetActive(false);
            Reset.gameObject.SetActive(true);
            Negro.gameObject.SetActive(true);
            died.gameObject.SetActive(true);
            Backmenu.gameObject.SetActive(true);
            animacionNull = false;
            fuente2.clip = clip;
            fuente.Play();
            Debug.Log("¡¡¡YOU DIED!!!");
        }
    }
}
