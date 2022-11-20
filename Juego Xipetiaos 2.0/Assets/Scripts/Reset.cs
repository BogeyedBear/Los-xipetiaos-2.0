using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    public void ResetGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
