using TMPro;
using UnityEngine;

namespace Quiz
{
    public class AnswerButton : MonoBehaviour
    {
        #region Custom Methods
        public void submitResponse()
        {
            EventManager.TriggerEvent("TouchedUI", new EventParam { });
            string response = gameObject.GetComponentInChildren<TMP_Text>().text;
            EventManager.TriggerEvent("SubmitResponse", new EventParam { param5 = response });
        }
        #endregion

    }
}
