using UnityEngine;

public class EnemyController : MonoBehaviour { 
 public float jumpForce = 10f;
private void OnCollisionEnter2D(Collision2D collision) { 

    if (collision.relativeVelocity.y <= 0f)
    {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rb.name == "Popcorn"){
            Vector2 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;

                Destroy(gameObject);// destroy the enemy
                Debug.Log("enemy dead...");

            } 
    } 
    if(collision.relativeVelocity.y>0)
    if(collision.gameObject.name== "Popcorn") {
                PlayMenuUIController.msg = "Game Over";
                Debug.Log("Game is over..."); 
            
            }
}

            
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
