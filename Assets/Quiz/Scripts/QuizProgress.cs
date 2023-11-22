using TMPro;
using UnityEngine;

namespace Quiz
{
    public class QuizProgress : MonoBehaviour
    {
        #region Variables
        [SerializeField] private TMP_Text quizProgressText;
        #endregion

        #region Builtin Methods
        private void Start()
        {
            EventManager.StartListening("UpdateQuizProgress", onUpdateQuizProgress);
        }

        private void OnDestroy()
        {
            EventManager.StopListening("UpdateQuizProgress", onUpdateQuizProgress);
        }
        #endregion

        #region Custom Methods
        public void onUpdateQuizProgress(EventParam eventParam)
        {
            var current = eventParam.param1;
            var length = eventParam.param2;
            quizProgressText.text = current + "/" + length;
        }
        #endregion

    }
}
