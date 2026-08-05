using UnityEngine;

[System.Serializable]
/// <summary>가구 한 개의 기본 정보를 저장합니다.</summary>
public class FurnitureData : IData
{
    public int id;          // 가구를 구분하는 고유 ID입니다.
    public string name;     // 화면에 표시할 가구 이름입니다.

    /// <summary>목록 UI 등에 표시할 가구 이름을 반환합니다.</summary>
    public string GetName()
    {
        return name;
    }
}