using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

// Takes and handles input and movement for a player character
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public GameManager manager;


    // public GameDialog manager;

    Vector2 movementInput;
    Vector3 dirVec;
    GameObject scanObject;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // movementInput.x = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        // movementInput.y = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        // bool xDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        // bool yDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        // bool xUp = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        // bool yUp = manager.isAction ? false : Input.GetButtonDown("Vertical");

        if (movementInput.y == 1)
            dirVec = Vector3.up;
        else if (movementInput.y == -1)
            dirVec = Vector3.down;
        else if (movementInput.x == 1)
            dirVec = Vector3.right;
        else if (movementInput.x == -1)
            dirVec = Vector3.left;


        //scan object
        if (Input.GetButtonDown("Jump") && scanObject != null){
            manager.Action(scanObject);
        }
            
    }

    private void FixedUpdate() {
        if(canMove) {
            // If movement input is not 0, try to move
            if(movementInput != Vector2.zero){
                
                bool success = TryMove(movementInput);

                if(!success) {
                    success = TryMove(new Vector2(movementInput.x, 0));
                }

                if(!success) {
                    success = TryMove(new Vector2(0, movementInput.y));
                }
                
                animator.SetBool("isMoving", success);
            } else {
                animator.SetBool("isMoving", false);
            }

            // Set direction of sprite to movement direction
            if(movementInput.x < 0) {
                spriteRenderer.flipX = true;
            } else if (movementInput.x > 0) {
                spriteRenderer.flipX = false;
            }
        }
        
        //Ray
        Debug.DrawRay(rb.position, dirVec * 0.3f, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rb.position, dirVec, 0.3f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null){
            scanObject = rayHit.collider.gameObject;}
        else{
            scanObject = null;}
    }

    private bool TryMove(Vector2 direction) {
        if(direction != Vector2.zero) {
            // Check for potential collisions
            int count = rb.Cast(
                direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collisions
                movementFilter, // The settings that determine where a collision can occur on such as layers to collide with
                castCollisions, // List of collisions to store the found collisions into after the Cast is finished
                moveSpeed * Time.fixedDeltaTime + collisionOffset); // The amount to cast equal to the movement plus an offset

            if(count == 0){
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            } else {
                return false;
            }
        } else {
            // Can't move if there's no direction to move in
            return false;
        }
        
    }

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }
}
