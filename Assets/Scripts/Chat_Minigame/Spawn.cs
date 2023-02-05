using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject emojiSending;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnNewEmoji()
    {
        GameObject newChat = Instantiate(emojiSending, transform);
        ChatMinigameManager.Instance.gravityIncreasing = ChatMinigameManager.Instance.gravityIncreasing + 10;
    }

}
