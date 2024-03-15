using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorNivel : MonoBehaviour
{
   [SerializeField] private GameObject[] partesNivel;
   [SerializeField] private float distanciaMinima;
   [SerializeField] private Transform puntoFinal;
   [SerializeField] private int cantidadInicial;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < cantidadInicial; i++)
        {
            GenerarParteNivel();
        }
    }

    private void Update()
    {
        if (Vector2.Distance(player.position, puntoFinal.position)<distanciaMinima)
        {
            GenerarParteNivel();
        }
        
    }

    private void GenerarParteNivel()
    {
        int numeroAleatorio = Random.Range(0, partesNivel.Length);
        GameObject nivel = Instantiate(partesNivel[numeroAleatorio], puntoFinal.position, Quaternion.identity);
        puntoFinal = BuscarPuntoFinal(nivel, "PuntoFinal");
    }

    private Transform BuscarPuntoFinal(GameObject parteNivel, string etiqueta)
    {
        Transform punto = null;

        foreach (Transform ubicacion in parteNivel.transform)
        {
            if(ubicacion.CompareTag(etiqueta))
            {
                punto = ubicacion;
                break;
            }
        }
        return punto;
    }
}
