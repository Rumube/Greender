using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GAME_STATE
    {
        INICIO,
        SELECCION,
        PERFIL_PROPIO,
        PERFIL,
        CHAT,
        MOVIMIENTO,
        CITA,
        FIN
    }
    public GAME_STATE _gameState = GAME_STATE.INICIO;
    [Header("Escenas")]
    public GameObject _inicio;
    public GameObject _seleccion;
    public GameObject _perfilPropio;
    public GameObject _perfil;
    public GameObject _chat;
    public GameObject _movimiento;
    public GameObject _cita;
    public GameObject _fin;

    public List<AudioClip> _clips = new List<AudioClip>();
    public AudioClip _transitionClip;
    public AudioClip _currentClip;

    private void Start()
    {
        StartTruck();
    }

    public void CambiarEscena(GAME_STATE newState)
    {
        _gameState = newState;
        _inicio.SetActive(false);
        _seleccion.SetActive(false);
        _perfilPropio.SetActive(false);
        _perfil.SetActive(false);
        _chat.SetActive(false);
        _movimiento.SetActive(false);
        _cita.SetActive(false);
        //_fin.SetActive(false);

        switch (_gameState)
        {
            case GAME_STATE.INICIO:
                _inicio.SetActive(true);
                break;
            case GAME_STATE.SELECCION:
                _seleccion.SetActive(true);
                _seleccion.GetComponent<ImgPerfil>().CargarEscena(GetComponent<Perfil>());
                break;
            case GAME_STATE.PERFIL_PROPIO:
                _perfilPropio.SetActive(true);
                //_perfilPropio.GetComponent<PerfilPropio>().SetData();
                print("Perfil Propio");
                _perfil.GetComponent<PerfilUsuario>().CargarEscena(GetComponent<PerfilPropio>());
                break;
            case GAME_STATE.PERFIL:
                _perfil.SetActive(true);
                print("Perfil Otro");
                _perfil.GetComponent<PerfilUsuario>().CargarEscena(GetComponent<Perfil>());
                break;
            case GAME_STATE.CHAT:
                _currentClip = _clips[1];
                StartTruck();
                _chat.SetActive(true);
                break;
            case GAME_STATE.MOVIMIENTO:
                _currentClip = _clips[2];
                StartTruck();
                _movimiento.SetActive(true);
                break;
            case GAME_STATE.CITA:
                _currentClip = _clips[3];
                StartTruck();
                _cita.SetActive(true);
                break;
            case GAME_STATE.FIN:
                break;
            default:
                break;
        }
    }

    public void StartTruck()
    {
        StartCoroutine(esperaClip());
    }

    public IEnumerator esperaClip()
    {

        GetComponent<AudioSource>().clip = _transitionClip;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.7f);
        GetComponent<AudioSource>().clip = _currentClip;
        GetComponent<AudioSource>().Play();
    }

    #region Botones
    public void CargarSeleccionBoton()
    {
        CambiarEscena(GAME_STATE.SELECCION);
    }
    public void CargarPerfilPropio()
    {
        CambiarEscena(GAME_STATE.PERFIL_PROPIO);
    }
    public void Cerrar()
    {
        Application.Quit();
    }
    #endregion
}
