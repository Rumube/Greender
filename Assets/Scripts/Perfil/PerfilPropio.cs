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
    public TextMeshProUGUI _etiquetasTxt;
    public GameObject _etiquetaGO;
    public GameObject _etiquetasParent;
    private List<GameObject> _etiquetasList = new List<GameObject>();
    [Header("Panel Etiquetas")]
    public GameObject _panelEtiquetas;
    public GameObject _panelEtiquetasParent;
    private List<GameObject> _panelEtiquetasList;
    private GameManager _manager;
    public GameObject _panelEtiquetasActuales;
    public List<string> _etiquetasPropias = new List<string>();
    public int _maxEt = 0;
    public int _currentNumberEt = 0;

    // Start is called before the first frame update
    void Start()
    {
        _isUser = true;
        _name = null;
        _edad = 0;
        _etiquetasPropias.Clear();
        if (_manager == null)
        {
            _manager = GetComponent<GameManager>();
        }
        GenerarImagenRandom();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetData()
    {
        if (_name != "")
        {
            _nameTxt.GetComponent<TMP_InputField>().text = _name;
            _bioTxt.GetComponent<TMP_InputField>().text = _bio[0];
            _edadTxt.GetComponent<TMP_InputField>().text = _edad.ToString();
            SetEtiquetas();
        }
    }
    private void SetEtiquetas()
    {
        if (_etiquetasList != null)
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
        if (_panelEtiquetasList != null)
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
    public void GenerarImagenRandom()
    {
        _cuerpo.GetComponent<Image>().sprite = _posibleCuerpo[UnityEngine.Random.Range(0, _posibleCuerpo.Count - 1)];
        _ojos.GetComponent<Image>().sprite = _posibleOjos[UnityEngine.Random.Range(0, _posibleOjos.Count - 1)];
        _boca.GetComponent<Image>().sprite = _posibleBocas[UnityEngine.Random.Range(0, _posibleBocas.Count - 1)];
        _brazos.GetComponent<Image>().sprite = _posibleBrazos[UnityEngine.Random.Range(0, _posibleBrazos.Count - 1)];
    }
    public void SaveDataInit()
    {
        _name = _nameTxt.GetComponent<TMP_InputField>().text;
        _edad = int.Parse(_edadTxt.GetComponent<TMP_InputField>().text);
        //NEXT SCENE
        InitDataEtiquetas();
    }
    #endregion
    private void InitDataEtiquetas()
    {
        foreach (string currentET in GetComponent<Perfil>()._posibleEtiquetas)
        {
            GameObject newEt = Instantiate(_etiquetaGO, _etiquetasParent.transform);
            newEt.name = currentET;
            newEt.GetComponentInChildren<TextMeshProUGUI>().text = currentET;
            newEt.GetComponent<Etiquetas>().SetPulsada(true);
            _etiquetasList.Add(newEt);
        }
        string text = _currentNumberEt + " - " + _maxEt;
        _etiquetasTxt.text = text;
    }
    public void CheckEtiquetas()
    {
        int count = 0;
        _etiquetas.Clear();
        foreach (GameObject currentEt in _etiquetasList)
        {
            if (currentEt.GetComponent<Etiquetas>()._selected)
            {
                count++;
                _etiquetas.Add(currentEt.GetComponent<Etiquetas>().GetEtiqueta());
            }
        }
        _currentNumberEt = count;
        string text = _currentNumberEt + " - " + _maxEt;
        _etiquetasTxt.text = text;
    }
}
