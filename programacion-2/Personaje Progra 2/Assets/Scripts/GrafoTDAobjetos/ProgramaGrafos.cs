using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramaGrafos : MonoBehaviour
{
    
    Dictionary<int, Obj_Nodos> dicNodos;

    // diccionario de aristas
    Dictionary<int, Obj_Aristas> dicAristas;
    GrafoMA grafoEst;
    // vector con id de los vértices (nodos)
    int[] vertices = { 10, 12, 13, 14, 15, 61, 27, 83, 19, 17 };
    // vector de aristas - vertices origen
    int[] aristas_origen = { 10, 12, 12, 13, 13, 14, 13, 15, 15, 61, 15, 27, 12, 83, 83, 17, 83, 19 };
    // vector de aristas - vertices destino
    int[] aristas_destino = { 12, 10, 13, 12, 14, 13, 15, 13, 61, 15, 27, 15, 83, 12, 17, 83, 19, 83 };
    // vector de aristas - pesos
    int[] aristas_pesos = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

    private void Awake()
    {
        // diccionario de nodos
        dicNodos = new Dictionary<int, Obj_Nodos>();

        // diccionario de aristas
        dicAristas = new Dictionary<int, Obj_Aristas>();

        // creo la estructura de grafos (estatica)
        grafoEst = new GrafoMA();

        // inicializo TDA
        grafoEst.InicializarGrafo();

        for (int i = 0; i < vertices.Length; i++)
        {
            // creo el objeto que va a guardar los datos del nodo
            Obj_Nodos n1 = new Obj_Nodos();
            n1.id = vertices[i];

            // agrego el objeto al diccionario de nodos
            dicNodos.Add(n1.id, n1);
        }

        // creo los objetos aristas
        for (int i = 0; i < aristas_pesos.Length; i++)
        {
            // objeto arista
            Obj_Aristas a1 = new Obj_Aristas();
            a1.id = i + 10;
            a1.idOrig = aristas_origen[i];
            a1.idDest = aristas_destino[i];
            a1.peso = aristas_pesos[i];

            // agrego aristas al diccionario
            dicAristas.Add(a1.id, a1);
        }
        // cargo el TDA Grafos a partir de los diccionarios  //
        // agrego las nodos al TDA_Grafo a partir del diccionario
        foreach (KeyValuePair<int, Obj_Nodos> nodo in dicNodos)
        {
            // agrego los vértices (nodos)
            grafoEst.AgregarVertice(nodo.Key);
        }

        // agrego las aristas al TDA_Grafo a partir del diccionario
        foreach (KeyValuePair<int, Obj_Aristas> arista in dicAristas)
        {
            // agrego las aristas
            grafoEst.AgregarArista(arista.Key, arista.Value.idOrig, arista.Value.idDest, arista.Value.peso);
        }
        
    }
}
