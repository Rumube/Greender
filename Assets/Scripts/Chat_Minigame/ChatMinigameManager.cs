using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatMinigameManager : MonoBehaviour
{
    public static ChatMinigameManager Instance { get; private set; }

    public GameObject emojiSending;
    public bool shootNow;
    public float gravityIncreasing;
    public float _gameTime;
    public float _finishGameTime;

    public GameObject _generador;
    public TextMeshProUGUI _contador;

    // Start is called before the first frame update
    void Start()
    {
        gravityIncreasing = 100;
        if (Instance == null)
        {
            Instance = this;
        }
        StartCoroutine(CuentaAtras());
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.realtimeSinceStartup >= _finishGameTime)
        {
            _generador.GetComponent<EmojiTextsGenerator>()._gameStarted = false;
        }
    }

    private IEnumerator CuentaAtras()
    {
        for (int i = 0; i < 4; i++)
        {
            _contador.text = (3 - i).ToString();
            print(3-i);
            yield return new WaitForSeconds(1f);
        }
        StartGame();
        yield return new WaitForSeconds(0.5f);
        _contador.gameObject.SetActive(false);
    }

    private void StartGame()
    {
        _finishGameTime = Time.realtimeSinceStartup + _gameTime;
        _generador.GetComponent<EmojiTextsGenerator>()._gameStarted = true;
    }

}
