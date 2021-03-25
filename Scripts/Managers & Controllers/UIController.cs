using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public GameObject deathScreen; 
    public Slider healthSlider;
    public Text healthText, coinText;

    public Image fadeScreen;
    public float fadeSpeed;
    private bool fadeToBlack, fadeFromBlack;

    public string newGameScene, mainMenuScene;
    public GameObject pauseMenu, mapDisplay, bigMapText;

    public Image currentGun;
    public Text gunText;

    public Slider bossHealthBar; 

    private void Awake()
    {
        instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        fadeFromBlack = true;
        fadeToBlack = false;

        currentGun.sprite = PlayerController.instance.availableGuns[PlayerController.instance.currentGun].gunUI;
        gunText.text = PlayerController.instance.availableGuns[PlayerController.instance.currentGun].weaponName;
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if(fadeScreen.color.a == 0)
            {
                fadeFromBlack = false; 
            }
        }

        if(fadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 1f)
            {
                fadeFromBlack = true;
            }
        }
    }

    public void StartFadeToBlack()
    {
        fadeToBlack = true;
        fadeFromBlack = false; 
    }  
    
    public void NewGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(newGameScene);

        PlayerController.instance.gameObject.SetActive(true);
        //Destroy(PlayerController.instance.gameObject);
    }
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);

        Destroy(PlayerController.instance.gameObject);
    }    

    public void Resume()
    {
        LevelManager.instance.PauseUnpause();
    }
}
