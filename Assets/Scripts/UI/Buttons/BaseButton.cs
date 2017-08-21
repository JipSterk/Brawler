using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Brawler.UI
{
    public class BaseButton : Button
    {
        public event Action SelectCallback;
        public event Action<AxisEventData> OnMoveCallback;
        public event Action<BaseEventData> OnSelectCallback;
        public event Action<BaseEventData> OnDeselectCallback;
        public event Action<BaseEventData> OnSubmitCallback;
        public event Action<PointerEventData> OnPointerEnterCallback;
        public event Action<PointerEventData> OnPointerExitCallback;
        public event Action<PointerEventData> OnPointerClickCallback;
        public event Action<PointerEventData> OnPointerUpCallback;
        public event Action<PointerEventData> OnPointerDownCallback;

        public override void Select()
        {
            base.Select();

            if (SelectCallback != null)
                SelectCallback();
        }

        public override void OnMove(AxisEventData axisEventData)
        {
            base.OnMove(axisEventData);

            if (OnMoveCallback != null)
                OnMoveCallback(axisEventData);
        }

        public override void OnSelect(BaseEventData baseEventData)
        {
            base.OnSelect(baseEventData);

            if (OnSelectCallback != null)
                OnSelectCallback(baseEventData);
        }

        public override void OnDeselect(BaseEventData baseEventData)
        {
            base.OnDeselect(baseEventData);

            if (OnDeselectCallback != null)
                OnDeselectCallback(baseEventData);
        }

        public override void OnSubmit(BaseEventData baseEventData)
        {
            base.OnSubmit(baseEventData);

            if (OnSubmitCallback != null)
                OnSubmitCallback(baseEventData);
        }

        public override void OnPointerClick(PointerEventData pointerEventData)
        {
            base.OnPointerClick(pointerEventData);

            if(OnPointerClickCallback != null)
                OnPointerClickCallback(pointerEventData);
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);

            if (OnPointerEnterCallback != null)
                OnPointerEnterCallback(eventData);
        }

        public override void OnPointerExit(PointerEventData pointerEventData)
        {
            base.OnPointerExit(pointerEventData);

            if (OnPointerExitCallback != null)
                OnPointerExitCallback(pointerEventData);
        }

        public override void OnPointerUp(PointerEventData pointerEventData)
        {
            if (OnPointerUpCallback != null)
                OnPointerUpCallback(pointerEventData);

            base.OnPointerUp(pointerEventData);
        }

        public override void OnPointerDown(PointerEventData pointerEventData)
        {
            base.OnPointerDown(pointerEventData);

            if (OnPointerDownCallback != null)
                OnPointerDownCallback(pointerEventData);
        }
    }
}