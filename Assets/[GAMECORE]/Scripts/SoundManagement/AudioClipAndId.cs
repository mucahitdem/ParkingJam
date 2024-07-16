using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.SoundManagement
{
    [Serializable]
    public struct AudioClipAndId
    {
        [HorizontalGroup]
        public AudioClip audioClip;

        [HorizontalGroup]
        public string clipId;

        [Range(0, 1)]
        public float volume;
    }
}