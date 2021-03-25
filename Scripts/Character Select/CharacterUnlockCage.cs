using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUnlockCage : MonoBehaviour
{
    private bool canUnlock;

    public GameObject message;

    public CharacterSelector[] characterSelects;
    private CharacterSelector playerToUnlock;

    public SpriteRenderer cagedSR; 

    // Start is called before the first frame update
    void Start()
    {
        playerToUnlock = characterSelects[Random.Range(0, characterSelects.Length)];

        cagedSR.sprite = playerToUnlock.playerToSpawn.sr.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(canUnlock)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                PlayerPrefs.SetInt(playerToUnlock.playerToSpawn.name, 1);


                Instantiate(playerToUnlock, transform.position, transform.rotation);

                gameObject.SetActive(false); 
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canUnlock = true;
            message.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canUnlock = false;
            message.SetActive(false);
        }
    }
}
