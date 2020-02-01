using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Transform groundCheck;

    public CanvasGroup canvasGroup;


    private bool canvActive = false;
   // [SerializeField] private Inventory inventory;

     Rigidbody2D rb;
    public float jumpSpeed = 10.0f;


    public static int health = 100;

    public static int maxHealth = 100;

    public bool currentanim;

    public float speed = 10.0f;

    public float walkAcc = 1.2f;

    Vector2 velocity;

    bool canJump = true;

     LayerMask mask;
     
     private bool grounded = false;

    public Animator anim;

    bool isFlipped = false;

    public AudioSource footsteps;

    public AudioSource jump;

    bool soundPlay = true;

     
    void Awake() {
        
    rb = GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start()
    {

       mask = LayerMask.GetMask("Environment");
       velocity = new Vector2(0.0f, 0.0f);
       StartCoroutine(SoundWait());

    //   anim.GetComponent<Animator>();

    }

    public void UpdateHealth(int newHealth)
    {
        health = newHealth;
    }


    void FixedUpdate() {


      //  Debug.Log(grounded);

        if(grounded)
        {

            velocity.y = 0.0f;

            if(Input.GetButton("Vertical"))
            {
                Debug.Log("Jump button pressed");
          //  rb.AddForce(new Vector2(0.0f, jumpForce));#
       //     velocity.y = Mathf.Sqrt(2 * jumpSpeed * Mathf.Abs(Physics2D.gravity.y));
                velocity.y = jumpSpeed;
                anim.SetBool("isJump", true);
                jump.Play();
                grounded = false;
            }
        }

        float horInput = Input.GetAxisRaw("Horizontal");
        //float verInput = transform.position.y;
        //velocity.x = Mathf.MoveTowards(velocity.x, speed * horInput, walkAcc * Time.deltaTime);

        if(horInput != 0 && grounded)
        {
          //  Debug.Log("should play");
             if(soundPlay)
             {
            footsteps.Play();
            soundPlay = false;
             }
        }


        anim.SetFloat("Speed", horInput);
        //anim.SetFloat("Height")

        velocity.x = speed * horInput;

        transform.Translate(velocity * Time.deltaTime);

        if(velocity.x < 0 && !isFlipped)
        {
             Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
            isFlipped = true;
        }
        else if(velocity.x > 0 && isFlipped)
        {
    Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
            isFlipped = false;
        }


      // Debug.Log(canJump);

        if(!grounded)
        {
       //     RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.5f, mask);
            	Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f, mask);

            for(int i = 0; i < colliders.Length; i++)
            {
                if(colliders[i].gameObject != gameObject)
                {
                    anim.SetBool("isJump", false);
                    grounded = true;
                }                   
            }

            /*
            if(hit.collider != null)
            {              
                grounded = true;
               // Debug.Log("Setting jump to true");
                canJump = true;
            }*/
        }

    }


    void Update() {

       if(Input.GetButtonDown("Inventory"))
       {
           canvActive = !canvActive; // change the state of your bool
           if(canvActive)
           {
           canvasGroup.alpha = 1.0f;
           }
           else if(!canvActive)
           {
              canvasGroup.alpha = 0.0f;
           }
        //   InvPanel.GetComponent<Renderer>.enabled = canvActive;
            //InvCanvas.gameObject.SetActive(canvActive); // d

       }
       

    }

    IEnumerator SoundWait()
    {
        while(true)
        {
           yield return new WaitForSeconds(0.4f);
           soundPlay = true;
        }

    }

}
