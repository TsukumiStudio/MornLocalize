using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace MornLib
{
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class MornLocalizeSprite : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private List<MornLocalizeSpriteSet> _images = new();

        private void Reset()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        private void Awake()
        {
            MornLocalizeCore.OnLanguageChanged.Subscribe(UpdateSprite).AddTo(this);
            UpdateSprite(MornLocalizeCore.CurrentLanguage);
        }

        private void UpdateSprite(string languageKey)
        {
            var setImage = _images.Find(x => x.LanguageKey == languageKey);
            if (setImage.Sprite != null)
            {
                _renderer.sprite = setImage.Sprite;
            }
        }
    }
}