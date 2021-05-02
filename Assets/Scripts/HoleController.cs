using UnityEngine;

public class HoleController : MonoBehaviour
{
    void Update()
    {
        if (PlayMenuUIController.msg == "Game Over") Destroy(gameObject);
    }
}
