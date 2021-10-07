using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparos : MonoBehaviour
{
    public float velocidadX = 10f;
    private const string ENEMIGO = "Enemigo";

    private Rigidbody2D Body;
    //private Puntajes Score;

    public static int daño;
    public static int daño2;
    public int refeDaño = 1;
    public int refeDaño2 = 2;

    void Start()
    {
        daño = refeDaño;
        daño2 = refeDaño2;
        Body = GetComponent<Rigidbody2D>();
        //Score = FindObjectOfType<Puntajes>();
        Destroy(this.gameObject, 2);
    }

    void Update()
    {
        Body.velocity = new Vector2(velocidadX, Body.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(ENEMIGO))
        {
            Destroy(this.gameObject);
            //Score.SumPunEne(5);
            //Debug.Log("Enemigo: " + Score.getScoreEnem());
        }
    }

}
