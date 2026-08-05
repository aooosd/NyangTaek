using UnityEngine;

/// <summary>Resources 폴더의 JSON 파일을 지정한 데이터 형식으로 변환합니다.</summary>
public static class JsonLoader
{
    /// <summary>Resources 경로의 JSON TextAsset을 읽어 T 형식으로 역직렬화합니다.</summary>
    /// <param name="path">확장자를 제외한 Resources 내부 경로입니다.</param>
    /// <returns>변환된 데이터이며, 파일을 찾지 못하면 T의 기본값입니다.</returns>
    public static T LoadData<T>(string path)
    {
        TextAsset json = Resources.Load<TextAsset>(path); // 원본 JSON 문자열을 담은 Unity 에셋입니다.

        if (json == null)
        {
            Debug.LogError($"Failed to load {path}");
            return default;
        }

        return JsonUtility.FromJson<T>(json.text);
    }
}
