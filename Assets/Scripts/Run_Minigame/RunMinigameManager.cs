using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class RunMinigameManager : MonoBehaviour
{

    public GameObject _decorFondo;

    public GameObject _suelo;
    public GameObject _cielo;

    public float _speed;

    public float _tiempo;

    public float _spawnTiempo;
    public GameObject _obstaculo;
    public List<Sprite> _spritesFondo;
    //private

    private List<GameObject> _listObs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _suelo.transform.position = new Vector2(_speed, -703) * Time.deltaTime;
    }

    private void SpawnObs()
    {
        //new GameObject newObs = Instantiate(_obstaculo, _spawnTiempo);
    }
}
