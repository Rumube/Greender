using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiTextsGenerator : MonoBehaviour
{
    GameObject emojiSending;
    int emojiSelector;
    private float minFreq;
    private float maxFreq;
    private float freq;
    private float coolDown;


    public GameObject spawn0;
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;

    public bool _gameStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        freq = 3f;
        minFreq = 1f;
        maxFreq = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (coolDown <= Time.time && _gameStarted)
        {
            freq = Random.Range(minFreq, maxFreq);
            Invoke("TextTheEmoji", freq);
            coolDown = Time.time + freq;
        }
    }

    void TextTheEmoji()
    {
        emojiSelector = Random.Range(0, 3);
        switch (emojiSelector)
        {
            case 0:
                spawn0.GetComponent<Spawn>().SpawnNewEmoji();
                break;
            case 1:
                spawn1.GetComponent<Spawn>().SpawnNewEmoji();
                break;
            case 2:
                spawn2.GetComponent<Spawn>().SpawnNewEmoji();
                break;
            case 3:
                spawn3.GetComponent<Spawn>().SpawnNewEmoji();
                break;
        }
        ChatMinigameManager.Instance.shootNow = true;
    }
}
