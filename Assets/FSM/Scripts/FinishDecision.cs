using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FinishDecision.asset", menuName = "FSM/Decision/FinishDecision")]
public class FinishDecision : Decision
{
    public override bool Decide(Controller controller)
    {
        DoorController1 door = controller.GetComponent<DoorController1>();
        if (door == null) return false;

        Debug.Log("Decision checked: closingFinished = " + door.closingFinished);
        return door.closingFinished;
    }
}
