using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCtrl : MonoBehaviour
{
    public float speed;
    public float strafeSpeed;
    public float jumpForce;
    public float rotationSpeed;
    public float fuelAmount;
    public float sunDistance;

    public Rigidbody mainBody;
    public GameObject armLeft;
    public GameObject armLeftGrab;
    public GameObject armRightGrab;
    public GameObject armRight;
    public GameObject jetPack;
    public GameObject jetpackTrail;
    public GameObject trail;

    protected bool isGrounded = true;
    protected bool isJumping = false;
    protected bool grabLeft = false;
    protected bool grabRight = false;
    public bool pickupHeld = false;

    public GameObject pickup;
    public GameObject lastMoon;
    public GameObject fuelCharge;
    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        mainBody = GetComponent<Rigidbody>();
        armLeftGrab.SetActive(false);
        armRightGrab.SetActive(false);
        fuelAmount = 100;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Left Click");
            armLeft.SetActive(false);
            armLeftGrab.SetActive(true);
            grabLeft = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            //Debug.Log("Left Click");
            armLeft.SetActive(true);
            armLeftGrab.SetActive(false);
            grabLeft = false;
        }
        if (Input.GetMouseButtonDown(1))
        {
            //Debug.Log("Right Click");
            armRight.SetActive(false);
            armRightGrab.SetActive(true);
            grabRight = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            //Debug.Log("Right Click");
            armRight.SetActive(true);
            armRightGrab.SetActive(false);
            grabRight = false;
        }
        if (pickup != null)
        {
            if (grabLeft && grabRight)
            {
                pickup.transform.parent.transform.parent = mainBody.transform;
                pickupHeld = true;
            }
            else
            {
                pickup.transform.parent.transform.parent = lastMoon.transform;
                pickupHeld = false;
                // pickup.transform.parent.GetComponent<GravityCtrl>().gravityOn = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("jumping");
            trail = Instantiate(jetpackTrail, jetPack.transform.position, jetPack.transform.rotation);
            trail.transform.parent = jetPack.transform;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //Debug.Log("not jumping");
            Destroy(trail);
        }
        if (fuelAmount <= 0)
        {
            fuelAmount = 0;
        }

        sunDistance = Vector3.Distance(transform.position, GameObject.Find("Sun").transform.position) - 752;

    }
    private void FixedUpdate()
    {
        float moonSpeed = GameObject.Find("MoonSpawner").GetComponent<RandomSpawn>().moonSpeed;
        transform.position += new Vector3(1, 0, 0) * moonSpeed * Time.deltaTime;
        //Debug.Log(isGrounded);
        if (Input.GetKey(KeyCode.W))
        {
            //Debug.Log("W");
            mainBody.AddForce(mainBody.transform.forward * (speed * mainBody.mass));
        }
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("A");
            mainBody.AddForce(-mainBody.transform.right * strafeSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("S");
            mainBody.AddForce(-mainBody.transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("D");
            mainBody.AddForce(mainBody.transform.right * strafeSpeed);
        }

        if (Input.GetKey(KeyCode.Space) && fuelAmount > 0)
        {
            fuelAmount -= 0.1f;
            //Debug.Log("Jump");
            if (isGrounded)
            {
                mainBody.AddForce(mainBody.transform.up * jumpForce);
                isGrounded = false;
                isJumping = true;
            }
        }

        mainBody.transform.Rotate((Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime), (Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime), 0);

        if (!isJumping)
        {
            mainBody.velocity = Vector3.ClampMagnitude(mainBody.velocity, 10f);
        }

        // if (isJumping)
        // {
        //     fuelAmount -= 0.1f;
        // }
    }
    private void OnCollisionEnter(Collision ground)
    {
        // Debug.Log("grounded");
        isGrounded = true;
        isJumping = false;
    }

    private void OnCollisionExit(Collision ground)
    {
        // Debug.Log("not grounded");
        isGrounded = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("trigger");
        if (collider.gameObject.tag == "Pickup" && !pickupHeld)
        {
            //Debug.Log("pickup");
            pickup = collider.gameObject;
            pickup.transform.parent.GetComponent<PickupControler>().pickUpHeld();
        }
        else if (collider.gameObject.tag == "Moon")
        {
            lastMoon = collider.gameObject;
        }
        else if (collider.gameObject.tag == "Sun")
        {
            Debug.Log("Dead RIP");
            SceneManager.LoadScene("GameOver");
        }
        else if (collider.gameObject.tag == "Fuel")
        {
            Debug.Log("Fuel");
            fuelCharge = collider.gameObject;
            fuelAmount += 25;
            Destroy(fuelCharge);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Pickup" && !pickupHeld)
        {
            //Debug.Log("not pickup");
            pickup.transform.parent.GetComponent<PickupControler>().pickUpDropped();
            pickup = null;
        }
    }
}
