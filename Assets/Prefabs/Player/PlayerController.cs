using System;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterContoller;
    private Rigidbody rb;

    [SerializeField] private float speed = 3f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float Jamp = 2f;
    private float velocity;
 
    private void Start()
    {
        _characterContoller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        
    }

void Update() {
    
Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

//f(_characterContoller.isGrounded)if(Input.GetKeyDown(KeyCode.Space))Jmp();


}
 void FixedUpdate() {
        
    
    
        rb.MovePosition(transform.position +_movement * speed * Time.fixedDeltaTime);
    }
   

    

    
   

    private Vector3 _movement
    {
        get
        {
            float hor = Input.GetAxis("Horizontal") ;
            float ver = Input.GetAxis("Vertical") ;

            Vector3 move = transform.right * hor + transform.forward * ver;
            return move;
        }
    }
 
}
