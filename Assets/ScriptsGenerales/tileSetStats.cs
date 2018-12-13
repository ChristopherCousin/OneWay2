using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileSetStats : MonoBehaviour {


    public Component[] walls;
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
        walls = GetComponentsInChildren<Component>();
        
        foreach(Component wall in walls)
        {
            string n = wall.GetComponent<SpriteRenderer>().sprite.ToString();
            Debug.Log(n);
            
            if(wall.GetComponent<SpriteRenderer>().sprite.Equals("asd_52") || wall.GetComponent<SpriteRenderer>().sprite.Equals("asd_52")
                || wall.GetComponent<SpriteRenderer>().sprite.Equals("asd_52"))
            {
                Debug.Log(wall.GetComponent<SpriteRenderer>().sprite);
            }
        }
    }
}
