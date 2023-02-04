using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perfil : MonoBehaviour
{
    [Header("Test")]
    public bool _generarBio = false;
    [Header("Datos Perfil Actual")]
    public bool _isUser = false;
    public string _name = "";
    public List<string> _etiquetas = new List<string>();
    public List<string> _bio = new List<string>();
    public int _edad = 0;
    public int _distancia = 0;
    [Header("Imagen Perfil")]
    public Sprite _cuerpo;
    public Sprite _ojos;
    public Sprite _boca;
    public Sprite _brazos;
    public Sprite _piernas;
    public Sprite _fondo;

    [Header("PosibleImg")]
    public List<Sprite> _posibleCuerpo = new List<Sprite>();
    public List<Sprite> _posibleOjos = new List<Sprite>();
    public List<Sprite> _posibleBocas = new List<Sprite>();
    public List<Sprite> _posibleBrazos = new List<Sprite>();
    public List<Sprite> _posiblePiernas = new List<Sprite>();
    public List<Sprite> _posibleFondo = new List<Sprite>();
    [Header("Datos Posibles")]
    public List<string> _posibleEtiquetas = new List<string>();
    public List<string> _posibleNombres = new List<string>();
    public List<string> _posibleBio = new List<string>();

    private void Start()
    {
        GenerarNuevoPerfil();
    }

    // Update is called once per frame
    void Update()
    {
        if (_generarBio)
        {
            _generarBio= false;
            GenerarNuevoPerfil();
        }
    }

    public void GenerarNuevoPerfil()
    {
        _bio.Clear();
        _etiquetas.Clear();

        GenerarNombre();
        GenerarEtiquetas();
        GenerateBio();
        GenerarImagen();
        GenerateEdad();
        GenerateDistancia();
        CargarData();
        GetComponent<GameManager>()._seleccion.GetComponent<ImgPerfil>().CargarEscena(this);
    }

    private void GenerarNombre()
    {
        _name = _posibleNombres[Random.Range(0, _posibleNombres.Count - 1)];
    }
    private void GenerarEtiquetas()
    {
        int numEtiquetas = Random.Range(1, 4);
        int count = 0;
        for (int i = 0; i < numEtiquetas; i++)
        {
            do
            {
                string newEtiqueta = "";
                if (count == 0)
                {
                    newEtiqueta = _posibleEtiquetas[Random.Range(0, _posibleEtiquetas.Count - 1)];
                }
                else
                {
                    newEtiqueta = _posibleEtiquetas[count];
                }
                if (!_etiquetas.Contains(newEtiqueta))
                {
                    _etiquetas.Add(newEtiqueta);
                }
                else
                {
                    count++;
                    if (count >= _posibleEtiquetas.Count)
                    {
                        count = 0;
                    }
                }
            } while (false);
        }
    }
    private void GenerateBio()
    {
        int numBio = Random.Range(1, 4);
        int count = 0;
        for (int i = 0; i < numBio; i++)
        {
            do
            {
                string newBio = "";
                if (count == 0)
                {
                    newBio = _posibleBio[Random.Range(0, _posibleBio.Count - 1)];
                }
                else
                {
                    newBio = _posibleBio[count];
                }
                if (!_bio.Contains(newBio))
                {
                    _bio.Add(newBio);
                }
                else
                {
                    count++;
                    if (count >= _posibleBio.Count)
                    {
                        count = 0;
                    }
                }
            } while (false);
        }
    }
    private void GenerateEdad()
    {
        //USAR EDAD DEL JUGADOR
        _edad = Random.Range(20, 61);
    }
    private void GenerateDistancia()
    {
        _distancia = Random.Range(0, 301);
    }
    private void GenerarImagen()
    {
        //TODO: GENERAR IMAGEN
    }
    private void CargarData()
    {

    }
}
