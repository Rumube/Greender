using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    public void CargarEscena(Perfil perfil)
    {
        //SET DATA
        _name = perfil._name;
        _edad = perfil._edad;
        _distancia = perfil._distancia;
        _etiquetas = perfil._etiquetas;
        _bio = perfil._bio;
        //UPDATE UI

        _nombreTxt.text = _name;
        _edadTxt.text = _edad.ToString();
        _distanciaTxt.text = _distancia.ToString();

        foreach (String currentEt in perfil._etiquetas)
        {
            GameObject newEt = Instantiate(_etiquetaGO, _etiquetasParent.transform);
            newEt.name = currentEt;
            newEt.GetComponentInChildren<TextMeshProUGUI>().text = currentEt;
        }
    }
}
