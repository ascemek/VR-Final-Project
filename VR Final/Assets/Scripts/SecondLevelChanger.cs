//LATEST VERSION
//04/29/21
//@author Sami Cemek


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SecondLevelChanger : MonoBehaviour
{
    private int levelToLoad;
    public Animator animator;
    public float startingTime = 15f;
    [SerializeField] float currentTime = 0f;
    [SerializeField] Text countdownText;
    private Vector3 sunPosition;

    void Start()
    {
        currentTime = startingTime;
        //sunPosition = GameObject.FindGameObjectsWithTag("Sun").transform.position;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
        }

        //Change color of countdown text to red when current time is less or equal to 10
        if (currentTime <= 10)
        {
            countdownText.color = Color.red;
        }

        //Change scene and disable canvas when current time is less than or equal to 0
        if (currentTime <= 0)
        {
            //countdownText.text = ("Out of time!");
            FadeToLevel(2);
            DisableCanvas();
        }
    }

public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("Fadeout");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    //Disabiling the canvas on the scene
    public void DisableCanvas()
    {
        GameObject canvasPrefab = transform.Find("myCanvas").gameObject;
        canvasPrefab.SetActive(false);
    }
}
