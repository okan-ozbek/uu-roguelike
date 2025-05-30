using System.Collections;
using UnityEngine;

namespace Entities.Handlers
{
    public class ColorHandler : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private Coroutine _colorFadeCoroutine;

        private void Awake()
        {
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            
            if (_spriteRenderer == null)
            {
                throw new MissingComponentException("SpriteRenderer component is required on ColorHandler.");
            }
        }
        
        public void SetColor(Color color, float duration)
        {
            if (_colorFadeCoroutine != null)
            {
                StopCoroutine(_colorFadeCoroutine);
            }

            _spriteRenderer.color = color;

            if (duration > 0)
            {
                _colorFadeCoroutine = StartCoroutine(ColorFade(Color.white, duration));
            }
        }
        
        private IEnumerator ColorFade(Color color, float duration)
        {
            Color startColor = _spriteRenderer.color;
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                _spriteRenderer.color = Color.Lerp(startColor, color, elapsedTime / duration);
                yield return null;
            }

            _spriteRenderer.color = color;
            _colorFadeCoroutine = null;
        }
    }
}