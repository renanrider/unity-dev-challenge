using TMPro;
using UnityEngine;

namespace Quiz
{
    public class QuizResult : MonoBehaviour
    {
        #region Variables
        [SerializeField] private TMP_Text quizResultText;
        #endregion

        #region Builtin Methods
        private void Start()
        {
            EventManager.StartListening("UpdateResultText", UpdateResultText);
        }

        private void OnDestroy()
        {
            EventManager.StopListening("UpdateResultText", UpdateResultText);
        }
        #endregion

        #region Custom Methods
        public void UpdateResultText(EventParam eventParam)
        {
            var score = eventParam.param1;
            var length = eventParam.param2;

            if (score == length)
            {
                quizResultText.text = "Parab�ns";
                EventManager.TriggerEvent("PlayParticle", new EventParam { });
                EventManager.TriggerEvent("VictorySfx", new EventParam {});               
            }
            else
            {
                quizResultText.text = "Voc� achou que qualquer op��o era correta! :(";
                EventManager.TriggerEvent("LoseSfx", new EventParam { });

            }

        }
        #endregion
    }
}
