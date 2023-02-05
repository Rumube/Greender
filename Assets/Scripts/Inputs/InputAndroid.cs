using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class InputAndroid : MonoBehaviour
{
    private GameObject _perfil = null;

    public GameObject _likeAnim;
    public GameObject _nopeAnim;
    public GameObject _imgAnim;
    public GameObject _textAnim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.touchCount > 0)
        {
            Touch touch = UnityEngine.Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    //INPUT
                    InputBegan(touch);
                    break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    //DRAG
                    InputDrag(touch);
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    //DROP
                    InputDrop();
                    break;
                default:
                    break;
            }
        }
    }

    private void InputBegan(Touch touch)
    {
        RaycastHit2D hit = Physics2D.Raycast(touch.position, -Vector2.up, Mathf.Infinity);
        if (hit)
        {
            if (hit.transform.gameObject.tag == "Cuerpo")
            {
                _perfil = hit.transform.gameObject;
                GetComponent<GameManager>()._seleccion.GetComponent<ImgPerfil>().SeleccionarPerfil();
            }
        }
    }
    private void InputDrag(Touch touch)
    {
        if (_perfil != null)
        {
            GetComponent<GameManager>()._seleccion.GetComponent<ImgPerfil>().MovePerfil(touch.position);
        }
    }
    private void InputDrop()
    {
        if (_perfil != null)
        {
            if (GetComponent<GameManager>()._seleccion.GetComponent<ImgPerfil>().GetInLike())
            {
                Like();
            }
            else if (GetComponent<GameManager>()._seleccion.GetComponent<ImgPerfil>().GetInNope())
            {
                Nope();
            }
            GetComponent<GameManager>()._seleccion.GetComponent<ImgPerfil>().Volver();

            _perfil = null;
        }
    }
    public void Like()
    {
        //LIKE!
        //LIGAR?
        _likeAnim.GetComponent<Animator>().Play("Like_Anim");
        if (!isMatch())
        {
            if (GetComponent<GameManager>()._gameState != GameManager.GAME_STATE.SELECCION)
            {
                GetComponent<GameManager>().CargarSeleccionBoton();
            }
        }
        else
        {
            print("Match!!");
        }
        GetComponent<Perfil>().GenerarNuevoPerfil();
    }
    public void Nope()
    {
        //NOPE!
        if (GetComponent<GameManager>()._gameState != GameManager.GAME_STATE.SELECCION)
        {
            GetComponent<GameManager>().CargarSeleccionBoton();
        }
        _nopeAnim.GetComponent<Animator>().Play("Nope_Anim");
        GetComponent<Perfil>().GenerarNuevoPerfil();
    }


    public bool isMatch()
    {
        bool result = false;
        int baseMatch = 0;
        int count = 0;

        foreach (string currentEt in GetComponent<PerfilPropio>()._etiquetas)
        {
            if (GetComponent<Perfil>()._etiquetas.Contains(currentEt))
            {
                count++;
            }
        }
        baseMatch += (3 * 10);

        int randomValue = Random.Range(baseMatch, 101);

        if(randomValue >= 90)
        {
            result = true;
        }
        print("Random Value" + randomValue);
        return result;
    }
}
