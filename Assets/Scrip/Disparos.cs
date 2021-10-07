using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparos : MonoBehaviour
{
    public float velocidadX = 10f;
    private const string ENEMIGO = "Enemigo";

    private Rigidbody2D Body;
    //private Puntajes Score;

    public static int da�o;
    public static int da�o2;
    public int refeDa�o = 1;
    public int refeDa�o2 = 2;

    void Start()
    {
        da�o = refeDa�o;
        da�o2 = refeDa�o2;
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
