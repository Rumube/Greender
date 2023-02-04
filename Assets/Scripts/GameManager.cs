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

    public void CambiarEscena(GAME_STATE newState)
    {
        _gameState = newState;
        //_inicio.SetActive(false);
        _seleccion.SetActive(false);
        //_perfilPropio.SetActive(false);
        _perfil.SetActive(false);
        //_chat.SetActive(false);
        //_movimiento.SetActive(false);
        //_cita.SetActive(false);
        //_fin.SetActive(false);

        switch (_gameState)
        {
            case GAME_STATE.INICIO:
                break;
            case GAME_STATE.SELECCION:
                _seleccion.SetActive(true);
                _seleccion.GetComponent<ImgPerfil>().CargarEscena(GetComponent<Perfil>());
                break;
            case GAME_STATE.PERFIL_PROPIO:
                break;
            case GAME_STATE.PERFIL:
                _perfil.SetActive(true);
                _perfil.GetComponent<PerfilUsuario>().CargarEscena(GetComponent<Perfil>());
                break;
            case GAME_STATE.CHAT:
                break;
            case GAME_STATE.MOVIMIENTO:
                break;
            case GAME_STATE.CITA:
                break;
            case GAME_STATE.FIN:
                break;
            default:
                break;
        }
    }
    #region Botones
    public void CargarSeleccionBoton()
    {
        CambiarEscena(GAME_STATE.SELECCION);
    }
    #endregion
}
