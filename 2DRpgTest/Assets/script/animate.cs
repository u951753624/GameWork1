using UnityEngine;
using System.Collections;
using System.IO;


public class animate : MonoBehaviour
{
    public Sprite[] sprites;
    public float framesPerSecond;
    private SpriteRenderer spriteRenderer;
    public GameObject camera;
    private int dir = 2;
    // Use this for initialization
    int gotime = 0;
    bool saying = false;
    public GameObject say;
    public UILabel sayline;
    public UITexture icon;
    public SpriteRenderer des;
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (PlayerPrefs.GetInt("MapChange") == 1)
        {
            gameObject.transform.position = new Vector3(-17.71f,0.89f,0);
            PlayerPrefs.DeleteKey("MapChange");
        }
        camera.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,-10);
       
    }

    // Update is called once per frame

    void FixedUpdate()
    {


        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position += new Vector3(0.05f, 0, 0);
            camera.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
            gotime++;
            if (gotime % (60 * 4 / framesPerSecond) < (60 / framesPerSecond)) spriteRenderer.sprite = sprites[9];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 2 / framesPerSecond)) spriteRenderer.sprite = sprites[10];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 3 / framesPerSecond)) spriteRenderer.sprite = sprites[11];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 4 / framesPerSecond)) spriteRenderer.sprite = sprites[8];


        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.position += new Vector3(-0.05f, 0, 0);
            camera.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
            gotime++;
            if (gotime % (60 * 4 / framesPerSecond) < (60 / framesPerSecond)) spriteRenderer.sprite = sprites[5];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 2 / framesPerSecond)) spriteRenderer.sprite = sprites[6];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 3 / framesPerSecond)) spriteRenderer.sprite = sprites[7];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 4 / framesPerSecond)) spriteRenderer.sprite = sprites[4];


        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.position += new Vector3(0, 0.05f, 0);
            camera.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
            gotime++;
            if (gotime % (60 * 4 / framesPerSecond) < (60 / framesPerSecond)) spriteRenderer.sprite = sprites[13];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 2 / framesPerSecond)) spriteRenderer.sprite = sprites[14];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 3 / framesPerSecond)) spriteRenderer.sprite = sprites[15];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 4 / framesPerSecond)) spriteRenderer.sprite = sprites[12];



        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.position += new Vector3(0, -0.05f, 0);
            camera.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
            gotime++;
            if (gotime % (60 * 4 / framesPerSecond) < (60 / framesPerSecond)) spriteRenderer.sprite = sprites[1];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 2 / framesPerSecond)) spriteRenderer.sprite = sprites[2];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 3 / framesPerSecond)) spriteRenderer.sprite = sprites[3];
            else if (gotime % (60 * 4 / framesPerSecond) < (60 * 4 / framesPerSecond)) spriteRenderer.sprite = sprites[0];


        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            dir = 6;
            gotime = 0;
            spriteRenderer.sprite = sprites[8];
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            dir = 4;
            gotime = 0;
            spriteRenderer.sprite = sprites[4];
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            dir = 8;
            gotime = 0;
            spriteRenderer.sprite = sprites[12];
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            dir = 2;
            gotime = 0;
            spriteRenderer.sprite = sprites[0];
        }



        if (Input.GetKeyUp(KeyCode.Z))
        {

            Application.LoadLevelAsync(0);

        }




    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Door")
        {
            if (Equals(collision.ToString().Split(' ')[0], "Map1_1_1"))
            {
                PlayerPrefs.SetInt("MapChange", 1);
                Application.LoadLevelAsync(2);
                //StartCoroutine(goMap(2));
                
            }
            else if (Equals(collision.ToString().Split(' ')[0], "Map1_2_1"))
            {
                PlayerPrefs.SetInt("MapChange", 1);
                Application.LoadLevelAsync(1);
                //StartCoroutine(goMap(1));
            }

        }

        if (collision.tag == "Npc")
        {
            if (gameObject.transform.position.y < collision.transform.position.y)
            {

                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
            else if (gameObject.transform.position.y > collision.transform.position.y)
            {

                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
        }


    }


    //文本
    //行數 1對話or2選項 頭像 "名字" "對話" 接續(下句留空.0結束.跳行行數)
    private struct Line
    {
        public int row;
        public int state;
        public string icon;
        public string name;
        public string line;
        public int toRow;
        public string[] lines;
        public int[] toRows;

    }
    ArrayList LineList = new ArrayList();
    int startline = 1;
    int readingline;
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Npc")
        {
            if (gameObject.transform.position.y < collision.transform.position.y)
            {

                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 3;
            }
            else if (gameObject.transform.position.y > collision.transform.position.y)
            {

                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }

            //對話動畫延遲判斷尚未處理
            if (Input.GetKeyDown(KeyCode.X) && !say.GetComponent<Animator>().GetBool("saying") && !saying)
            {

                say.GetComponent<Animator>().SetBool("close", false);
                say.GetComponent<Animator>().SetBool("saying", true);
                saying = true;

                //事先讀好文本
                string startchapter = "1_1";
                
                string[] strLines2;
                string strContent = ((TextAsset)Resources.Load("Lines/1_1")).text;
                string[] strLines = strContent.Split('\n');
                for (int nIndex = 0; nIndex < strLines.Length; nIndex++)
                {

                    if (strLines[nIndex].IndexOf("\\") == 0) { continue; }
                    else if (strLines[nIndex].IndexOf("^") == 0)
                    {

                        strLines2 = strLines[nIndex].Split(',');
                        Line temp = new Line();
                        temp.row = int.Parse(strLines2[0].Split('^')[1]);
                        temp.state = int.Parse(strLines2[1]);
                        temp.icon = strLines2[2];
                        temp.name = strLines2[3];
                        if (temp.state == 1)
                        {//一般對話
                            temp.line = strLines2[4];

                            if (strLines2.Length == 6) temp.toRow = int.Parse(strLines2[5]);
                            else
                            {
                                temp.toRow = -1;
                            }

                        }
                        else if (temp.state == 2)
                        {//選項對話


                        }
                        LineList.Add(temp);
                    }
                }

                //判斷npc對話行數
                if (Equals(collision.ToString().Split(' ')[0], "npc1")) {

                    readingline = 1;

                }
                
            }
            else if (Input.GetKeyDown(KeyCode.X) && say.GetComponent<Animator>().GetBool("saying") && saying)
            {

                //觸發對話後點擊
                for (int i = 0; i < LineList.Count; i++)
                {
                    if (((Line)LineList[i]).row == readingline)
                    {

                        if (((Line)LineList[i]).state == 1)
                        {
                            icon.mainTexture=(Texture)Resources.Load("icon/"+((Line)LineList[i]).icon,typeof(Texture));
                            sayline.text ="";
                            StartCoroutine(Lineing(((Line)LineList[i]).line));
                            if (((Line)LineList[i]).toRow == -1)
                                readingline++;
                            else if (((Line)LineList[i]).toRow == 0)
                            {
                                saying = false;
                                
                            }
                            else
                                readingline = ((Line)LineList[i]).toRow;

                            break;
                        }
                        else if (((Line)LineList[i]).state == 2)
                        {

                        }
                    }
                }


            }
            else if (Input.GetKeyDown(KeyCode.X) && say.GetComponent<Animator>().GetBool("saying") && !saying)
            {
                sayline.text = "";
                icon.mainTexture = null;
                say.GetComponent<Animator>().SetBool("saying", false);
                say.GetComponent<Animator>().SetBool("close", true);

            }



        }

        

}
    public IEnumerator Lineing(string line)
    {

        yield return new WaitForSeconds(0.02f);
        sayline.text += (char)line[0];

        

        if (sayline.lineHeight == 30) sayline.transform.localPosition =new Vector3(sayline.transform.localPosition.x, -621,0);
        else if (sayline.lineHeight == 60) sayline.transform.localPosition = new Vector3(sayline.transform.localPosition.x, -721, 0);
        else if (sayline.lineHeight == 90) sayline.transform.localPosition = new Vector3(sayline.transform.localPosition.x, -821, 0);

        if (line.Length > 1)
        {
            line = line.Substring(1, line.Length - 1);
            StartCoroutine(Lineing(line));
        }
    }
    IEnumerator goMap(int i)
    {
        des.GetComponent<Animator>().enabled = true;
        
        
        yield return new WaitForSeconds(1f);
        
            Application.LoadLevelAsync(i);
        
           
        


    }

}
