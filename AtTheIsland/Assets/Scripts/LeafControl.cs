using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeafControl : MonoBehaviour {

    enum ShowingSlide { None, Left, Right};

    public GameObject player;
    public Text leftSlide;
    public Text rightSlide;
    public Text backSlide;
    public GameObject leftSlideOutline;
    public GameObject rightSlideOutline;
    public GameObject backSlideOutline;
    public GameObject theatreEntrance;
    public Transform startPoint;
    public Transform endPoint;
    public Transform InsideTheatre;
    public string []  slideContent;

    private Vector3 playerInitialPosition;
    private int numOfSlides;
    private Vector3 Diff;

    private int slideIndex = 0;
    private float moveTime = 0.5f;
    private ShowingSlide activeSlide = ShowingSlide.None;

    // Use this for initialization
    void Start () {

        leftSlideOutline.SetActive(false);
        rightSlideOutline.SetActive(false);
        backSlideOutline.SetActive(false);
        theatreEntrance.SetActive(false);


        numOfSlides = slideContent.Length;
        Diff = endPoint.transform.position - startPoint.transform.position;
        Diff = Diff / (numOfSlides+1);
        playerInitialPosition = player.transform.position;

        Debug.Log(Diff);

	}
	
    public void StartSlideShow ()
    {
        Debug.Log("Slide show started");
        MoveToNextSlide();
        backSlideOutline.SetActive(true);
    }

    public void MoveToNextSlide ()
    {
        if (slideIndex < numOfSlides)
        {
            iTween.MoveTo(player,
                    iTween.Hash(
                        "position", player.transform.position + Diff,
                        "time", moveTime,
                        "easytype", "linear"
                    )
                );
            if (activeSlide == ShowingSlide.None || activeSlide == ShowingSlide.Right)
            {
                leftSlideOutline.SetActive(true);
                rightSlideOutline.SetActive(false);
                leftSlide.text = slideContent[slideIndex];
                activeSlide = ShowingSlide.Left;
            }
            else
            {
                leftSlideOutline.SetActive(false);
                rightSlideOutline.SetActive(true);
                rightSlide.text = slideContent[slideIndex];
                activeSlide = ShowingSlide.Right;
            }

            slideIndex++;
            Debug.Log(Diff);
        }
        else if (slideIndex == numOfSlides)
        {
            MoveToEndPoint();
            slideIndex++;
        }
    }

    public void MoveToStartPoint ()
    {
        iTween.MoveTo(player,
            iTween.Hash(
                "position", playerInitialPosition,
                "time", moveTime*(slideIndex+1),
                "easytype", "linear"
            )
        );

        leftSlideOutline.SetActive(false);
        rightSlideOutline.SetActive(false);
        activeSlide = ShowingSlide.None;
        slideIndex = 0;
        backSlideOutline.SetActive(false);
    }

    public void MoveToEndPoint()
    {
        theatreEntrance.SetActive(true);
        iTween.MoveTo(player,
             iTween.Hash(
                 "position", player.transform.position + Diff,
                 "time", moveTime,
                 "easytype", "linear"
             )
         );

        leftSlideOutline.SetActive(false);
        rightSlideOutline.SetActive(false);
        activeSlide = ShowingSlide.None;
    }

    public void MoveInsideTheatre()
    {
        iTween.MoveTo(player,
             iTween.Hash(
                 "position", InsideTheatre.transform.position,
                 "time", moveTime,
                 "easytype", "linear"
             )
         );
        theatreEntrance.SetActive(false);
    }
}
