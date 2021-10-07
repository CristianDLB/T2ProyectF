using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotControl : MonoBehaviour
{

    private SpriteRenderer Render;
    private Rigidbody2D Body;
    private Animator Animar;

    private const int Normal = 0;
    private const int Disparo = 1;
    private const int Desliza = 2;
    private const int Corre = 3;
    private const int Salto = 4;
    private const int Muerte = 5;
    private const int DispCorre = 6;


    public GameObject Dis;
    public GameObject DisIzq;

    public GameObject Dispaaaro;
    public GameObject DispaaaroIzq;

    private float Tiempo = 0;
    private const string LLAVES = "Llaves";
    private const string MUERTES = "Muerte";
    private const string FINAL = "FinJuego";
    private const string ENEMIGOS = "Enemigo";

    //private Puntajes Scors;
    public int VidasRobot = 3;
    void Start()
    {
        Render = GetComponent<SpriteRenderer>();
        Body = GetComponent<Rigidbody2D>();
        Animar = GetComponent<Animator>();
        //Scors = FindObjectOfType<Puntajes>();
    }


    void Update()
    {
        Body.velocity = new Vector2(0, Body.velocity.y);
        RealizarAnimacion(Normal);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Body.velocity = new Vector2(12, Body.velocity.y);
            Render.flipX = false;
            RealizarAnimacion(Corre);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Body.velocity = new Vector2(-12, Body.velocity.y);
            Render.flipX = true;
            RealizarAnimacion(Corre);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Body.AddForce(Vector2.up * 22, ForceMode2D.Impulse);
            RealizarAnimacion(Salto);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            RealizarAnimacion(Desliza);
        }
        if (Input.GetKey(KeyCode.C))
        {
            Tiempo += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            if (Tiempo < 2)
            {
                Debug.Log("Disparo Bala 1");
                RealizarAnimacion(Disparo);
                var disparoXD = Render.flipX ? DisIzq : Dis;
                var posicion = new Vector2(transform.position.x, transform.position.y);
                Instantiate(disparoXD, posicion, Dis.transform.rotation);
            }
            else if (Tiempo < 5)
            {
                Debug.Log("Disapro Bala 2");
                RealizarAnimacion(Disparo);
                var disparoXD = Render.flipX ? DispaaaroIzq : Dispaaaro;
                var posicion = new Vector2(transform.position.x, transform.position.y);
                Instantiate(disparoXD, posicion, Dispaaaro.transform.rotation);

            }
            Tiempo =0;
        }

    }

    private void RealizarAnimacion(int Animaciones)
    {
        Animar.SetInteger("Estado", Animaciones);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(LLAVES))
        {
            Debug.Log("Choque");
            SceneManager.LoadScene("Ecena2");
        }

        if (other.gameObject.CompareTag(MUERTES))
        {
            Debug.Log("<<< Estoy Muerto >>>");
            SceneManager.LoadScene("SampleScene");
        }

        if (other.gameObject.CompareTag(FINAL))
        {
            Destroy(other.gameObject);
            Debug.Log("<<<< FIN DEL JUEGO >>>>");
        }

        if (other.gameObject.CompareTag(ENEMIGOS))
        {
            VidasRobot -= Enemigo.dañoRobot;
            //Scors.MenosVida(1);
            //Debug.Log("Vida: " + Scors.getScoreVidas());
            Debug.Log("Tengo Menos Vida");
            if (VidasRobot <= 0)
            {
                Debug.Log("<<< Estoy Muerto >>>");
                SceneManager.LoadScene("SampleScene");
            }

        }

    }

}
