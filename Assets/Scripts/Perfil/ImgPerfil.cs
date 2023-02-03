using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ImgPerfil : MonoBehaviour
{
    private Vector3 _initPos;
    private bool _return = false;
    // Start is called before the first frame update
    void Start()
    {
        _initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_return)
        {
            transform.position = Vector2.Lerp(transform.position, _initPos, 7 * Time.deltaTime);
            if(transform.position == _initPos)
            {
                _return = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    public void MovePerfil(Vector2 clicPos)
    {
        transform.position = new Vector2(clicPos.x, transform.position.y);
    }
    public void Volver()
    {
        _return = true;
    }
}
