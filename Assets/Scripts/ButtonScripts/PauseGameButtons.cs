using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGameButtons : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Resume()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(!gameObject.active);

    }


    public void Quit()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
