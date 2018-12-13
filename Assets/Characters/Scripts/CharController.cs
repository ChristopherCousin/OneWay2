using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class CharController : MonoBehaviour {
    [SerializeField]
    public int _MovementSpeed = 5;
    private Vector2 direction;
    private Animator _animator;
    int animationCount;
    bool inArrows;
    List<string> animationsList = new List<string>();

	void Start () {
        _animator = gameObject.GetComponent<Animator>();
        animationCount = _animator.parameterCount;
        getAnimationsParameters();
        inArrows = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!inArrows)
        {
            GetInput();
        } else
        {
            move();
        }
	}

    public void move()
    {
        transform.Translate(direction * _MovementSpeed * Time.deltaTime);
    }

    private void GetInput()
    {
        //direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction = Vector2.up;
            move();
            setAnimation("walkUp", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            setAnimation("walkUp", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction = Vector2.left;
            move();
            setAnimation("walkLeft", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            setAnimation("walkLeft", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction = Vector2.down;
            move();
            setAnimation("walkDown", true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            setAnimation("walkDown", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = Vector2.right;
            move();
            setAnimation("walkRigth", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            setAnimation("walkRigth", false);
        }
    }

    private void setAnimation(string value, bool booleana)
    {
        foreach(string animationName in animationsList)
        {
            if (value.Equals(animationName) && booleana)
            {
                _animator.SetBool(animationName, true);
            }
            if (value.Equals(animationName) && !booleana)
            {
                _animator.SetBool(animationName, false);
            }
        }
    }

    private void getAnimationsParameters()
    {
        for(int x = 0; x < animationCount; x++)
        {
            animationsList.Add(_animator.GetParameter(x).name);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "RightArrow" || collision.gameObject.tag == "LeftArrow"
            || collision.gameObject.tag == "DownArrow" || collision.gameObject.tag == "UpArrow")
        {
            foreach (string animationName in animationsList)
            {
                _animator.SetBool(animationName, false);
            }
        }

        TriggerCollisions(collision);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        NormalCollisions(collision);
    }
    void TriggerCollisions(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "RightArrow":
                moveInArrows("right");
                break;
            case "LeftArrow":
                moveInArrows("left");
                break;
            case "DownArrow":
                moveInArrows("down");
                break;
            case "UpArrow":
                moveInArrows("up");
                break;
        }
    }
    void NormalCollisions(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "wall":
                moveInArrows("wall");
                break;
        }
    }

    void moveInArrows(string value)
    {
        switch (value)
        {
            case "right":
                direction = Vector2.right;
                inArrows = true;
                break;
            case "left":
                direction = Vector2.left;
                inArrows = true;
                break;
            case "down":
                direction = Vector2.down;
                inArrows = true;
                break;
            case "up":
                direction = Vector2.up;
                inArrows = true;
                break;
            case "wall":
                inArrows = false;
                direction = Vector2.zero;
                break;
        }
    }

}
