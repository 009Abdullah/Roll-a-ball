using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 10f;
    public GameObject bulletPrefab;
    public Transform muzzleTransform;
    public float bulletSpeed = 500f;

    private Animator animator;
    private Rigidbody rigidbody;
    private bool isShooting;

    public Joystick joystick;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from the player
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        bool shoot = Input.GetKeyDown(KeyCode.Space);

        // Update the character's state based on input
        if (shoot && !isShooting)
        {
            isShooting = true;
            Shoot();
            
        }
        else if (horizontal != 0f || vertical != 0f)
        {
            isShooting = false;
            Move(horizontal, vertical);
        }
        else
        {
            isShooting = false;
            Idle();
        }
    }

    void Move(float horizontal, float vertical)
    {
        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        direction = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f) * direction;

        rigidbody.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

        animator.SetFloat("Speed", direction.magnitude);
    }

    void Idle()
    {

        animator.SetFloat("Speed", 0f);
    }

    void Shoot()
    {
        soundManager.instance.PlayHitSound();
        GameObject bullet = Instantiate(bulletPrefab, muzzleTransform.position, muzzleTransform.rotation);

        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = muzzleTransform.forward * bulletSpeed;

        

        animator.SetTrigger("isShoot");

        Destroy(bullet, 1f);

    }

}
