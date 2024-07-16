using System.Collections.Generic;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Scripts.SoundManagement
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField]
        private PooledAudioSource audioSource;

        [SerializeField]
        private AudioSource generalAudio;
        
        [SerializeField]
        private AudioSource bg;
        
        [SerializeField]
        private AudioSource secondBg;

        [SerializeField]
        private AudioClipAndId[] clips;

        
        private readonly Dictionary<string, AudioClipAndId> _idsAndClips = new Dictionary<string, AudioClipAndId>();
        
        private float _initialBgVolume;
        private float _initialSecondBgVolume;
        private float _bgSoundVolumeMultiply;
        private float _globalSoundVolume;
        private bool _isEffectsDisabled;
        private AudioClip _tempClip;

        public static readonly string SAVE_KEY_BG_VOLUME_MULTIPLIER = "BgVolumeMultiplier";
        public static readonly string SAVE_KEY_GLOBAL_VOLUME = "GlobalVolumeMultiplier";
        public static readonly string SAVE_KEY_IS_EFFECTS_DISABLED = "EffectIsDısabled";
        public static readonly string AUDIO_BUTTON_CLICK = "AudioButtonClick";

        private void Awake()
        {
            for (var i = 0; i < clips.Length; i++)
            {
                var currentData = clips[i];
                _idsAndClips[currentData.clipId] = currentData;
            }
            
            _initialBgVolume = bg.volume;
            _initialSecondBgVolume = secondBg.volume;
            
            _bgSoundVolumeMultiply = PlayerPrefs.GetFloat(SAVE_KEY_BG_VOLUME_MULTIPLIER, 1);
            _globalSoundVolume = PlayerPrefs.GetFloat(SAVE_KEY_GLOBAL_VOLUME, 1);
            _isEffectsDisabled = PlayerPrefs.GetInt(SAVE_KEY_IS_EFFECTS_DISABLED, 0) != 0;
            
            SetBgSoundVolume(_bgSoundVolumeMultiply);
        }
        

        public void ControlBg(bool isEnabled)
        {
            if (isEnabled)
            {
                bg.Play();
                secondBg.Play();
            }
            else
            {
                bg.Stop();
                secondBg.Stop();
            }
        }
        public void ControlGlobalVolume(bool isEnabled)
        {
            _isEffectsDisabled = isEnabled;
            PlayerPrefs.SetInt(SAVE_KEY_IS_EFFECTS_DISABLED, _isEffectsDisabled ? 1 : 0);
        }
        public float GetMusicVolume()
        {
            return _bgSoundVolumeMultiply;
        }
        public float GetFxVolume()
        {
            return _globalSoundVolume;
        }
        public void SetGlobalSoundVolume(float volume)
        {
            _globalSoundVolume = volume;
            PlayerPrefs.SetFloat(SAVE_KEY_GLOBAL_VOLUME, _globalSoundVolume);
        }
        public void SetSecondBgSound(string id)
        {
            var clip = ClipData(id);
            secondBg.clip = clip.audioClip;
            secondBg.Play();
        }
        public void ClearBgSound()
        {
            secondBg.Stop();
        }
        public void SetBgSound(string id)
        {
            Addressables.LoadAssetAsync<AudioClip>(id).Completed += handle =>
            {
                bg.clip = handle.Result;
                bg.Play();
            };
        }
        public void PlayAudio(string id)
        {
            if (_isEffectsDisabled)
                return;
            var clip = ClipData(id);

            if (clip.audioClip)
            {
                generalAudio.volume = _globalSoundVolume;
                generalAudio.PlayOneShot(clip.audioClip);
            }
        }
        public void PlayAudioAtPosition(string id, Vector3 targetPos)
        {
            var clip = ClipData(id);

            var source = audioSource.BasePoolItem.PullObjFromPool<PooledAudioSource>(targetPos);
            source.AudioSource.volume = clip.volume;
            source.PlayClip(clip.audioClip);
        }
        public AudioClip ClipWithId(string id)
        {
            if (_idsAndClips.TryGetValue(id, out AudioClipAndId clipAndId)) 
                return clipAndId.audioClip;
        
            DebugHelper.LogRed("THERE IS NO AUDIO WITH ID : " + id);
            return default;
        }

        
        private AudioClipAndId ClipData(string id)
        {
            if (_idsAndClips.TryGetValue(id, out AudioClipAndId clipAndId)) 
                return clipAndId;

            DebugHelper.LogRed("THERE IS NO AUDIO WITH ID : " + id);
            return default;
        }
        private void SetBgSoundVolume(float volume)
        {
            _bgSoundVolumeMultiply = volume;
            PlayerPrefs.SetFloat(SAVE_KEY_BG_VOLUME_MULTIPLIER, _bgSoundVolumeMultiply);

            bg.volume = _bgSoundVolumeMultiply * _initialBgVolume;
            secondBg.volume *= _bgSoundVolumeMultiply * _initialSecondBgVolume;
        }
    }
}