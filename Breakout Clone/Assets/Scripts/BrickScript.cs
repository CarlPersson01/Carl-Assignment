using UnityEngine;

public class BrickScript : MonoBehaviour
{
    private int _brickHealth;
    public Sprite[] states;

    private SpriteRenderer _spriteRenderer;

    public int _pointValue = 100;
    private void Awake()
    {
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        this._brickHealth = this.states.Length;
        this._spriteRenderer.sprite = this.states[this._brickHealth - 1];
    }

    private void Hit()
    {
        this._brickHealth--;
        SoundManager.Instance.Play(SettingsHolder.Instance._score);

        if (this._brickHealth <= 0)
            this.gameObject.SetActive(false);
        else
            this._spriteRenderer.sprite = this.states[this._brickHealth - 1];

        FindObjectOfType<GameManager>().AddScore(this);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            Hit();
        }
    }

}
