using UnityEngine;
using UnityEngine.EventSystems;

namespace Buttons
{
    public class ButtonInfo : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        public bool isPressed { get; set; }


        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            isPressed = true;
        }

        void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
        {
            isPressed = false;
        }
    }
}