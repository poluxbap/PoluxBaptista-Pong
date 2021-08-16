using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 speed = new Vector3(3, 5, 0);
    private Vector3 _startSpeed;
    [Header("Random range")]
    public Vector2 randomRange = new Vector2(5, 8);

    private Vector3 _staticPosition;
    public bool _canMove = false;

    private void Awake()
    {
        _staticPosition = transform.position;
        _startSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (_canMove)
        {
            transform.Translate(speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            RandomizeSpeed();
        }
        else
        {
            speed.y *= -1;
        }
    }

    private void RandomizeSpeed()
    {
        speed.x *= -1;

        var result = Random.Range(randomRange.x, randomRange.y);

        if (speed.x < 0)
        {
            result = -result;
        }
        speed.x = result;

        int y_signal = ((int)Mathf.Abs(speed.y) / (int)speed.y);

        speed.y = Mathf.Abs(result) * y_signal;
    }

    public void ResetPosition()
    {
        transform.position = _staticPosition;
        speed = _startSpeed;
    }

    public void CanMove(bool state)
    {
        _canMove = state;
    }
}
