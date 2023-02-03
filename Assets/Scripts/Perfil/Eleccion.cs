using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eleccion : MonoBehaviour
{
    public bool _isLike;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Selector")
        {
            if (_isLike)
            {
                //LIKE
                print("Like");
            }
            else
            {
                //NOPE
                print("Nope");
            }
        }
    }
}
