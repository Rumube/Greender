using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class RunMinigameManager : MonoBehaviour
{
    public GameObject _player;
    public GameObject _decorFondo;

    public GameObject _suelo;
    public GameObject _cielo;

    public float _speed;


    public float _spawnTiempo;
    public GameObject _spawnParent;
    public GameObject _obstaculo;
    public List<Sprite> _spritesFondo;
    public float _nextObs;

    public bool _inGame = false;

    public bool _inJump = false;
    public GameObject _jumPos;
    public GameObject _normalPos;

    private List<GameObject> _listObs = new List<GameObject>();
    public float _finishGameTime;
    public float _gameTime;
    public TextMeshProUGUI _contador;

    private GameManager _manager;

    private bool _played = false;

    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        _nextObs = 999990;
        StartCoroutine(CuentaAtras());
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup >= _nextObs && _inGame)
        {
            _nextObs = Time.realtimeSinceStartup + _spawnTiempo;
            SpawnObs();
        }
        foreach (GameObject currentObs in _listObs)
        {
            currentObs.transform.localPosition = new Vector2(currentObs.transform.localPosition.x - 1, 0);
        }
        if (Time.realtimeSinceStartup >= _finishGameTime && _played)
        {
            _inGame = false;
            _manager.CambiarEscena(GameManager.GAME_STATE.CITA);
        }
    }

    private void SpawnObs()
    {
        GameObject newObs = Instantiate(_obstaculo, _spawnParent.transform);
        _listObs.Add(newObs);
    }

    public void Jump()
    {
        if(!_inJump)
        {
            _inJump = true;
            _player.transform.position = _jumPos.transform.position;
            StartCoroutine(FinSalto());
        }

    }

    private IEnumerator FinSalto()
    {
        yield return new WaitForSeconds(1);
        _inJump = false;
        _player.transform.position = _normalPos.transform.position;
    }

    private IEnumerator CuentaAtras()
    {
        for (int i = 0; i < 4; i++)
        {
            _contador.text = (3 - i).ToString();
            yield return new WaitForSeconds(1f);
        }
        StartGame();
        yield return new WaitForSeconds(0.5f);
        _contador.gameObject.SetActive(false);
    }
    private void StartGame()
    {
        _finishGameTime = Time.realtimeSinceStartup + _gameTime;
        _inGame = true;
        _played = true;
    }

}
