using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsScript : MonoBehaviour
{
    public int _damageToGive = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BallScript ball = collision.gameObject.GetComponent<BallScript>();
        ball.transform.position = Vector2.zero;
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ball.Invoke(nameof(ball.BallStart), 1f);

        FindObjectOfType<GameManager>().LooseLife(this);
    }
}
