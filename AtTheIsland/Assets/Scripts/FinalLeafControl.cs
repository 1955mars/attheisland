using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalLeafControl : MonoBehaviour
{

    public GameLogic gameLogic;
    public Texture introImage;
    public TextMesh introText;
    public TextMesh[] slideContent;
    public Texture[] slideImages;

    public GameObject player;
    public GameObject frontScreen;
    public GameObject backScreen;
    public GameObject frontScreenTransformOnLeaf;
    public GameObject backScreenTransformOnLeaf;
    public GameObject playStartPoint;

    public TextMesh vrGuideMessage;
    public RawImage vrGuideImage;

    public GameObject MainEntranceUI;
    public Transform startPoint;
    public Transform endPoint;
    public Transform insideTheatre;
    public GameObject enterTheatreText;
    public Animator m_doorAnimator;

    private Vector3 playerInitialPosition;

    private int numOfSlides;
    private Vector3 posDiff;

    private int slideIndex = 0;
    private float moveTime = 0.75f;

    // Use this for initialization
    void Start()
    {


        frontScreen.SetActive(false);
        backScreen.SetActive(false);
        enterTheatreText.SetActive(false);
        
        numOfSlides = slideContent.Length;
        posDiff = endPoint.transform.position - startPoint.transform.position;
        posDiff = posDiff / (numOfSlides + 1);


        playerInitialPosition = playStartPoint.transform.position;

        m_doorAnimator.SetBool("openDoor", false);
        Debug.Log(posDiff);

    }


    public void StartSlideShow()
    {
        gameLogic.LeafActivated(this.gameObject);
        Debug.Log("Slide show started");
        vrGuideMessage.text = introText.text;
        vrGuideImage.texture = introImage;
        iTween.MoveTo(player,
            iTween.Hash(
                 "position", startPoint.transform.position,
                 "time", moveTime,
                 "easytype", "linear"
             )
         );

        frontScreen.transform.parent = frontScreenTransformOnLeaf.transform;
        frontScreen.transform.localRotation = Quaternion.identity;
        frontScreen.transform.localPosition = Vector3.zero;
        frontScreen.transform.localScale = Vector3.one;

        backScreen.transform.parent = backScreenTransformOnLeaf.transform;
        backScreen.transform.localRotation = Quaternion.identity;
        backScreen.transform.localPosition = Vector3.zero;
        backScreen.transform.localScale = Vector3.one;


        Invoke("MakeScreenChildToPlayer", moveTime);

        //player.transform.localRotation = startPoint.transform.rotation;
        frontScreen.SetActive(true);
        MainEntranceUI.SetActive(false);
    }

    void MakeScreenChildToPlayer()
    {
        frontScreen.transform.parent = player.transform;
        backScreen.transform.parent = player.transform;
    }

    public void MoveToNextSlide()
    {
        if (slideIndex == 0)
        {
            backScreen.SetActive(true);
        }
        if (slideIndex < numOfSlides)
        {
            iTween.MoveTo(player,
                    iTween.Hash(
                        "position", player.transform.position + posDiff,
                        "time", moveTime,
                        "easytype", "linear"
                    )
                );
            vrGuideMessage.text = slideContent[slideIndex].text;
            vrGuideImage.texture = slideImages[slideIndex];
            slideIndex++;
            Debug.Log(posDiff);
        }
        else if (slideIndex == numOfSlides)
        {
            MoveToEndPoint();
            slideIndex++;
        }
    }

    public void MoveToStartPoint()
    {
        iTween.MoveTo(player,
            iTween.Hash(
                "position", playerInitialPosition,
                "time", moveTime * (slideIndex + 1),
                "easytype", "linear"
            )
        );
        Invoke("SetActiveAfterSeconds", moveTime * (slideIndex + 1));
        slideIndex = 0;
        vrGuideMessage.text = introText.text;
        vrGuideImage.texture = introImage;
        frontScreen.SetActive(false);
        backScreen.SetActive(false);
        m_doorAnimator.SetBool("openDoor", false);
        //MainEntranceUI.SetActive(true);
    }

    void SetActiveAfterSeconds()
    {
        MainEntranceUI.SetActive(true);
    }

    public void MoveToEndPoint()
    {
        iTween.MoveTo(player,
             iTween.Hash(
                 "position", player.transform.position + posDiff,
                 "time", moveTime,
                 "easytype", "linear"
             )
         );
        frontScreen.SetActive(false);
        m_doorAnimator.SetBool("openDoor", true);
        Invoke("ShowEnterText", 1.5f);
    }

    public void MoveInsideTheatre()
    {
        enterTheatreText.SetActive(false);
        iTween.MoveTo(player,
             iTween.Hash(
                 "position", insideTheatre.transform.position,
                 "time", moveTime,
                 "easytype", "linear"
             )
         );
    }

    private void ShowEnterText()
    {
        enterTheatreText.SetActive(true);
    }
}
