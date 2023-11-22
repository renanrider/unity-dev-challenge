using UnityEngine;
using UnityEngine.UI;

namespace Quiz
{
    public class UIManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] private Button buttonStart;
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject quizPanel;
        [SerializeField] private GameObject quizResult;
        [SerializeField] private GameObject _Dynamic;

        #endregion

        #region Builtin Methods

        private void Start()
        {
            Screen.SetResolution(1080, 1920, false);
            EventManager.StartListening("QuizFinish", QuizResult);
        }

        private void OnDestroy()
        {
            EventManager.StopListening("QuizFinish", QuizResult);
        }

        #endregion

        #region Custom Methods  

        private void QuizResult(EventParam eventParam)
        {
            quizPanel.SetActive(true);
            _Dynamic.SetActive(false);
            quizResult.SetActive(true);
        }

        public void StartQuiz()
        {
            EventManager.TriggerEvent("TouchedUI", new EventParam { });
            startPanel.GetComponent<Animator>().SetBool("isStartPanelHidden", true);
            quizPanel.GetComponent<Animator>().SetBool("isQuizPanelHidden", false);
            quizPanel.SetActive(true);
            _Dynamic.SetActive(true);
            quizResult.SetActive(false);
        }

        public void TryAgainQuiz()
        {
            EventManager.TriggerEvent("StartQuiz", new EventParam { });
            EventManager.TriggerEvent("TouchedUI", new EventParam { });
            startPanel.GetComponent<Animator>().SetBool("isStartPanelHidden", false);
            quizPanel.GetComponent<Animator>().SetBool("isQuizPanelHidden", true);
        }

        #endregion
    }
}