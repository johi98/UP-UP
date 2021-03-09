using UnityEngine;
using UnityEngine.EventSystems;
namespace InterfaceThemeManager
{
    [DisallowMultipleComponent]
    [AddComponentMenu("UI/Sound Style", 1)]
    public class SoundStyle : MonoBehaviour, IPointerDownHandler, IDragHandler
    {
        public Sound sound;
        public void OnPointerDown(PointerEventData data)
        {
            InterfaceManager.Instance.PlayClip(sound);
        }
        public void OnDrag(PointerEventData data)
        {
            if (sound == Sound.Slider)
            {
                InterfaceManager.Instance.PlayClip(sound);
            }
        }
    }
    public enum Sound { Clip, Agree, Cancel, Slider }
}