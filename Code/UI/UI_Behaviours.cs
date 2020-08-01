using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Behaviours : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void activateObject(GameObject objectReference)
    {
        objectReference.SetActive(true);
    }
    public void deActivateObject(GameObject objectReference)
    {
        objectReference.SetActive(false);
    }

    public void loadScene(string sceneToLoad) 
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void exitAplication()
    {
        Application.Quit();
    }

   

}
