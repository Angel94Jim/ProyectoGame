using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private CharacterController controller; //Creamos referencia a CharacterController
    private Vector3 direction; //Variable para mover al player.
    public float forwardSpeed;

    void Start()
    {   //Referencia al componente
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;
        //Mov a player eje z
    }

    private void FixedUpdate() 
    {   //Loop para actualizar la pos actual del player.
        controller.Move(direction * Time.fixedDeltaTime);
    }
}
