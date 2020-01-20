using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWonTime : MonoBehaviour {

    public Text currentTime;
    public GameObject starOne;
    public GameObject starTwo;
    public GameObject starThree;

    void Start () {

        currentTime.text = PlayerPrefs.GetInt("CurrentTime").ToString();

        if (PlayerPrefs.GetInt("CurrentTime") <= 25)
        {
            starOne.SetActive(true);
            starTwo.SetActive(true);
            starThree.SetActive(true);
        }

        if (PlayerPrefs.GetInt("CurrentTime") >= 25 && PlayerPrefs.GetInt("CurrentTime") <= 35)
        {
            starOne.SetActive(true);
            starTwo.SetActive(true);
        }

        if (PlayerPrefs.GetInt("CurrentTime") > 35)
        {
            starOne.SetActive(true);
        }
    }
	
}
