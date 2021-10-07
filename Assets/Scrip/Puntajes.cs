using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntajes : MonoBehaviour
{
    public Text Vida;
    public Text Enemigos;
    public Text Tiempo;

    private int punVida = 3;
    private int punEnemigos = 5;
    private int punTiempo = 60;



    private void Start()
    {
        Vida.text = "Vida Robot: " + punVida;
        Enemigos.text = "Hay " + punEnemigos + "Enemigos";
        Tiempo.text = "Teimpo: " + punTiempo +"Seg";
    }


    //*******[ENEMIGOS]*******************
    public int getScoreEnem()
    {
        return this.punEnemigos;
    }
    public void SumPunEne(int score)
    {
        this.punEnemigos += score;
        Enemigos.text = "Hay " + punEnemigos + "Enemigos";
    }

    //**************************

    public int getScoreVida()
    {
        return this.punVida;
    }
    public void SumPunVida(int score)
    {
        this.punVida += score;
        Vida.text = "Vida Robot: " + punVida;
    }

}
