using UnityEngine;

/// <summary>아이템 한 개의 기본 정보를 저장합니다.</summary>
public class ItemData : IData
{
    public int id;          // 아이템을 구분하는 고유 ID입니다.
    public string name;     // 화면에 표시할 아이템 이름입니다.

    /// <summary>목록 UI 등에 표시할 아이템 이름을 반환합니다.</summary>
    public string GetName()
    {
        return name;
    }
}

[System.Serializable]
/// <summary>JSON에서 불러온 아이템 데이터 배열을 보관합니다.</summary>
public class ItemDatabase
{
<<<<<<< Updated upstream
    public ItemData[] items; // 게임에 등록된 모든 아이템 데이터입니다.
}
=======
    public ItemData[] items;
}

>>>>>>> Stashed changes
