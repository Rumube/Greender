using System;
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
    public GameObject _etiquetaGO;
    public GameObject _etiquetasParent;
    private List<GameObject> _etiquetasList;
    [Header("Panel Etiquetas")]
    public GameObject _panelEtiquetas;
    public GameObject _panelEtiquetasParent;
    private List<GameObject> _panelEtiquetasList;
    private GameManager _manager;
    public GameObject _panelEtiquetasActuales;
    public List<string> _etiquetasPropias = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        _isUser= true;
        _name = null;
        _edad = 0;
        _etiquetasPropias.Clear();
        if(_manager == null)
        {
            _manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetData()
    {
        if(_name != "")
        {
            _nameTxt.GetComponent<TMP_InputField>().text = _name;
            _bioTxt.GetComponent<TMP_InputField>().text = _bio[0];
            _edadTxt.GetComponent<TMP_InputField>().text = _edad.ToString();
            SetEtiquetas();
        }
    }
    private void SetEtiquetas()
    {
        if(_etiquetasList!= null)
        {
            ClearEtiquetas(_etiquetasParent.transform, _etiquetasList);
        }
        foreach (String currentEt in _etiquetasPropias)
        {
            GameObject newEt = Instantiate(_etiquetaGO, _etiquetasParent.transform);
            newEt.name = currentEt;
            newEt.GetComponentInChildren<TextMeshProUGUI>().text = currentEt;
        }
    }
    private void SetEtiquetas(Transform parent)
    {
        if(_panelEtiquetasList != null)
        {
            ClearEtiquetas(_panelEtiquetasParent.transform, _panelEtiquetasList);
        }
        foreach (String currentEt in _etiquetasPropias)
        {
            GameObject newEt = Instantiate(_etiquetaGO, parent);
            newEt.name = currentEt;
            newEt.GetComponentInChildren<TextMeshProUGUI>().text = currentEt;
        }
    }
    private void ClearEtiquetas(Transform parent, List<GameObject> etiquetas)
    {
        List<GameObject> list = new List<GameObject>(etiquetas);

        for (int i = 0; i < list.Count; i++)
        {
            Destroy(etiquetas[i]);
        }
        etiquetas.Clear();
    }
    public void EtiquetaPulsada(string etiqueta)
    {
        if (_etiquetasPropias.Contains(etiqueta))
        {
            _etiquetasPropias.Remove(etiqueta);
        }
        else
        {
            _etiquetasPropias.Add(etiqueta);
        }
        _panelEtiquetasActuales.GetComponent<EtiquetasActuales>().UpdateEtiquetas();
    }

    #region boton
    public void SetPerfilData()
    {
        _name = _nameTxt.GetComponent<TMP_InputField>().text;
        _bio.Clear();
        _bio.Add(_bioTxt.GetComponent<TMP_InputField>().text);
        _edad = int.Parse(_edadTxt.GetComponent<TMP_InputField>().text);
        _manager.GetComponent<GameManager>().CambiarEscena(GameManager.GAME_STATE.SELECCION);
    }
    public void InitPanelEtiquetas()
    {
        foreach (String currentEt in _manager.GetComponent<Perfil>()._posibleEtiquetas)
        {
            GameObject newEt = Instantiate(_etiquetaGO, _panelEtiquetasParent.transform);
            newEt.name = currentEt;
            newEt.GetComponentInChildren<TextMeshProUGUI>().text = currentEt;
            newEt.GetComponent<Etiquetas>().SetPulsada(true);
            newEt.GetComponent<Etiquetas>().SetUser(gameObject);
            newEt.GetComponent<Etiquetas>().SetEtiqueta(currentEt);
        }
    }
    #endregion
}
