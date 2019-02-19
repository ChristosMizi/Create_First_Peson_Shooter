using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    // variable for has coin
    public bool hascoin = false;
    public bool hasMGun = false;
    public bool hasPistol = false;
    
    [SerializeField]
    private float _speed = 3.5f;
    private float _gravity = 9.81f; // this is actual gravitation force on earth

    //Variables for Jump
    private float verticalVelocity;
    private float jumpForce = 6.0f;

    //Variable for runSpeed
    private float _runSpeed = 8;
    Vector3 MoveDirection = Vector3.zero;

    public Inventory inventory;
    public GameObject _weaponMG;
    

    public GameObject _weaponPistol;



    // Use this for initialization
    void Start()
    {
        
      
        _controller = GetComponent<CharacterController>();
        

    }


    // Update is called once per frame
    void Update()

    {
        
        CalculateMovement();
        //If Shft Key pressed then Run
        if (_controller.isGrounded && Input.GetButton("Sprint"))
        {
            MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            MoveDirection = transform.TransformDirection(MoveDirection);
            MoveDirection *= _runSpeed;


        }

    }
    void CalculateMovement()
    {
       
        //Space key pressed then Jump
        if (_controller.isGrounded)
        {
            verticalVelocity = -_gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= _gravity * Time.deltaTime;
        }
        // Specify the direction where the player is moving
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalVelocity, verticalInput); // we have the direction where to move
        Vector3 velocity = direction * _speed;

        // every frame gravity applied, so we have to affect the y value of our velocity
        //make sure that we are grounded
        // velocity is a formula with the direction of the speed
        velocity.y -= _gravity;

        velocity = transform.transform.TransformDirection(velocity); // assign the worldspace values to my velocity
        _controller.Move(velocity * Time.deltaTime);// tha kineitai pio irema We apply real time 

       
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        if(item!= null)
        {
            inventory.AddItem(item);
        }
    }

    public void EnableMG() {
        _weaponMG.SetActive(true);
    }

    public void DisablePistol()
    {
        _weaponPistol.SetActive(false);
    }
   
    
}
