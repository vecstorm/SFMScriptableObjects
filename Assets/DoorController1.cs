using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController1 : MonoBehaviour
{//Script usado para poder añadir las puertas individuales
 //y las variables para saber si se ha acabdo de abrir o cerrar

    [SerializeField] public GameObject[] doors;

    [SerializeField] public bool openingFinished = false;
    [SerializeField] public bool closingFinished = false;

}
