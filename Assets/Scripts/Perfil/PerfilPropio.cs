using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;

public class PerfilPropio : Perfil
{
    [Header("Perfil Propio Referencias")]
    public GameObject _nameTxt;
    public GameObject _bioTxt;
    public GameObject _edadTxt;
    public GameObject _etiquetaGO;
    public GameObject _etiquetasParent;
    [Header("Panel Etiquetas")]
    public GameObject _panelEtiquetas;
    public GameObject _panelEtiquetasParent;

    // Start is called before the first frame update
    void Start()
    {
        _isUser= true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetData()
    {
        if(_name != null)
        {
            _nameTxt.GetComponent<Text>().text = _name;
            _bioTxt.GetComponent<Text>().text = _bio[0];
            _edadTxt.GetComponent<Text>().text = _edad.ToString();
            SetEtiquetas();
        }
    }
    private void SetEtiquetas()
    {
        foreach (String currentEt in _etiquetas)
        {
            GameObject newEt = Instantiate(_etiquetaGO, _etiquetasParent.transform);
            newEt.name = currentEt;
            newEt.GetComponentInChildren<TextMeshProUGUI>().text = currentEt;
        }
    }

    #region boton
    public void SetPerfilData()
    {
        _name = _nameTxt.GetComponent<TMP_InputField>().text;
        _bio.Clear();
        _bio.Add(_bioTxt.GetComponent<TMP_InputField>().text);
        _edad = int.Parse(_edadTxt.GetComponent<TMP_InputField>().text);
        GetComponent<GameManager>().CambiarEscena(GameManager.GAME_STATE.SELECCION);
    }
    public void InitPanelEtiquetas()
    {
        foreach (String currentEt in _posibleEtiquetas)
        {
            GameObject newEt = Instantiate(_etiquetaGO, _panelEtiquetasParent.transform);
            newEt.name = currentEt;
            newEt.GetComponentInChildren<TextMeshProUGUI>().text = currentEt;
        }
    }
    #endregion
}