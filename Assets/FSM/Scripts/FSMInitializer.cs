using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSMInitializer : MonoBehaviour
{
    //aqui añadimos el boton y hacemos una llamada al metodo de RegisterButton ubicado en FSMbuttonDecision
    public FSMButtonDecision buttonDecision;
    [SerializeField] public Button button;


    void Start()
    {
        buttonDecision.RegisterButton(button);
    }
}
