using DG.Tweening;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Pool;
using UnityEngine;

namespace Scripts.SoundManagement
{
    public class PooledAudioSource : BaseComponent
    {
        [SerializeField]
        private BasePoolItem basePoolItem;

        public AudioSource AudioSource { get; private set; }

        public BasePoolItem BasePoolItem => basePoolItem;

        public override void OnEnable()
        {
            base.OnEnable();
            AudioSource = GetComponent<AudioSource>();
        }

        
        public void PlayClip(AudioClip audioClip)
        {
            var clipLength = audioClip.length;
            AudioSource.PlayOneShot(audioClip);

            DOVirtual.DelayedCall(clipLength, () =>
            {
                if(basePoolItem)
                    basePoolItem.AddObjToPool(gameObject);
            });
        }
    }
}