using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maquinaexp : MonoBehaviour
{
    private Animator animator;
    public Transform player;
    public Transform maquinaexp;
    public GameObject mainPanel;
    public GameObject maquina;
    public GameObject maquinaPanel;
    public bool movimiento = true;
    public MaquinaPanel final;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cerca();
        animator.SetBool("fin", final.fin);

    }
    private void Cerca()
    {
        float restaX = Mathf.Abs(maquinaexp.position.x - player.transform.position.x);
        float restaY = Mathf.Abs(maquinaexp.position.y - player.transform.position.y);
        if (restaX < 1f && restaY < 1f)
        {
            animator.SetBool("cerca", true);
            if (final.fin == false)
            {

                if (Input.GetKeyDown(KeyCode.E))
                {
                    this.maquina.SetActive(true);
                    this.mainPanel.SetActive(true);
                    this.maquinaPanel.SetActive(true);
                    Time.timeScale = 0f;
                    movimiento = false;
                }
            }
            else
            {
                animator.SetBool("cerca", false);
            }
            
        }
            
    }
}
