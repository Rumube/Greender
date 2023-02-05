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
    private bool _inLike = false;
    private bool _inNope = false;

    [Header("Parfil Data")]
    public TextMeshProUGUI _nombreTxt;
    public TextMeshProUGUI _edadTxt;
    public TextMeshProUGUI _distanciaTxt;

    // Start is called before the first frame update
    void Start()
    {
        if(_imagen != null)
        {
            _initPos = _imagen.transform.position;
        }
        if (_manager == null)
        {
            _manager = GameObject.FindGameObjectWithTag("Manager");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_return)
        {
            _imagen.transform.position = Vector2.Lerp(_imagen.transform.position, _initPos, 7 * Time.deltaTime);
            if (_imagen.transform.position == _initPos)
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
        _finSelect = Time.realtimeSinceStartup + 0.09f;
    }
    public void CargarEscena(Perfil perfil)
    {
        _nombreTxt.text = perfil._name;
        _edadTxt.text = perfil._edad.ToString();
        _distanciaTxt.text = perfil._distancia.ToString();
    }

    public void SetInLike(bool inLike)
    {
        _inLike = inLike;
    }
    public void SetInNope(bool inNope)
    {
        _inNope = inNope;
    }
    public bool GetInLike()
    {
        return _inLike;
    }

    public bool GetInNope()
    {
        return _inNope;
    }

    #region Boton
    public void CargarPerfilPropio()
    {
        _manager.GetComponent<GameManager>().CargarPerfilPropio();
    }
    #endregion
}
