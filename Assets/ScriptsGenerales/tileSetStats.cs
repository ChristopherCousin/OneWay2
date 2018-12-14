using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileSetStats : MonoBehaviour {


    public SpriteRenderer[] walls;
    public string[] spriteNames;
    List<GameObject> arrows;

    void Start () {
        setWalls();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void setWalls()
    {
        walls = GetComponentsInChildren<SpriteRenderer>();
        
        foreach(SpriteRenderer wall in walls)
        {
            //string n = renderer.tileMode.ToString();
            //Debug.Log(wall.gameObject.GetComponent<SpriteRenderer>().);
            //string n = wall.sprite;
            Debug.Log(wall.sprite.ToString());
            if(wall.gameObject.GetComponent<SpriteRenderer>().GetInstanceID() == 6418 || wall.gameObject.GetComponent<SpriteRenderer>().GetInstanceID() == 3338
                || wall.gameObject.GetComponent<SpriteRenderer>().GetInstanceID() == 3340)
            {
                Debug.Log("adasd");
            }
        }
    }
}
