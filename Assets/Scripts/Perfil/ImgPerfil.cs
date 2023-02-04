using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ImgPerfil : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject _manager;
    public GameObject _imagen;

    private Vector3 _initPos;
    private bool _return = false;
    public bool _seleccionado = false;
    private float _finSelect = 0;

    [Header("Parfil Data")]
    public TextMeshProUGUI _nombreTxt;
    public TextMeshProUGUI _edadTxt;
    public TextMeshProUGUI _distanciaTxt;

    // Start is called before the first frame update
    void Start()
    {
        _initPos = _imagen.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_return)
        {
            _imagen.transform.position = Vector2.Lerp(_imagen.transform.position, _initPos, 7 * Time.deltaTime);
            if(_imagen.transform.position == _initPos)
            {
                _return = false;
            }
        }

        if (Time.realtimeSinceStartup >= _finSelect)
        {
            _seleccionado = false;
        }
    }
    public void MovePerfil(Vector2 clicPos)
    {
        _imagen.transform.position = new Vector2(clicPos.x, _imagen.transform.position.y);
    }
    public void Volver()
    {
        _return = true;
        if (_seleccionado)
        {
            _manager.GetComponent<GameManager>().CambiarEscena(GameManager.GAME_STATE.PERFIL);
        }
    }
    public void SeleccionarPerfil()
    {
        _seleccionado = true;
        _finSelect = Time.realtimeSinceStartup + 0.2f;
    }
    public void CargarEscena(Perfil perfil)
    {
        _nombreTxt.text = perfil._name;
        _edadTxt.text = perfil._edad.ToString();
        _distanciaTxt.text = perfil._distancia.ToString();
    }
}
