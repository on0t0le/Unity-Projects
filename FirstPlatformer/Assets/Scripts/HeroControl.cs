using UnityEngine;
using System.Collections;

public class HeroControl : MonoBehaviour {

    private Rigidbody2D heroBody;

    [SerializeField]
    private Transform ground;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    int score;


    private bool onGround = false;
    //private bool colider = false;
    private float groundRadius = 0.2f;
    private float forceValue = 500;
    private float speed = 5;
    private float spawnX, spawnY;



	// Use this for initialization
	void Start () {

        heroBody = GetComponent<Rigidbody2D>();
        score = 0;
        spawnX = transform.position.x;
        spawnY = transform.position.y;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        //cheking controls
        onGround = Grounded();
        float horizontal = Input.GetAxis("Horizontal");
        //for moving         
        HandleMovement(horizontal, onGround);        

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Application.LoadLevel("Main");
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    private void HandleMovement(float _horizontal, bool _onGround)
    {
        heroBody.velocity = new Vector2(_horizontal*speed, heroBody.velocity.y);

        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            heroBody.AddForce(new Vector2(0, forceValue));
        }

    }

    private void ResetAll()
    {
    }

    private bool Grounded()
    {
        //check for ground
        Collider2D[] coliders = Physics2D.OverlapCircleAll(ground.position, groundRadius, whatIsGround);
        for(int i=0; i<coliders.Length; i++)
        {
            //if collider is not hero
            if (coliders[i].gameObject != gameObject)
                return true;
        }

        return false;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
       if(col.gameObject.name == "star")
        {
            Destroy(col.gameObject);
            score++;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "saw" || coll.gameObject.name == "deadZone")
        {
            //Debug.Log("It`s not over");
            //Destroy(gameObject);
            transform.position = new Vector3(spawnX, spawnY, transform.position.z);

        }
        if (coll.gameObject.name == "endLevel")
        {
            Application.LoadLevel("Main");
        }
    }

}
