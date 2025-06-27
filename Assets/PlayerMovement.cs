using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] float m_speed = 3f;
    [SerializeField] float m_sprintSpeed = 4.5f;
    [SerializeField] float m_currentSpeed;
    public Camera playerCamera;
    private float interactRange = 5f;

    Vector3 m_movement;
    Rigidbody m_playerRigidbody;

    float m_horz = 0f;
    float m_vert = 0f;

    public bool canMove = true;

    private void Update()
    {
        Interact();
    }

    void Start()
    {
        m_playerRigidbody = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
        if (!canMove) return;

        m_horz = Input.GetAxis("Horizontal");
        m_vert = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_currentSpeed = m_sprintSpeed;
        }
        else
        {
            m_currentSpeed = m_speed;
        }

        Move();
    }
    void Move()
    {
        m_movement.Set(m_horz, 0f, m_vert);
        m_movement = m_movement.normalized * m_currentSpeed * Time.deltaTime;
        m_playerRigidbody.MovePosition(transform.position + m_movement);
    }

    void Interact()
    {
        if (Input.GetMouseButtonDown(0)) // Clic izquierdo
        {
            Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // Centro de la pantalla
            Debug.DrawRay(ray.origin, ray.direction * interactRange, Color.red, 1f);
            if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
            {
                Debug.Log("Raycast hit: " + hit.collider.name); // Para verificar si algo se toca
                Torch torch = hit.collider.GetComponent<Torch>();
                if (torch != null)
                {
                    torch.Toggle();
                }
            }
            else
            {
                Debug.Log("Raycast no impactó nada.");
            }
        }
    }
}
