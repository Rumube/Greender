using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PerfilUsuario : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject _etiquetasParent;
    public GameObject _etiquetaGO;
    [Header("Datos Perfil Actual")]
    private string _name = "";
    private List<string> _etiquetas = new List<string>();
    private List<string> _bio = new List<string>();
    private int _edad = 0;
    private int _distancia = 0;

    [Header("Interfaz")]
    public TextMeshProUGUI _nombreTxt;
    public TextMeshProUGUI _bioTxt;
    public TextMeshProUGUI _distanciaTxt;
    public TextMeshProUGUI _edadTxt;

    [Header("Foto")]
    public GameObject _cuerpo;
    public GameObject _ojos;
    public GameObject _boca;
    public GameObject _brazos;

    public Sprite _cuerpoS;
    public Sprite _ojosS;
    public Sprite _bocaS;
    public Sprite _brazosS;

    public void CargarEscena(Perfil perfil)
    {
        //SET DATA
        _name = perfil._name;
        _edad = perfil._edad;
        _distancia = perfil._distancia;
        _etiquetas = perfil._etiquetas;
        _bio = perfil._bio;

        _cuerpoS = perfil._cuerpoS;
        _ojos = perfil._ojos;
        _bocaS= perfil._bocaS;
        _brazosS = perfil._brazosS;

        _cuerpo.GetComponent<Image>().sprite = _cuerpoS;
        _ojos.GetComponent<Image>().sprite = _ojosS;
        _boca.GetComponent<Image>().sprite = _bocaS;
        _brazos.GetComponent<Image>().sprite = _brazosS;

        //UPDATE UI

        _nombreTxt.text = _name;
        _edadTxt.text = _edad.ToString() + " días";
        _distanciaTxt.text = "A " + _distancia.ToString() + " huertos de ti";
        BorrarEtiquetas();
        foreach (String currentEt in perfil._etiquetas)
        {
            GameObject newEt = Instantiate(_etiquetaGO, _etiquetasParent.transform);
            newEt.name = currentEt;
            newEt.GetComponentInChildren<TextMeshProUGUI>().text = currentEt;
        }
        string newBio = "";
        foreach (string currentBio in _bio)
        {
            newBio += "\n -" + currentBio;
        }
        _bioTxt.text = newBio;
    }

    private void BorrarEtiquetas()
    {
        foreach (Transform currentChild in _etiquetasParent.transform)
        {
            GameObject.Destroy(currentChild.gameObject);
        }
    }

    private void CargarFoto()
    {

    }
}
