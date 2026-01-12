using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MornLib
{
    [RequireComponent(typeof(Image))]
    public sealed class MornLocalizeImage : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private List<MornLocalizeSpriteSet> _images = new();

        private void Reset()
        {
            _image = GetComponent<Image>();
        }

        private void Awake()
        {
            MornLocalizeCore.OnLanguageChanged.Subscribe(UpdateImage).AddTo(this);
            UpdateImage(MornLocalizeCore.CurrentLanguage);
        }

        private void UpdateImage(string languageKey)
        {
            var setImage = _images.Find(x => x.LanguageKey == languageKey);
            if (setImage.Sprite != null)
            {
                _image.sprite = setImage.Sprite;
            }
        }
    }
}