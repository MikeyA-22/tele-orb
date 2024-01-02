using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float vInput;
    public float hInput;
    //public GameObject bullet;
    public float bulletSpeed = 100f;
    //public Transform orientation;
    public float moveSpeed = 5.0f;
    public float gravity = -9.81f;
    public float jumpVelocity = 5f;
    public Transform tform;
    public float rotateSpeed;
    Vector3 moveDirection;
    public float jumpForce;
    public TextMeshProUGUI orbUI;
    [SerializeField]private float boundary = -15;
    public float cooldownTime = 5;
    private float nextFireTime = 0;
    private float waitTime = 4;
    private float nextTime = 0;


    public Animator animate;

    public GameObject knifeFab;
    [SerializeField] private int daggers;

    

    private CharacterController controller;
    public GameObject releasePoint;

    
    public float floatDuration = 5.0f;


    [SerializeField]Vector3 velocity;

    
    public bool isGrounded = true;

    
    public LayerMask ground;
    private AudioSource source;
    public float airPad = 12f;

    
    
    GameObject proj;

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
   
                
        tform = GetComponent<Transform>();
        source = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();

        animate.SetBool("isJumping", false);
        animate.SetBool("isRunning", false);
        animate.SetBool("isGrounded", true);
        animate.SetBool("isFalling", false);
        orbUI.text = "Orb: 1";
    }

    private void Update()
    {

        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        Vector3 moveInput = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) * new Vector3(hInput, 0, vInput);
        moveDirection = moveInput.normalized;
        //release point control
        

        if (moveDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotateSpeed * Time.deltaTime);



        }


        controller.Move(moveDirection * moveSpeed * Time.deltaTime);


        MyInput();
        
        if (hInput != 0 || vInput != 0)
        {
            isGrounded = true;
            animate.SetBool("isRunning", true);
            
        }
        else
            animate.SetBool("isRunning", false);


        if (controller.isGrounded)
        {
            velocity.y = 0;
            animate.SetBool("isGrounded", true);
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
            animate.SetBool("isFalling", false);
            animate.SetBool("isJumping", false);


            if(velocity.y < -5)
            {
                animate.SetBool("isJumping", false);
                animate.SetBool("isFalling", true);
            }

        }










        //jump
        if (controller.isGrounded && Input.GetKey(KeyCode.Space))
        {
            
            velocity.y = Mathf.Sqrt(jumpForce * -2.0f * gravity);
            animate.SetBool("isJumping", true);
            animate.SetBool("isRunning", false);
            
        }


        if (daggers > 0)
        {
            orbUI.text = "Orb: 1";
        }
        else
        {
            orbUI.text = "Orb: 0";
        }
        if(Time.time < nextFireTime)
        {
            orbUI.color = Color.yellow;
        }
        else
        {
            orbUI.color = Color.white;
        }


        if (transform.position.y < boundary)
        {
            controller.enabled = false;
            controller.transform.position = new Vector3(4f, 6f, 8.64f);
            controller.enabled = true;
        }

        if (transform.position.z > 278)
        {
            orbUI.text = "CONGRATS YOU WIN!!!.....u can go now.";
            nextTime = Time.time + waitTime;
            if(Time.time > nextTime)
            {
                SceneManager.LoadScene("Menu");
            }
            
        }

    }

        

    private void MyInput()
    {
       

        if(Input.GetKey(KeyCode.Q) && daggers > 0 && Time.time > nextFireTime)
        {
            
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.E) && daggers == 0)
        {
            StartCoroutine(Teleport());
            Destroy(proj);
            daggers += 1;
            nextFireTime = Time.time + cooldownTime;
        }
    }

   

    private void Shoot()
    {


        
        proj = Instantiate(knifeFab, releasePoint.transform.position, transform.rotation);
       
        Rigidbody knifeBody = proj.GetComponent<Rigidbody>();

        knifeBody.AddForce(cam.transform.forward * bulletSpeed * 1f, ForceMode.Impulse);



        daggers -= 1;

        if (transform.position.z - proj.transform.position.z <= -30 || transform.position.y - proj.transform.position.y <= -30 || transform.position.x - proj.transform.position.x <= -30)
        {
            daggers += 1;
            Destroy(proj);
        }


    }

    private IEnumerator Teleport()
    {

        
        
            controller.enabled= false;
            controller.transform.position = proj.transform.position;
            controller.enabled = true;
            source.Play();
            velocity.y = Mathf.Sqrt(airPad * -2.0f * gravity);

            transform.parent = null;

            yield return new WaitForSeconds(floatDuration);
        


       

    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if(collision.gameObject.tag == "knife")
        {
            daggers += 1;
            Destroy(collision.gameObject);
        }

        
    }

}
