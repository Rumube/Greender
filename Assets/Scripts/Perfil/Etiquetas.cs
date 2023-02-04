using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Etiquetas : MonoBehaviour
{
    private string _etiqueta;
    public bool _pulsable = false;
    public GameObject _perfilUser;
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
            _perfilUser.GetComponent<PerfilPropio>().EtiquetaPulsada(_etiqueta);
        }
    }
    #endregion

}
