using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

 [CreateAssetMenu(fileName="FSMButtonDecision.asset", menuName = "FSM/Decision/ButtonDecision")]

public class FSMButtonDecision : Decision
{
    //con este script registramos si el boton ha sido pulsado, la decision tanto de open
    //como de close
    [SerializeField] private bool hasBeenClicked = false;

    public void RegisterButton(Button uiButton)
    {
        uiButton.onClick.AddListener(() => hasBeenClicked = true);
    }

    public override bool Decide(Controller controller)
    {
        if (!hasBeenClicked) return false;

        hasBeenClicked = false;

        return true;
    }
}
