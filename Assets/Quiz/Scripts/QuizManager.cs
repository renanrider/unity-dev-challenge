using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Quiz
{
    public class QuizManager : MonoBehaviour
    {
        #region Variables
        public GameObject questionTextPrefab;
        public GameObject answerButtonPrefab;
        public GameObject dynamic;
        public List<QuizQuestion> quizQuestions;
        public int currentQuestionIndex = 0;
        public int score = 0;
        public List<GameObject> quizGameObjects;
        #endregion

        #region Builtin Methods
        void Start()
        {

            EventManager.StartListening("SubmitResponse", OnSubmitQuestion);
            EventManager.StartListening("StartQuiz", OnStartQuiz);
            Setup();
        }

        private void OnDestroy()
        {
            EventManager.StopListening("SubmitResponse", OnSubmitQuestion);
            EventManager.StopListening("StartQuiz", OnStartQuiz);
        }
        #endregion

        #region Custom Methods
        public void OnStartQuiz(EventParam eventParam)
        {
            EventManager.TriggerEvent("UpdateQuizProgress", new EventParam { param1 = 1, param2 = quizGameObjects.Count });
            EventManager.TriggerEvent("UpdateScore", new EventParam { param1 = 0, param2 = quizGameObjects.Count });
        }

        public QuizQuestion GetCurrentQuestion()
        {
            return quizQuestions[currentQuestionIndex];
        }

        void Setup()
        {
            Transform dynamicTransform = dynamic.transform; // transform.GetChild(1);
            foreach (QuizQuestion quizQuestion in quizQuestions)
            {
                float y = 0;
                // Instantiate a new questionWrapper for each quizQuestion
                GameObject questionWrapper = Instantiate(new GameObject("questionWrapper"), dynamicTransform, false);

                // Instantiate title using questionTextPrefab and set its text
                GameObject title = Instantiate(questionTextPrefab, questionWrapper.transform, false);
                title.GetComponent<TMP_Text>().text = quizQuestion.question;

                foreach (string answer in quizQuestion.answers)
                {
                    // Instantiate answerButton using answerButtonPrefab and set its text
                    GameObject answerButton = Instantiate(answerButtonPrefab, questionWrapper.transform, false);
                    answerButton.GetComponentInChildren<TMP_Text>().text = answer;
                    // Adjust the position of the answerButton
                    answerButton.transform.localPosition = new Vector3(answerButton.transform.position.x, y, answerButton.transform.position.z);
                    // Use negative y to move downwards
                    y -= 38f; 

                }
                questionWrapper.SetActive(false);
                quizGameObjects.Add(questionWrapper);
            }
            // show the first quiz
            quizGameObjects[0].SetActive(true);

        }

        public void OnSubmitQuestion(EventParam eventParam)
        {
            if (currentQuestionIndex < quizGameObjects.Count - 1)
            {
                if (eventParam.param5 == GetCurrentQuestion().answers[GetCurrentQuestion().correct - 1])
                {
                    score++;
                    EventManager.TriggerEvent("UpdateScore", new EventParam { param1 = score + 1, param2 = quizGameObjects.Count });
                }

                quizGameObjects[currentQuestionIndex].SetActive(false);
                currentQuestionIndex++;
                quizGameObjects[currentQuestionIndex].SetActive(true);
                EventManager.TriggerEvent("UpdateQuizProgress", new EventParam { param1 = currentQuestionIndex + 1, param2 = quizGameObjects.Count });            

            }
            else
            {              
                EventManager.TriggerEvent("UpdateQuizProgress", new EventParam { param1 = quizGameObjects.Count, param2 = quizGameObjects.Count });
                EventManager.TriggerEvent("UpdateResultText", new EventParam { param1 = score + 1, param2 = quizGameObjects.Count });
                EventManager.TriggerEvent("QuizFinish", new EventParam { });
                quizGameObjects[currentQuestionIndex].SetActive(false);
                quizGameObjects[0].SetActive(true);
                currentQuestionIndex = 0;
                score = 0;
            }

        }
        #endregion
    }
}