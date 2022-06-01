using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    private Rigidbody2D _playerRB;

    [SerializeField] private float _playerSpeed = 30f;
    [SerializeField] private float _maxBounceAngle = 75f;

    public Vector2 direction { get; private set; }

    private void Awake()
    {
        _playerRB = this.GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            this.direction = Vector2.left;
        else if (Input.GetKey(KeyCode.RightArrow))
            this.direction = Vector2.right;
        else this.direction = Vector2.zero;
    }

    private void FixedUpdate()
    {
        if(this.direction != Vector2.zero)
        {
            this._playerRB.AddForce(this.direction * this._playerSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallScript ball = collision.gameObject.GetComponent<BallScript>();

        if(ball != null)
        {
            Vector3 paddlePosition = this.transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float _offset = paddlePosition.x - contactPoint.x;
            float _width = collision.otherCollider.bounds.size.x / 2;

            float _currentAngle = Vector2.SignedAngle(Vector2.up, ball.GetComponent<Rigidbody2D>().velocity);
            float _bounceAngle = (_offset / _width) * this._maxBounceAngle;
            float _newAngle = Mathf.Clamp(_currentAngle + _bounceAngle, -this._maxBounceAngle, this._maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(_newAngle, Vector3.forward);

            ball.GetComponent<Rigidbody2D>().velocity = rotation * Vector2.up * ball.GetComponent<Rigidbody2D>().velocity.magnitude;
        }
    }
}
