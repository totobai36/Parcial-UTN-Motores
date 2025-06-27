using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 checkpointPosition;
    private Quaternion checkpointRotation;

    private void Start()
    {
        checkpointPosition = transform.position;
        checkpointRotation = transform.rotation;
    }

    public void SetCheckpoint(Vector3 position, Quaternion rotation)
    {
        checkpointPosition = position;
        checkpointRotation = rotation;
    }

    public void Respawn()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.enabled = false; // para evitar errores con el movimiento
        }

        transform.position = checkpointPosition;
        transform.rotation = checkpointRotation;

        if (controller != null)
        {
            controller.enabled = true;
        }
    }
}
