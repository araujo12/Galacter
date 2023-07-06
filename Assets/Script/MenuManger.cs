using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManger : MonoBehaviour
{
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSceneGame()
    {

        SceneManager.LoadScene("Level");
    }

    public void LoadSceneMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadSceneControle()
    {
        SceneManager.LoadScene("Controles");
    }

    public void LoadSceneCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    
    
}
