using UnityEngine;

public class MobMove : MonoBehaviour
{
    public float speed = 1.3f;
    public float leftLimit = -2.7f;
    public float rightLimit = -0.2f;
    public bool canMove = true;
    private bool movingLeft = true;

    void Update()
    {
        if (canMove)
        {
            if (movingLeft)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);

                if (transform.position.x <= leftLimit)
                {
                    movingLeft = false;
                    Flip();
                }
            }
            else
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);

                if (transform.position.x >= rightLimit)
                {
                    movingLeft = true;
                    Flip();
                }
            }
        }
    }
    void Flip()
    {
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
