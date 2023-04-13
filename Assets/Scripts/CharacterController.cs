using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 10f;
    public GameObject bulletPrefab;
    public Transform muzzleTransform;
    public float bulletSpeed = 50f;

    private Animator animator;
    private Rigidbody rigidbody;
    private bool isShooting;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from the player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool shoot = Input.GetKeyDown(KeyCode.Space);

        // Update the character's state based on input
        if (shoot && !isShooting)
        {
            isShooting = true;
            Shoot();
            //StartCoroutine(stopAnimation());
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
        // Move the character
        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        direction = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f) * direction;
        //direction.Normalize();
        rigidbody.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);

        // Rotate the character
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

        // Set the animator parameters
        animator.SetFloat("Speed", direction.magnitude);
    }

    void Idle()
    {
        // Set the animator parameters
        animator.SetFloat("Speed", 0f);
    }

    void Shoot()
    {
        // Spawn the bullet
        GameObject bullet = Instantiate(bulletPrefab, muzzleTransform.position, muzzleTransform.rotation);

        // Add velocity to the bullet
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = muzzleTransform.forward * bulletSpeed;

        // Play the shooting animation
        animator.SetTrigger("isShoot");

    }
    //IEnumerator stopAnimation()
    //{
    //    yield return new WaitForSeconds(.3f);
    //    animator.SetBool("isShoot", false);
    //    Idle();
    //}
}
