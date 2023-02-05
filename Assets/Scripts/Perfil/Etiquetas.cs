using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Etiquetas : MonoBehaviour
{
    private string _etiqueta;
    public bool _pulsable = false;
    public GameObject _perfilUser;
    public Sprite _normalSprite;
    public Sprite _selectedSprite;
    public bool _selected = false;
    private GameObject _manager;


    private void Start()
    {
        _manager = GameObject.FindGameObjectWithTag("Manager");
    }

    private void Update()
    {
        if (_selected)
        {
            GetComponent<Image>().sprite = _selectedSprite;
        }
        else
        {
            GetComponent<Image>().sprite = _normalSprite;
        }
    }

    public void SetEtiqueta(string etiqueta)
    {
        _etiqueta = etiqueta;
    }
    public string GetEtiqueta()
    {
        return _etiqueta;
    }
    public void SetPulsada(bool pulsable)
    {
        _pulsable = pulsable;
    }
    public void SetUser(GameObject user)
    {
        _perfilUser = user;
    }
    #region Boton
    public void EtiquetaPulsada()
    {
        if (_pulsable)
        {
            if(_selected)
            {
                _selected = false;
            }else if(!_selected && _manager.GetComponent<PerfilPropio>()._currentNumberEt < _manager.GetComponent<PerfilPropio>()._maxEt)
            {
                _selected = true;
            }
        }
        _manager.GetComponent<PerfilPropio>().CheckEtiquetas();
    }
    #endregion

}
