using UnityEngine;
using System.Collections;

public class animate : MonoBehaviour {
    public Sprite[] sprites;
    public float framesPerSecond;
    private SpriteRenderer spriteRenderer;
    public GameObject camera;
    // Use this for initialization
    int gotime=0;
    void Start () { 
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow)) {
            gameObject.transform.position+= new Vector3(0.05f, 0, 0);
            camera.transform.position += new Vector3(0.05f, 0, 0);
            gotime++;
            if (gotime % (60*4/ framesPerSecond) < (60/ framesPerSecond)) spriteRenderer.sprite = sprites[9];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 *2/ framesPerSecond)) spriteRenderer.sprite = sprites[10];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 *3/ framesPerSecond)) spriteRenderer.sprite = sprites[11];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 *4/ framesPerSecond)) spriteRenderer.sprite = sprites[8];
        
            
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.position += new Vector3(-0.05f, 0, 0);
            camera.transform.position += new Vector3(-0.05f, 0, 0);
            gotime++;
            if (gotime % (60 * 4 / framesPerSecond) < (60 / framesPerSecond)) spriteRenderer.sprite = sprites[5];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 2 / framesPerSecond)) spriteRenderer.sprite = sprites[6];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 3 / framesPerSecond)) spriteRenderer.sprite = sprites[7];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 4 / framesPerSecond)) spriteRenderer.sprite = sprites[4];

            
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.position += new Vector3(0,0.05f, 0);
            camera.transform.position += new Vector3(0, 0.05f, 0);
            gotime++;
            if (gotime % (60 * 4 / framesPerSecond) < (60  / framesPerSecond)) spriteRenderer.sprite = sprites[13];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 2 / framesPerSecond)) spriteRenderer.sprite = sprites[14];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 3 / framesPerSecond)) spriteRenderer.sprite = sprites[15];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 4 / framesPerSecond)) spriteRenderer.sprite = sprites[12];

            

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.position += new Vector3(0,-0.05f, 0);
            camera.transform.position += new Vector3(0, -0.05f, 0);
            gotime++;
            if (gotime % (60 * 4 / framesPerSecond) < (60 / framesPerSecond)) spriteRenderer.sprite = sprites[1];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 2 / framesPerSecond)) spriteRenderer.sprite = sprites[2];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 3 / framesPerSecond)) spriteRenderer.sprite = sprites[3];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 4 / framesPerSecond)) spriteRenderer.sprite = sprites[0];

           
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            gotime = 0;
            spriteRenderer.sprite = sprites[8];
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            gotime = 0;
            spriteRenderer.sprite = sprites[4];
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            gotime = 0;
            spriteRenderer.sprite = sprites[12];
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            gotime = 0;
            spriteRenderer.sprite = sprites[0];
        }
    }
    
}
