using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "OpeningDecision.asset", menuName = "FSM/Decision/OpeningDecision")]
public class OpeningDecision : Decision
{
    [SerializeField] private bool hasBeenClicked = false;

    public void RegisterButton(Button uiButton)
    {
        uiButton.onClick.AddListener(() => hasBeenClicked = true);
        
    }
    public override bool Decide(Controller controller)
    {
        DoorController1 door = controller.GetComponent<DoorController1>();
        return door.openingFinished;
    }

}
