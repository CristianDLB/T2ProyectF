using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private SpriteRenderer Render;
    private Rigidbody2D Body;
    private Animator Animar;

    public float Maxveloz = 4f;
    public float veloz = 4f;
    private const string DISPARO1 = "Disp1";
    private const string DISPARO2 = "Disp2";

    private const int Corre = 0;
    private const int Muertos =1;

    public int Vida1 = 3;
    public int Valor = 3;

    public static int dañoRobot;
    public int refeDañoR = 1;

    void Start()
    {
        dañoRobot = refeDañoR;
        Render = GetComponent<SpriteRenderer>();
        Body = GetComponent<Rigidbody2D>();
        Animar = GetComponent<Animator>();
        //Score = FindObjectOfType<Puntajes>();
    }


    void Update()
    {
        Body.AddForce(Vector2.right * veloz);
        float limitar = Mathf.Clamp(Body.velocity.x, -Maxveloz, Maxveloz);
        Body.velocity = new Vector2(limitar, Body.velocity.y);
        RealizarAnimacion(Corre);

        if (Body.velocity.x > -0.01f && Body.velocity.x < 0.01f)
        {
            veloz = -veloz;
            Body.velocity = new Vector2(veloz, Body.velocity.y);
            Render.flipX = true;
        }
        if (veloz < 0)
        {
            Render.flipX = true;
        }
        if (veloz > 0)
        {
            Render.flipX = false;
        }
    }

    private void RealizarAnimacion(int Animaciones)
    {
        Animar.SetInteger("Estado1", Animaciones);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(DISPARO1))
        {
            Vida1 -= Disparos.daño;
            Debug.Log("Tengo Menos Vida");
            if (Vida1 <= 0)
            {
                //Scors.MenosVida(1);
                Destroy(this.gameObject);
                Debug.Log("Muerto");
            }

        }

        if ( other.gameObject.CompareTag(DISPARO2))
        {
            Vida1 -= Disparos.daño2;
            Debug.Log("Tengo Menos Vida");
            if (Vida1 <= 0)
            {
                //Scors.MenosVida(1);
                Destroy(this.gameObject);
                Debug.Log("Muerto");
            }

        }
    }

}
