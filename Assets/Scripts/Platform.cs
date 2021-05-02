using UnityEngine;
public class Platform : MonoBehaviour {
    public float jumpForce = 10f;
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.relativeVelocity.y <= 0f){
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb.name== "Popcorn"){
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
               
               if (gameObject.name == "Platform 2(Clone)")// destroy when player jumps to the platform
                   Destroy(gameObject, 2f);
                if (gameObject.name == "Platform 3(Clone)")// destroy when player jumps to the platform
                    Destroy(gameObject, 1f);
              
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.name == "Destroy"){
            Destroy(gameObject);
        } 
    }

    public void ResetPlatforms() {
        Destroy(gameObject);
    }
    private void Update() {
        if (PlayMenuUIController.msg == "Game Over") Destroy(gameObject);
    }
}