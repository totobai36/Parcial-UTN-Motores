using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSmoothTime = 0.1f;
    public Transform cameraTransform; // Asigna aquí la cámara de Cinemachine
    public float interactRange = 5f;

    float _turnSmoothVelocity;

    void Update()
    {
        Move();
        Interact();
    }

    void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(moveX, 0f, moveZ).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Calcula el ángulo hacia donde moverse según la cámara
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, rotationSmoothTime);

            // Rota el personaje hacia la dirección de movimiento
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Mueve el personaje en la dirección de la cámara
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            transform.position += moveDir.normalized * moveSpeed * Time.deltaTime;
        }
    }

    void Interact()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Camera cam = Camera.main;
            if (cam == null)
            {
                Debug.LogWarning("No se encontró la cámara principal (MainCamera).");
                return;
            }

            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
            {
                Torch torch = hit.collider.GetComponent<Torch>();
                if (torch != null)
                {
                    torch.Toggle();
                }
            }
        }
    }
}
