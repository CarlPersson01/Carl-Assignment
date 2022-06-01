using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D _ballRB;
    [SerializeField] private float _ballSpeed = 500f;

    private void Awake()
    {
        _ballRB = this.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Invoke(nameof(BallStart), 1f);

    }

    public void BallStart()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        this._ballRB.AddForce(force.normalized * this._ballSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Brick")
            return;

        SoundManager.Instance.Play(SettingsHolder.Instance._paddle);
    }
}
