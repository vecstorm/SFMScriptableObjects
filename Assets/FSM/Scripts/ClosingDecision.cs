using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ClosingDecision.asset", menuName = "FSM/Decision/ClosingDecision")]
public class ClosingDecision : Decision
{
    [SerializeField] private bool hasBeenClicked = false;

    public void RegisterButton(Button uiButton)
    {
        uiButton.onClick.AddListener(() => hasBeenClicked = true);
    }

    public override bool Decide(Controller controller)
    {
        Debug.Log("ClosingDecision checked");

        if (!hasBeenClicked)
            return false;

        // Consumimos el click para que solo se use una vez
        hasBeenClicked = false;
        return true;
    }

}
