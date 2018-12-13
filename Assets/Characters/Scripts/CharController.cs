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
            move();
        } else
        {
            //Aqui poner animacion cuando entra en arrows
        }
	}

    public void move()
    {
        transform.Translate(direction * _MovementSpeed * Time.deltaTime);
    }

    private void GetInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction = Vector2.up;
            setAnimation("walkUp", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            setAnimation("walkUp", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction = Vector2.left;
            setAnimation("walkLeft", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            setAnimation("walkLeft", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction = Vector2.down;
            setAnimation("walkDown", true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            setAnimation("walkDown", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = Vector2.right;
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RightArrow") moveInArrows("right");
        if (collision.gameObject.tag == "LeftArrow") moveInArrows("left");
        if (collision.gameObject.tag == "DownArrow") moveInArrows("down");
        if (collision.gameObject.tag == "UpArrow") moveInArrows("up");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RightArrow")
        {
            inArrows = false;
            transform.Translate(Vector2.right * _MovementSpeed * Time.deltaTime);
        }
        else if (collision.gameObject.tag == "LeftArrow")
        {
            inArrows = false;
            transform.Translate(Vector2.left * _MovementSpeed * Time.deltaTime);
        }
        else if (collision.gameObject.tag == "DownArrow")
        {
            inArrows = false;
            transform.Translate(Vector2.down * _MovementSpeed * Time.deltaTime);
        }
        else if (collision.gameObject.tag == "UpArrow")
        {
            inArrows = false;
            transform.Translate(Vector2.up * _MovementSpeed * Time.deltaTime);
        }
    }

    void moveInArrows(string value)
    {
        inArrows = true;

        if (value.Equals("right"))
        {
            transform.Translate(Vector2.right * _MovementSpeed * Time.deltaTime);
        }
        if (value.Equals("left"))
        {
            transform.Translate(Vector2.left * _MovementSpeed * Time.deltaTime);
        }
        if (value.Equals("up"))
        {
            transform.Translate(Vector2.up * _MovementSpeed * Time.deltaTime);
        }
        if (value.Equals("down"))
        {
            transform.Translate(Vector2.down * _MovementSpeed * Time.deltaTime);
        }
    }
}
