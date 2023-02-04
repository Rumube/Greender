using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EtiquetasActuales : MonoBehaviour
{
    public GameObject _etiquetaGO;
    public GameObject _perfilManager;
    public List<string> _actuales = new List<string>();
    public List<GameObject> _actualesGO = new List<GameObject>();
    public GameObject _parentEtiquetas;

    public void UpdateEtiquetas()
    {
        VaciarEtiquetas();
        LlenarEtiquetas();
    }
    private void VaciarEtiquetas()
    {
        List<GameObject> listAux = new List<GameObject>(_actualesGO);
        for (int i = 0; i < listAux.Count; i++)
        {
            Destroy(_actualesGO[i]);
        }
        _actuales.Clear();
    }
    private void LlenarEtiquetas()
    {
        _actuales = _perfilManager.GetComponent<PerfilPropio>()._etiquetasPropias;
        foreach (string currentEt in _actuales)
        {
            GameObject newEt = Instantiate(_etiquetaGO, _parentEtiquetas.transform);
            newEt.name = currentEt;
            newEt.GetComponentInChildren<TextMeshProUGUI>().text = currentEt;
            _actualesGO.Add(newEt);
        }
    }
}
