using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

    public Transform demoStartPoint;
    public Transform playStartPoint;
    public GameObject player;
    public GameObject[] introSlides;
    public GameObject Island;
    public GameObject instructionUI;
    public GameObject[] instructions;

    private GameObject activeLeaf;
    private float moveTime = 4.0f;
    private int slideIndex = 0;
    private float  slideTime= 9.0f;
    private float startIntroTime = 2.0f;
    private float nextSlideTime;
    private int numSlides = 0;
    private int numInstructions = 0;
    private int instructionIndex = 0;

    private void Awake()
    {
        player.transform.position = demoStartPoint.transform.position;
        nextSlideTime = startIntroTime;
        Island.SetActive(false);
        foreach (GameObject slide in introSlides)
        {
            slide.SetActive(false);
        }

        instructionUI.SetActive(false);
        foreach (GameObject instruction in instructions)
        {
            instruction.SetActive(false);
        }
        
    }

    private void Start()
    {
        numSlides = introSlides.Length;
        numInstructions = instructions.Length;
        int i = 1;
        foreach (GameObject slide in introSlides)
        {
            Invoke("runAnimations", nextSlideTime);
            nextSlideTime = startIntroTime + (slideTime * i);
            i++;
            Debug.Log("done");
        }
        Invoke("runAnimations", nextSlideTime);
    }

    private void runAnimations()
    {
        Debug.Log("run Animations called" + Time.time);
        if (slideIndex == numSlides)
        {
            introSlides[slideIndex - 1].SetActive(false);
            Invoke("DisplayInstructions", 3.0f);
            return;
        }
        else if (slideIndex == numSlides-1)
        {
            introSlides[slideIndex - 1].SetActive(false);
            Island.SetActive(true);
        }
        else if (slideIndex > 0)
        {
            introSlides[slideIndex - 1].SetActive(false);
        }
        introSlides[slideIndex].GetComponent<Animator>().SetBool("runSlide", true);
        introSlides[slideIndex].SetActive(true);
        slideIndex++;
    }

    private void DisplayInstructions()
    {
        instructionUI.SetActive(true);
        instructions[instructionIndex].SetActive(true);
    }

    public void NextInstruction()
    {
        instructions[instructionIndex].SetActive(false);
        instructionIndex++;
        instructions[instructionIndex].SetActive(true);
    }

    public void GoToIsland()
    {
        instructionUI.SetActive(false);
        iTween.MoveTo(player,
            iTween.Hash(
                 "position", playStartPoint.transform.position,
                 "time", moveTime,
                 "easytype", "linear"
             )
         );
    }

    public void LeafActivated(GameObject leaf)
    {
        activeLeaf = leaf;
    }

    public void NextSlide()
    {
        activeLeaf.GetComponent<FinalLeafControl>().MoveToNextSlide();
    }

    public void GoBackToStartPoint()
    {
        activeLeaf.GetComponent<FinalLeafControl>().MoveToStartPoint();
    }

    public void StopVideoIfRunning()
    {
        activeLeaf.GetComponentInChildren<StreamVideo>().StopVideo();
    }


    
}
