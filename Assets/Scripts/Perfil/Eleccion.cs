using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eleccion : MonoBehaviour
{
    public bool _isLike;
    public GameObject _manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Selector")
        {
            if (_isLike)
            {
                //LIKE
                print("Like");
                _manager.GetComponent<GameManager>()._seleccion.GetComponent<ImgPerfil>().SetInLike(true);
            }
            else
            {
                //NOPE
                print("Nope");
                _manager.GetComponent<GameManager>()._seleccion.GetComponent<ImgPerfil>().SetInNope(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Selector")
        {
            if (_isLike)
            {
                //LIKE
                print("Like");
                _manager.GetComponent<GameManager>()._seleccion.GetComponent<ImgPerfil>().SetInLike(false);
            }
            else
            {
                //NOPE
                print("Nope");
                _manager.GetComponent<GameManager>()._seleccion.GetComponent<ImgPerfil>().SetInNope(false);
            }
        }
    }
}
