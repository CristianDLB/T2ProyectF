using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform Jugadores;
    void Start()
    {
    }

    void Update()
    {
        var x = Jugadores.position.x + 4f;
        var y = Jugadores.position.y + 2f;
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
