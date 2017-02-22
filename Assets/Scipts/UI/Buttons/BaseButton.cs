using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Brawler.UI
{
    public class BaseButton : Button
    {
        public event CallBack SelectCallBack;
        public event CallBack<AxisEventData> OnMoveCallBack;
        public event CallBack<BaseEventData> OnSelectCallBack;
        public event CallBack<BaseEventData> OnDeselectCallBack;
        public event CallBack<BaseEventData> OnSubmitCallback;
        public event CallBack<PointerEventData> OnPointerEnterCallBack;
        public event CallBack<PointerEventData> OnPointerExitCallBack;
        public event CallBack<PointerEventData> OnPointerClickCallBack;
        public event CallBack<PointerEventData> OnPointerUpCallBack;
        public event CallBack<PointerEventData> OnPointerDownCallBack;

        public override void Select()
        {
            base.Select();

            if (SelectCallBack != null)
                SelectCallBack();
        }

        public override void OnMove(AxisEventData axisEventData)
        {
            base.OnMove(axisEventData);

            if (OnMoveCallBack != null)
                OnMoveCallBack(axisEventData);
        }

        public override void OnSelect(BaseEventData baseEventData)
        {
            base.OnSelect(baseEventData);

            if (OnSelectCallBack != null)
                OnSelectCallBack(baseEventData);
        }

        public override void OnDeselect(BaseEventData baseEventData)
        {
            base.OnDeselect(baseEventData);

            if (OnDeselectCallBack != null)
                OnDeselectCallBack(baseEventData);
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

            if(OnPointerClickCallBack != null)
                OnPointerClickCallBack(pointerEventData);
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);

            if (OnPointerEnterCallBack != null)
                OnPointerEnterCallBack(eventData);
        }

        public override void OnPointerExit(PointerEventData pointerEventData)
        {
            base.OnPointerExit(pointerEventData);

            if (OnPointerExitCallBack != null)
                OnPointerExitCallBack(pointerEventData);
        }

        public override void OnPointerUp(PointerEventData pointerEventData)
        {
            if (OnPointerUpCallBack != null)
                OnPointerUpCallBack(pointerEventData);

            base.OnPointerUp(pointerEventData);
        }

        public override void OnPointerDown(PointerEventData pointerEventData)
        {
            base.OnPointerDown(pointerEventData);

            if (OnPointerDownCallBack != null)
                OnPointerDownCallBack(pointerEventData);
        }
    }
}