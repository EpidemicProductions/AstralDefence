using UnityEngine;
using System.Collections;

public class WinLose : MonoBehaviour {
    public GameObject tech;

    int count;
    GameObject[] gos;

    public GameObject winOrLose;
    public GameObject winText;
    public GameObject loseText;
    public GameObject starRatingWin;
    public GameObject starRatingLose;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject restart;
    public GameObject nextLevel;

    public bool win;

    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("CountEnemies", 5f, 1f);
        win = false;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void CountEnemies()
    {
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        count = gos.Length;

        if(win)
        {
            Time.timeScale = 0;
            winOrLose.SetActive(true);
            winText.SetActive(true);
            nextLevel.SetActive(true);

            if (tech.GetComponent<Energy>().heartsVal >= 5)
            {
                Time.timeScale = 0;
                starRatingWin.SetActive(true);
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
            }
            if(tech.GetComponent<Energy>().heartsVal >= 3 && tech.GetComponent<Energy>().heartsVal < 5)
            {
                Time.timeScale = 0;
                starRatingWin.SetActive(true);
                star1.SetActive(true);
                star2.SetActive(true);
            }
            if (tech.GetComponent<Energy>().heartsVal >= 1 && tech.GetComponent<Energy>().heartsVal < 3)
            {
                Time.timeScale = 0;
                starRatingWin.SetActive(true);
                star1.SetActive(true);
            }

        }

        if(tech.GetComponent<Energy>().heartsVal <= 0)
        {
            Time.timeScale = 0;
            winOrLose.SetActive(true);
            loseText.SetActive(true);
            restart.SetActive(true);

        }
    }
}
