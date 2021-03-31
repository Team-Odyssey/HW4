using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class mover2 : MonoBehaviour
{
    public CharacterController controller;
    public Player Owner;

    private GameManager gameManager;
    public Transform cam;
    public GameObject projectile;
    public int bulletCounter = 5;
    public float bulletSpeed = 100f;
    [SerializeField] public float speed = 6f;

    [SerializeField] public float turnSmoothTime = 0.1f;
    Vector3 moveMsg;


    float turnSmoothVelocity;

    void Start()
    {
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        Owner.UserID = gameManager.Players[0].UserID;
	}
    void Update()
    {
        if(gameManager.isSingle){
            moveMsg = Move(Input.GetAxisRaw("Horizontal2"), Input.GetAxisRaw("Vertical2"));
            Shoot();
        } 
        else if(Input.GetAxisRaw("Horizontal2") != 0 || Input.GetAxisRaw("Vertical2") != 0){
            moveMsg = Move(Input.GetAxisRaw("Horizontal2"), Input.GetAxisRaw("Vertical2"));
            gameManager.ProcessMove(gameManager.Players[1].UserID, Input.GetAxisRaw("Horizontal2"), Input.GetAxisRaw("Vertical2"), Time.time);
        }
        
        
    }
    
    public Vector3 Move(float horizontal, float vertical){
        Vector3 direction = new Vector3(-horizontal, 0f, -vertical).normalized;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 6;
        }

        //Shoot Bullet

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        Vector3 pos = -moveDir.normalized * speed * Time.deltaTime;
        controller.Move(pos);
        return pos;
        
    }

    void Shoot(){
        if (Input.GetMouseButtonDown(0))
        {
            GameObject instBullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            Rigidbody instbulletRigidbody = instBullet.GetComponent<Rigidbody>();
            instbulletRigidbody.AddForce(Vector3.forward * bulletSpeed);
        }
    }
    
}