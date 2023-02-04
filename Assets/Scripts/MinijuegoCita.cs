using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinijuegoCita : MonoBehaviour
{
    public GameObject _emoji;
    public List<Sprite> _emojiList = new List<Sprite>();
    // Start is called before the first frame update
    void Start()
    {
        GenerarEmoji();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Espera()
    {

    }

    void GenerarEmoji() 
    {
        _emoji.GetComponent<Image>().sprite = _emojiList[Random.Range(0, _emojiList.Count - 1)];
    }
}
