using UnityEngine;
public class PlayerController : MonoBehaviour{
    [HideInInspector] public static uint score = 0;

    public Rigidbody2D rb;
    public float speed = 10f;
    private float moveX;

    public static Vector2 playerStartPosition;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        playerStartPosition = transform.position;

    }
    void Update(){
       // moveX = Input.GetAxis("Horizontal") * speed;
         moveX= Input.acceleration.x * speed;


        if (transform.position.x < -2.312371f) {
            transform.position = new Vector2(-2.312371f,transform.position.y);
        }
        if (transform.position.x > 2.312371f)
        {
            transform.position = new Vector2(2.312371f, transform.position.y);
        }
    }

    public void ResetPlayerPosition() {
        transform.position = playerStartPosition;
    }
   

    private void FixedUpdate() {
        Vector2 velocity = rb.velocity;
        velocity.x = moveX;
        rb.velocity = velocity;   
        


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Hole(Clone)"|| collision.gameObject.name == "Hole 1(Clone)") {
            PlayMenuUIController.msg = "Game Over";
            Debug.Log("Game is over....");
        }
    }
}
