using TMPro;
using UnityEngine;

namespace Quiz
{
    public class QuizScore : MonoBehaviour
    {
        #region Variables
        [SerializeField] private TMP_Text quizSCoreText;
        #endregion

        #region Builtin Methods
        private void Start()
        {
            EventManager.StartListening("UpdateScore", OnUpdateScoreProgress);
        }

        private void OnDestroy()
        {
            EventManager.StopListening("UpdateScore", OnUpdateScoreProgress);
        }
        #endregion

        #region Custom Methods
        public void OnUpdateScoreProgress(EventParam eventParam)
        {
            var score = eventParam.param1;
            var length = eventParam.param2;
            quizSCoreText.text = score + "/" + length;
        }
        #endregion

    }
}
