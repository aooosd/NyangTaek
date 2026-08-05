using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>포인터 입력으로 메모 슬라이드 바를 정해진 단계 단위로 이동시킵니다.</summary>
public class MemoSlideBar : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    RectTransform boxRect;  // 슬라이더가 움직일 수 있는 전체 영역입니다.
    RectTransform slideBar; // 사용자가 직접 움직이는 막대입니다.

    private bool isDragging; // 현재 포인터로 막대를 드래그하고 있는지 나타냅니다.

    /// <summary>RectTransform 참조를 찾고 드래그 상태를 초기화합니다.</summary>
    void Start()
    {
        isDragging = false;
        boxRect = GetComponent<RectTransform>();
        slideBar = transform.GetChild(0).GetComponent<RectTransform>();
    }

    /// <summary>포인터를 누르면 드래그를 시작하고 막대를 즉시 이동합니다.</summary>
    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        MoveBar(eventData);
    }

    /// <summary>드래그 중인 포인터 위치에 맞추어 막대를 이동합니다.</summary>
    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
            MoveBar(eventData);
    }

    /// <summary>포인터를 놓으면 드래그 상태를 종료합니다.</summary>
    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }

    /// <summary>화면 좌표를 로컬 좌표로 변환하고 범위와 단계에 맞게 막대 위치를 보정합니다.</summary>
    private void MoveBar(PointerEventData eventData)
    {
        Vector2 localPoint; // 포인터의 RectTransform 기준 로컬 좌표입니다.

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            boxRect,
            eventData.position,
            eventData.pressEventCamera,
            out localPoint
        );

        float halfBarWidth = slideBar.rect.width * 0.5f; // 막대가 영역 밖으로 나가지 않게 고려할 반쪽 너비입니다.

        float minX = -boxRect.rect.width * 0.5f + halfBarWidth; // 이동 가능한 최소 X 좌표입니다.
        float maxX = boxRect.rect.width * 0.5f - halfBarWidth;  // 이동 가능한 최대 X 좌표입니다.

        float x = Mathf.Clamp(localPoint.x, minX, maxX); // 영역 안으로 제한한 최종 후보 X 좌표입니다.
        /*x = (int)(x + 300) / (int)(boxRect.rect.width * 0.2f);
        x = x * (boxRect.rect.width * 0.2f) - (boxRect.rect.width * 0.4f);*/
        //x = x - x % (boxRect.rect.width * 0.2f);
        x = Mathf.Round(x / (boxRect.rect.width * 0.2f)) * (boxRect.rect.width * 0.2f);


        slideBar.anchoredPosition = new Vector2(
            x,
            slideBar.anchoredPosition.y
        );
    }
}

