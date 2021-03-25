using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string levelToLoad;

    public GameObject deletePanel;

    public CharacterSelector[] charactersToDelete; 

    // Start is called before the first frame update
    void Start()
    {
        Destroy(PlayerController.instance.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("You Have Quit");
    }

    public void DeleteSave()
    {
        deletePanel.SetActive(true);
    }

    public void ConfirmDelete()
    {
        deletePanel.SetActive(false); 

        foreach(CharacterSelector theCharacter in charactersToDelete)
        {
            PlayerPrefs.SetInt(theCharacter.playerToSpawn.name, 0);
        }

    }

    public void CancelDelete()
    {
        deletePanel.SetActive(false);
    }
}
