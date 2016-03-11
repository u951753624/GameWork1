using UnityEngine;
using System.Collections;

public class npcmove : MonoBehaviour {
    public Sprite[] sprites;
    int gotime = 0;
    float framesPerSecond = 5;
    private SpriteRenderer spriteRenderer;
    int dir = 2;
    int medir = 2;
    // Use this for initialization
    int state = 0;
    public GameObject me;


    float rdgo=0;
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "me")
        {
            if(Mathf.Abs(collision.transform.position.x-gameObject.transform.position.x)>10)
            state = 0;
            
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "me")
        {
            state = 1;
            print("進入");
        }
    }
    // Update is called once per frame
    void FixedUpdate() {

        if (state == 0) {
            //亂走狀態
            
            if (rdgo < 0) {
                gotime = 0;
                rdgo = Random.value;
                float d = Random.value;
                if (d < 0.25)
                    dir = 2;
                else if (d < 0.5)
                    dir = 6;
                else if (d < 0.75)
                    dir = 8;
                else if (d < 1)
                    dir = 4;
            }
        }
        else if (state == 1)
        {
            //追蹤狀態
            
            if (rdgo < 0)
            {
                if (Mathf.Abs(me.transform.position.x - gameObject.transform.position.x) > Mathf.Abs(me.transform.position.y - gameObject.transform.position.y))
                {
                    if (me.transform.position.x - gameObject.transform.position.x > 0)
                    {
                        if (me.transform.position.y - gameObject.transform.position.y > 0)
                        {

                            gotime = 0;
                            rdgo = Random.value;
                            float d2 = Random.value;
                            if (d2 < 0.3)
                                dir = 8;
                            else if (d2 < 0.8)
                                dir = 6;
                            else if (d2 < 0.9)
                                dir = 2;
                            else if (d2 <= 1)
                                dir = 4;
                            
                        }
                        else
                        {
                            gotime = 0;
                            rdgo = Random.value;
                            float d2 = Random.value;
                            if (d2 < 0.3)
                                dir = 2;
                            else if (d2 < 0.8)
                                dir = 6;
                            else if (d2 < 0.9)
                                dir = 8;
                            else if (d2 <= 1)
                                dir = 4;
                            
                        }
                    }
                    else
                    {
                        if (me.transform.position.y - gameObject.transform.position.y > 0)
                        {
                            gotime = 0;
                            rdgo = Random.value;
                            float d2 = Random.value;
                            if (d2 < 0.3)
                                dir = 8;
                            else if (d2 < 0.8)
                                dir = 4;
                            else if (d2 < 0.9)
                                dir = 2;
                            else if (d2 <= 1)
                                dir = 6; 
                        }
                        else
                        {
                            gotime = 0;
                            rdgo = Random.value;
                            float d2 = Random.value;
                            if (d2 < 0.3)
                                dir = 2;
                            else if (d2 < 0.8)
                                dir = 4;
                            else if (d2 < 0.9)
                                dir = 8;
                            else if (d2 <= 1)
                                dir = 6;
                            
                        }
                    }
                }
                else {
                    if (me.transform.position.x - gameObject.transform.position.x > 0)
                    {
                        if (me.transform.position.y - gameObject.transform.position.y > 0)
                        {
                            gotime = 0;
                            rdgo = Random.value;
                            float d2 = Random.value;
                            if (d2 < 0.3)
                                dir = 6;
                            else if (d2 < 0.8)
                                dir = 8;
                            else if (d2 < 0.9)
                                dir = 2;
                            else if (d2 <= 1)
                                dir = 4; 
                        }
                        else
                        {
                            gotime = 0;
                            rdgo = Random.value;
                            float d2 = Random.value;
                            if (d2 < 0.3)
                                dir = 6;
                            else if (d2 < 0.8)
                                dir = 2;
                            else if (d2 < 0.9)
                                dir = 8;
                            else if (d2 <= 1)
                                dir = 4;
                           
                        }
                    }
                    else
                    {
                        if (me.transform.position.y - gameObject.transform.position.y > 0)
                        {
                            gotime = 0;
                            rdgo = Random.value;
                            float d2 = Random.value;
                            if (d2 < 0.3)
                                dir = 4;
                            else if (d2 < 0.8)
                                dir = 8;
                            else if (d2 < 0.9)
                                dir = 2;
                            else if (d2 <= 1)
                                dir = 6; 
                        }
                        else
                        {
                            gotime = 0;
                            rdgo = Random.value;
                            float d2 = Random.value;
                            if (d2 < 0.3)
                                dir = 4;
                            else if (d2 < 0.8)
                                dir = 2;
                            else if (d2 < 0.9)
                                dir = 8;
                            else if (d2 <= 1)
                                dir = 6;

                        }
                    }
                }
            }
        }




        rdgo = rdgo - 0.02f;
        if (dir==6)
        {
            gameObject.transform.position += new Vector3(0.05f, 0, 0);
            gotime++;
            if (gotime % (60 * 4 / framesPerSecond) < (60 / framesPerSecond)) spriteRenderer.sprite = sprites[9];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 2 / framesPerSecond)) spriteRenderer.sprite = sprites[10];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 3 / framesPerSecond)) spriteRenderer.sprite = sprites[11];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 4 / framesPerSecond)) spriteRenderer.sprite = sprites[8];


        }

        else if (dir == 4)
        {
            gameObject.transform.position += new Vector3(-0.05f, 0, 0);
            gotime++;
            if (gotime % (60 * 4 / framesPerSecond) < (60 / framesPerSecond)) spriteRenderer.sprite = sprites[5];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 2 / framesPerSecond)) spriteRenderer.sprite = sprites[6];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 3 / framesPerSecond)) spriteRenderer.sprite = sprites[7];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 4 / framesPerSecond)) spriteRenderer.sprite = sprites[4];


        }
        else if (dir == 8)
        {
            gameObject.transform.position += new Vector3(0, 0.05f, 0);
            gotime++;
            if (gotime % (60 * 4 / framesPerSecond) < (60 / framesPerSecond)) spriteRenderer.sprite = sprites[13];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 2 / framesPerSecond)) spriteRenderer.sprite = sprites[14];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 3 / framesPerSecond)) spriteRenderer.sprite = sprites[15];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 4 / framesPerSecond)) spriteRenderer.sprite = sprites[12];



        }
        else if (dir == 2)
        {
            gameObject.transform.position += new Vector3(0, -0.05f, 0);
            gotime++;
            if (gotime % (60 * 4 / framesPerSecond) < (60 / framesPerSecond)) spriteRenderer.sprite = sprites[1];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 2 / framesPerSecond)) spriteRenderer.sprite = sprites[2];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 3 / framesPerSecond)) spriteRenderer.sprite = sprites[3];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 4 / framesPerSecond)) spriteRenderer.sprite = sprites[0];


        }

    }
}
