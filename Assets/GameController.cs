using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public BasicObjectPool answerButtonObjectPool;
    public Text questionText;
    public Text scoreText;
    public Text timeText;
    public Transform answerButtonParent;
    public GameObject questionPanel;
    public GameObject levelFinishedPanel;

    private Manager dataController;
    private LevelData currentLevelData;
    private Questions[] questionPool;

    private bool isLevelActive;
    private float timeRemaining;
    private int questionIndex;
    private int playerScore;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

	// Use this for initialization
	void Start () {
        dataController = FindObjectOfType<Manager>();
        currentLevelData = dataController.GetCurrentLevelData();
        questionPool = currentLevelData.question;
        timeRemaining = currentLevelData.limitSeconds;
        UpdateTimeRemaining();

        playerScore = 0;
        questionIndex = 0;

        ShowQuestion();
        isLevelActive = true;
	}
	
    private void ShowQuestion()
    {
        RemoveAnswerButton();
        Questions questionData = questionPool[questionIndex];
        questionText.text = questionData.questionText;

        for(int i = 0; i < questionData.answers.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObject.transform.SetParent(answerButtonParent);
            answerButtonGameObjects.Add(answerButtonGameObject);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(questionData.answers[i]);
        }
    }

    public void AnswerButtonClicked(bool isCorrect)
    {
        if(isCorrect)
        {
            playerScore += currentLevelData.score;
            scoreText.text = "Score : " + playerScore.ToString();
        }
        if(questionPool.Length > questionIndex + 1)
        {
            questionIndex++;
            ShowQuestion();
        }
    }

    public void EndRound()
    {
        isLevelActive = false;

        questionPanel.SetActive(false);
        levelFinishedPanel.SetActive(true);
    }

    private void RemoveAnswerButton()
    {
        while(answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    public void ReturnToMenu()
    {
        //SceneManager.LoadScene();
    }

    private void UpdateTimeRemaining()
    {
        timeText.text = "Time : " + Mathf.Round(timeRemaining).ToString();
    }

	// Update is called once per frame
	void Update () {
		if(isLevelActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemaining();

            if(timeRemaining <= 0f)
            {
                EndRound();
            }
        }
	}
}
