using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActionClosing.asset", menuName = "FSM/Action/ActionClosing")]
public class ActionClosing : Action
{
    bool starter = false;
    Vector3 leftStart, rightStart, leftEnd, rightEnd;
    float elapsed = 0f;
    float duration = 1f; //velocidad de apertura de la puerta

    public override void Act(Controller controller)
    {
        //obtenemos el doorcontroller ubicado en la puerta para poder conger los componentes de esta
        DoorController1 door = controller.GetComponent<DoorController1>();

        // Inicialización al entrar en el estado Closing
        if (!starter)
        {
            starter = true;
            elapsed = 0f;
            door.closingFinished = false;

            // Posiciones iniciales de las puertas
            leftStart = door.doors[0].transform.localPosition;
            rightStart = door.doors[1].transform.localPosition;

            // Posiciones finales de las puertas 
            leftEnd = leftStart + Vector3.right * 1f;
            rightEnd = rightStart + Vector3.left * 1f;
        }

        // movemos las puertas por frames
        if (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            door.doors[0].transform.localPosition = Vector3.Lerp(leftStart, leftEnd, t);
            door.doors[1].transform.localPosition = Vector3.Lerp(rightStart, rightEnd, t);
            elapsed += Time.deltaTime;

            Debug.Log($"Closing... elapsed={elapsed:F2}, t={t:F2}");
        }
        else
        {
            // Aseguramos que las puertas queden cerradas
            door.doors[0].transform.localPosition = leftEnd;
            door.doors[1].transform.localPosition = rightEnd;
            door.closingFinished = true;
            starter = false;
            elapsed = 0f;

            Debug.Log("Closing finished.");
        }
    }

}
