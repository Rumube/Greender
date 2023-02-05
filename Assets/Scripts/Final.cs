using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Final : MonoBehaviour
{
    public TextMeshProUGUI _finalTxt;
    public GameManager _manager;
    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        SelectFinal();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SelectFinal()
    {
        _finalTxt.text = _manager.GetComponent<Perfil>()._posibleFinal[Random.Range(0, _manager.GetComponent<Perfil>()._posibleFinal.Count - 1)];
    }
}
