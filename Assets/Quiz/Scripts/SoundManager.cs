using UnityEngine;
using UnityEngine.Audio;

namespace Quiz
{
    public class SoundManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] private AudioMixer masterMixer;
        [SerializeField] private AudioSource soundEffectsAudio;

        public AudioClip touchedUI;
        public AudioClip victorySfx;
        public AudioClip loseSfx;
        private static SoundManager _soundManager;

        public static SoundManager Instance
        {
            get { return _soundManager; }
        }

        #endregion

        #region Builtin Methods

        private void Awake()
        {
            if (_soundManager == null)
            {
                _soundManager = this;
            }
            else if (_soundManager != this)
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            EventManager.StartListening("TouchedUI", PlayTouchedUI);
            EventManager.StartListening("VictorySfx", PlaySoundVictorySfx);
            EventManager.StartListening("LoseSfx", PlaySoundLoseSfx);
            soundEffectsAudio = GetComponent<AudioSource>();   
        }

        private void OnDestroy()
        {
            EventManager.StopListening("TouchedUI", PlayTouchedUI);
            EventManager.StopListening("VictorySfx", PlaySoundVictorySfx);
            EventManager.StopListening("LoseSfx", PlaySoundLoseSfx);
        }

        #endregion

        #region Custom Methods

        private void PlayTouchedUI(EventParam eventParam)
        {
            PlaySingleEffect(touchedUI);
        }

        private void PlaySoundVictorySfx(EventParam eventParam)
        {
            PlaySingleEffect(victorySfx);
        }

        private void PlaySoundLoseSfx(EventParam eventParam)
        {
            PlaySingleEffect(loseSfx);
        }
 
        //Used to play single sound clips.
        private void PlaySingleEffect(AudioClip clip)
        {
            //Play the clip.
            soundEffectsAudio.PlayOneShot(clip, 1f);
        }

        #endregion
    }
}