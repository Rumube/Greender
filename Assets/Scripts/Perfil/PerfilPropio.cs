using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PerfilPropio : Perfil
{
    [Header("Perfil Propio Referencias")]
    public GameObject _nameTxt;
    public GameObject _bioTxt;
    public GameObject _edadTxt;
    
    // Start is called before the first frame update
    void Start()
    {
        _isUser= true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region boton
    public void SetPerfilData()
    {
        _name = _nameTxt.GetComponent<TMP_InputField>().text;
        _bio.Add(_bioTxt.GetComponent<TMP_InputField>().text);
        _edad = int.Parse(_edadTxt.GetComponent<TMP_InputField>().text);
        GetComponent<GameManager>().CambiarEscena(GameManager.GAME_STATE.SELECCION);
    }
    #endregion
}
