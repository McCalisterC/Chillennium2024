using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject hero;
    public Button start;
    public Button end;
    
    public void StartGame()
    {
        StartCoroutine(StartGameSequence());
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    IEnumerator StartGameSequence()
    {
        start.enabled = false;
        end.enabled = false;
        hero.GetComponent<Animator>().SetTrigger("Play");
        yield return new WaitForSeconds(1.0f);
        //Black bar transition
        yield return new WaitForSeconds(1.0f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("TestScene");
    }
}
