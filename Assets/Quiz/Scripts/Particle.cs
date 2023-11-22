using UnityEngine;

namespace Quiz
{
    public class Particle : MonoBehaviour
    {
        #region Variables
        [SerializeField] private ParticleSystem particle;
        #endregion

        #region Builtin Methods
        private void Start()
        {
            EventManager.StartListening("PlayParticle", PlayParticle);
        }

        private void OnDestroy()
        {
            EventManager.StopListening("PlayParticle", PlayParticle);
        }
        #endregion

        #region Custom Methods
        public void PlayParticle(EventParam eventParam)
        {

            var ps = particle.GetComponent<ParticleSystem>();
            if (ps.isPlaying)
            {
                ps.Stop();
                ps.Play(true);
            } else
            {
               ps.Play(true);
            }
           
        }
        #endregion

    }
}
