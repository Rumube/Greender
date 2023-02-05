using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    GameObject emoji;
    [SerializeField] string tagFromEmoji;
    [SerializeField] Collider2D collisionEmoji;

    [SerializeField] bool clicked;
    bool correct = false;
    GameObject emojiToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Click()
    {
        GetComponent<Animator>().Play("ButtonAnim");
        if (correct)
        {
            //EJECUTAMOS BIEN
            CorrectClick();
        }
        else
        {
            //EJECUTAMOS MAL
            IncorrectClick();
        }
    }

    private void CorrectClick()
    {
        print("Bien");
        Object.Destroy(emojiToDestroy);
    }

    private void IncorrectClick()
    {
        print("Mal");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TextingEmoji_0") || collision.CompareTag("TextingEmoji_1") || collision.CompareTag("TextingEmoji_2") || collision.CompareTag("TextingEmoji_3"))
        {
            correct = true;
            emojiToDestroy = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TextingEmoji_0") || collision.CompareTag("TextingEmoji_1") || collision.CompareTag("TextingEmoji_2") || collision.CompareTag("TextingEmoji_3"))
        {
            correct = false;
        }
    }


}
