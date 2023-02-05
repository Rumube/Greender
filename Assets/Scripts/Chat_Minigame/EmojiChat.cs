using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiChat : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame 
    void Update()
    {
        rb.gravityScale = ChatMinigameManager.Instance.gravityIncreasing;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("End"))
        {
            print("Mal");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("End"))
        {
            Object.Destroy(this.gameObject);
        }
    }
}
