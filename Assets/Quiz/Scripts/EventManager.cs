using System;
using System.Collections.Generic;
using UnityEngine;

namespace Quiz
{
    public struct EventParam
    {
        public int param1;
        public int param2;
        public float param3;
        public bool param4;
        public string param5;
    }

    public class EventManager : MonoBehaviour
    {
        #region Variables

        private Dictionary<string, Action<EventParam>> eventDictionary;
        private static EventManager eventManager;

        public static EventManager Instance
        {
            get
            {
                if (eventManager) return eventManager;
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init();
                }

                return eventManager;
            }
        }

        #endregion

        #region Custom Methods

        private void Init()
        {
            if (eventDictionary != null) return;
            eventDictionary = new Dictionary<string, Action<EventParam>>();
            Debug.Log("initializing...");
        }

        public static void StartListening(string eventName, Action<EventParam> listener)
        {
            if (Instance.eventDictionary.TryGetValue(eventName, out Action<EventParam> thisEvent))
            {
                thisEvent += listener;
                //Update the Dictionary
                Instance.eventDictionary[eventName] = thisEvent;
            }
            else
            {
                thisEvent += listener;
                Instance.eventDictionary.Add(eventName, thisEvent);
            }
        }

        public static void StopListening(string eventName, Action<EventParam> listener)
        {
            if (eventManager == null) return;
            if (Instance.eventDictionary.TryGetValue(eventName, out Action<EventParam> thisEvent))
            {
                thisEvent -= listener;
            }
        }

        public static void TriggerEvent(string eventName, EventParam eventParam)
        {
            if (!Instance.eventDictionary.TryGetValue(eventName, out Action<EventParam> thisEvent)) return;
            thisEvent?.Invoke(eventParam);
        }

        #endregion
    }
}