using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private CharacterController controller; //Creamos referencia a CharacterController.
    private Vector3 direction; //Variable para mover al player.
    public float forwardSpeed; //Variable para inicializar la velocidad de player.
    private int desiredLane = 1; //0:izq, 1:centro, 2:der.
    public float laneDistance=4; //Distancia entre las lineas.

    void Start()
    {   //Referencia al componente
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() //ejecuta codigo por cuadro
    {
        //Mov a player eje z con la velocidad inicializada
        direction.z = forwardSpeed;
        
        //Necesitamos obtener el valor donde el player debe de estar.
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) 
        {   // Si se presiono la tecla "D".
            desiredLane++;        //Incrementamos en 1 la linea deseada.
            if(desiredLane == 3)  //Si nos salimos del intervalo("mapa").
            desiredLane = 2;      //Nos regresamos a una pos anterior.
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        { // Si se presiono la tecla "A".
            desiredLane--;          //Decrementamos en 1 la linea deseada.
            if(desiredLane == -1)  //Si nos salimos del intervalo("mapa").
            desiredLane = 0;       //Nos regresamos a una pos anterior.
        }

        //Calcular la nueva pos del player.
         Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        
        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance; 
        }else if(desiredLane == 2)
        {
           targetPosition += Vector3.right * laneDistance;  
        }

        transform.position = targetPosition;
    }

    private void FixedUpdate() //puede ejecutar 0,1, multiples veces por cuadro
    {   //Loop para actualizar la pos actual del player.
        controller.Move(direction * Time.fixedDeltaTime);
    }
}
