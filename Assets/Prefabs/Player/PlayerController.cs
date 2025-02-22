using System;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterContoller;

    [SerializeField] private float speed = 3f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float Jamp = 2f;
    private float velocity;
 
    private void Start()
    {
        _characterContoller = GetComponent<CharacterController>();
        
    }

void Update() {
    
Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
if(_characterContoller.isGrounded)if(Input.GetKeyDown(KeyCode.Space))Jmp();


}
 void FixedUpdate() {
        
    
    
        MoveLogic();
    }
   

    

    private void MoveLogic()
    {
        if(_characterContoller.isGrounded && velocity < 0)velocity = -2;

        
        _characterContoller.Move(_movement * speed * Time.fixedDeltaTime);

        velocity += gravity * Time.fixedDeltaTime;
        _characterContoller.Move(Vector3.up * velocity * Time.fixedDeltaTime);


        
    }
    void Jmp(){
        velocity = MathF.Sqrt(Jamp * -2 * gravity);
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
