using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject _cuerpo;
    public GameObject _ojos;
    public GameObject _boca;
    public GameObject _brazos;

    public Sprite _cuerpoS;
    public Sprite _ojosS;
    public Sprite _bocaS;
    public Sprite _brazosS;

    [Header("PosibleImg")]
    public List<Sprite> _posibleCuerpo = new List<Sprite>();
    public List<Sprite> _posibleOjos = new List<Sprite>();
    public List<Sprite> _posibleBocas = new List<Sprite>();
    public List<Sprite> _posibleBrazos = new List<Sprite>();

    [Header("Datos Posibles")]
    public List<string> _posibleEtiquetas = new List<string>();
    public List<string> _posibleNombres = new List<string>();
    public List<string> _posibleBio = new List<string>();
    public List<string> _posibleFinal = new List<string>();

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_generarBio)
        {
            _generarBio = false;
            GenerarNuevoPerfil();
        }
    }

    public void GenerarNuevoPerfil()
    {
        if (!_isUser)
        {
            _bio.Clear();
            _etiquetas.Clear();

            GenerarNombre();
            GenerarEtiquetas();
            GenerateBio();
            GenerateEdad();
            GenerateDistancia();
            GenerarImagen();
            if (GetComponent<GameManager>()._gameState != GameManager.GAME_STATE.SELECCION)
            {
                GetComponent<GameManager>().CargarSeleccionBoton();
            }
            GetComponent<GameManager>()._seleccion.GetComponent<ImgPerfil>().CargarEscena(this);
        }

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
        _cuerpo = GameObject.FindGameObjectWithTag("Cuerpo");
        _ojos = GameObject.FindGameObjectWithTag("Ojos");
        _boca = GameObject.FindGameObjectWithTag("Boca");
        _brazos = GameObject.FindGameObjectWithTag("Brazos");

        _cuerpoS = _posibleCuerpo[Random.Range(0, _posibleCuerpo.Count - 1)];
        _ojosS = _posibleOjos[Random.Range(0, _posibleOjos.Count - 1)];
        _bocaS = _posibleBocas[Random.Range(0, _posibleBocas.Count - 1)];
        _brazosS = _posibleBrazos[Random.Range(0, _posibleBrazos.Count - 1)];

        _cuerpo.GetComponent<Image>().sprite = _cuerpoS;
        _ojos.GetComponent<Image>().sprite = _ojosS;
        _boca.GetComponent<Image>().sprite = _bocaS;
        _brazos.GetComponent<Image>().sprite = _brazosS;
    }
}
