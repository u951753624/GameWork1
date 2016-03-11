using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStart : MonoBehaviour {

	// Use this for initialization
    public UILabel text1;
    public UILabel text2;
    private Color color;
    private Color black;
    private Color desc;
    public SpriteRenderer des;
    
    
    public AudioSource Choose;
    void Start () {
        text1.GetComponent<TweenColor>().enabled = true;
        
        text2.GetComponent<TweenColor>().enabled = false;
        color.r = 1;
        color.g = 1;
        color.b = 0;
        color.a = 1;
        black.r = 0;
        black.b = 0;
        black.g = 0;
        black.a = 0;
        desc.r = 1;
        desc.b = 1;
        desc.g = 1;
        desc.a = 0;
        des.color = desc;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetKeyDown(KeyCode.UpArrow)) {
           

            
            Choose.Play();
            if (text1.GetComponent<TweenColor>().enabled == true)
            {
                text1.GetComponent<TweenColor>().enabled = false;
                text2.GetComponent<TweenColor>().enabled = true;
                text1.color = color;

            }
            else {
                text1.GetComponent<TweenColor>().enabled = true;
                text2.GetComponent<TweenColor>().enabled = false;
                text2.color = color;
            }

        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            Choose.Play();
            if (text1.GetComponent<TweenColor>().enabled == true)
            {
                StartCoroutine(index(1));
                

            }
            else
            {
                StartCoroutine(index(2));
                
            }

        }
	}
    IEnumerator index(int i)
    {
        des.GetComponent<Animator>().enabled = true;
        text1.GetComponent<TweenColor>().enabled = false;
        text2.GetComponent<TweenColor>().enabled = false;
        //text1.color = black;
        //text2.color = black;
        yield return new WaitForSeconds(1f);
        if (i == 1)
        {
            Application.LoadLevelAsync(1);
        }
        if (i == 2)
        {
            Application.Quit();
        }


    }
}
