using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moverse : MonoBehaviour
{
    CharacterController m_controller;
    public float speed = 4;
    public float aceleracion = 1;
    public float gravedad = -9.81f;
    public float salto = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();

        float InputX = Input.GetAxis("Horizontal");
        float InputY = Input.GetAxis("Vertical");
        Vector3 Moving = new Vector3(InputX * speed * aceleracion, salto, InputY * speed * aceleracion);

        m_controller.Move(Moving * Time.deltaTime);
        Up();
        Gravity();
    }
    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (aceleracion < 3)
            {
                aceleracion++;
            }
        }
    }
    void Up()
    {
        if (m_controller.isGrounded && Input.GetKey(KeyCode.Space))
        {
            salto = 12;
        }
    }
    void Gravity()
    {
        salto += gravedad * Time.deltaTime;
    }
}
