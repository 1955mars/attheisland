using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StreamVideo : MonoBehaviour {

    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public GvrAudioSource audioSource;
    public GameObject playButton;
    public GameObject bigPlayButton;
    public GameObject pauseButton;
    public GameObject bigPauseButton;

    private GameObject player;
    private bool hasStarted;

    private void Start()
    {
        rawImage.gameObject.SetActive(false);

        bigPlayButton.SetActive(false);
        bigPauseButton.SetActive(false);
        playButton.SetActive(true);
        pauseButton.SetActive(false);

        hasStarted = false;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void StartVideo () {

        player.GetComponentInChildren<AudioSource>().volume = 0.1f;

        if (!hasStarted)
        {
            bigPlayButton.SetActive(false);
            playButton.SetActive(false);
            pauseButton.SetActive(true);
            rawImage.gameObject.SetActive(true);
            StartCoroutine(PlayVideo());
            hasStarted = true;
        }
        else
        {
            bigPlayButton.SetActive(false);
            playButton.SetActive(false);
            bigPauseButton.SetActive(true);
            pauseButton.SetActive(true);

            videoPlayer.Play();
            audioSource.Play();
            Invoke("DeactivePauseButton", 0.5f);
        }

    }
	
    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while(!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        audioSource.Play();
    }

    public void PauseVideo()
    {
        pauseButton.SetActive(false);
        bigPlayButton.SetActive(true);
        playButton.SetActive(true);

        videoPlayer.Pause();
        audioSource.Pause();
        player.GetComponentInChildren<AudioSource>().volume = 1.0f;
    }

    void DeactivePauseButton()
    {
        bigPauseButton.SetActive(false);
    }

    public void StopVideo()
    {
        if (hasStarted)
        {
            videoPlayer.Stop();
            audioSource.Stop();
            rawImage.gameObject.SetActive(false);

            bigPlayButton.SetActive(true);
            bigPauseButton.SetActive(false);
            playButton.SetActive(true);
            pauseButton.SetActive(false);

            hasStarted = false;
            player.GetComponentInChildren<AudioSource>().volume = 1.0f;
        }
    }

}
