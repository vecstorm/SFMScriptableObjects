using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActionOpening.asset", menuName = "FSM/Action/ActionOpening")]
public class ActionOpening : Action
{
    bool starter = false;
    Vector3 leftStart, rightStart, leftEnd, rightEnd;
    float elapsed = 0f;
    float duration = 1f;

    public override void Act(Controller controller)
    {
        DoorController1 door = controller.GetComponent<DoorController1>();
        if (door == null || door.doors.Length < 2) return;

        if (!starter)
        {
            starter = true;
            elapsed = 0f;
            door.openingFinished = false;

            // Usamos localPosition en todo
            leftStart = door.doors[0].transform.localPosition;
            rightStart = door.doors[1].transform.localPosition;

            leftEnd = leftStart + Vector3.left * 1f;
            rightEnd = rightStart + Vector3.right * 1f;
        }

        if (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            door.doors[0].transform.localPosition = Vector3.Lerp(leftStart, leftEnd, t);
            door.doors[1].transform.localPosition = Vector3.Lerp(rightStart, rightEnd, t);
            elapsed += Time.deltaTime;

            Debug.Log($"Opening... elapsed={elapsed:F2}, t={t:F2}");
        }
        else
        {
            door.doors[0].transform.localPosition = leftEnd;
            door.doors[1].transform.localPosition = rightEnd;
            door.openingFinished = true;
            starter = false;
            elapsed = 0f;

            Debug.Log("Opening finished.");
        }
    }
}
