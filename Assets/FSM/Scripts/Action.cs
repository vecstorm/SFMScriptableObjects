using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Action.asset", menuName = "FSM/Action")]
public abstract class Action : ScriptableObject {
    public abstract void Act(Controller controller);
}
