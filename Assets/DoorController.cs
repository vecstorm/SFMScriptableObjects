using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] public enum DoorState { CLOSED, OPENING, OPEN, CLOSING }
    [SerializeField] GameObject[] doors;
    [SerializeField] DoorState currentState = DoorState.CLOSED;

    // Método que usará el botón
    public void OpenCloseDoor()
    {
        if (currentState == DoorState.CLOSED)
            ChangeState(DoorState.OPENING);
        else if (currentState == DoorState.OPEN)
            ChangeState(DoorState.CLOSING);
    }

    // Cambiar de estado con control de enter/exit
    public void ChangeState(DoorState newState)
    {
        ExitState();       // Lógica al salir del estado actual
        currentState = newState;       // Cambio de estado
        EnterState(currentState);      // Lógica al entrar en el nuevo estado
    }

    // Lógica al entrar en un estado
    private void EnterState(DoorState newState)
    {
        switch (newState)
        {
            case DoorState.OPENING:
                StartCoroutine(DoorStateMovement(DoorState.OPENING));
                break;

            case DoorState.CLOSING:
                StartCoroutine(DoorStateMovement(DoorState.CLOSING));
                break;

            case DoorState.OPEN:
                Debug.Log("Puerta abierta");
                break;

            case DoorState.CLOSED:
                Debug.Log("Puerta cerrada");
                break;
        }
    }

    // Lógica al salir de un estado
    private void ExitState()
    {
        switch (currentState)
        {
            case DoorState.OPENING:                
                break;
            case DoorState.CLOSING:               
                break;
            case DoorState.OPEN:                
                break;
            case DoorState.CLOSED:            
                break;
        }
    }

    // Corrutina para mover las puertas
    IEnumerator DoorStateMovement(DoorState targetState)
    {
        float duration = 1f;
        float elapsed = 0f;

        Vector3 leftStart = doors[0].transform.localPosition;
        Vector3 rightStart = doors[1].transform.localPosition;

        Vector3 leftEnd, rightEnd;

        if (targetState == DoorState.OPENING)
        {
            leftEnd = leftStart + Vector3.left * 1f;
            rightEnd = rightStart + Vector3.right * 1f;
        }
        else // CLOSING
        {
            leftEnd = leftStart - Vector3.left * 1f;
            rightEnd = rightStart - Vector3.right * 1f;
        }

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            doors[0].transform.localPosition = Vector3.Lerp(leftStart, leftEnd, t);
            doors[1].transform.localPosition = Vector3.Lerp(rightStart, rightEnd, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Al terminar la animación, cambiamos al estado final
        ChangeState(targetState == DoorState.OPENING ? DoorState.OPEN : DoorState.CLOSED);
    }
}
