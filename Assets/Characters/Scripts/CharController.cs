using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {
    [SerializeField]
    public int _MovementSpeed = 5;
    private Vector2 direction;
    private Animator _animator;

	void Start () {
        _animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        GetInput();
        move();
	}

    public void move()
    {
        transform.Translate(direction * _MovementSpeed * Time.deltaTime);
    }

    private void GetInput()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) direction = Vector2.up;
        if (Input.GetKey(KeyCode.A))
        {
            direction = Vector2.left;
            _animator.SetBool("walkLeft", true);
        } else
        {
            _animator.SetBool("walkLeft", false);
        }
        if (Input.GetKey(KeyCode.S)) direction = Vector2.down;
        if (Input.GetKey(KeyCode.D)) direction = Vector2.right;
    }

}
