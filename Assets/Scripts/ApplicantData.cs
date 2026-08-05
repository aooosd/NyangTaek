using System.Collections.Generic;
using UnityEngine;

/// <summary>지원자 성향을 구성하는 스탯 종류를 정의합니다.</summary>
public enum StatType
{
    activity = 0,
    independence,
    closeness
}

/// <summary>지원자 성향을 표현하는 해시태그 종류를 정의합니다.</summary>
public enum TagName
{
    Independent = 0,  // 독립적
    Dependent,        // 의존적

    Introvert, // 내향적
    Active,    // 활동적

    Affection, // 애정파
    Individual // 개인파
}

/// <summary>해시태그의 종류, 표시 색상, 출력 문자열을 묶어 저장합니다.</summary>
public class HashTag
{
    public TagName tagName;    // 해시태그의 논리적인 종류입니다.
    public Color textColor;    // UI에 표시할 글자 색상입니다.
    public string text;        // UI에 실제로 출력할 문자열입니다.
}

[System.Serializable]
/// <summary>게임 진행 중 사용할 지원자의 성향 스탯과 해시태그를 보관합니다.</summary>
public class ApplicantVariable
{
    public HashTag hashTag;     // 현재 성향을 설명하는 해시태그 정보입니다.

    public int closeness;       // 밀착도
    public int activity;        // 활동성
    public int independence;    // 독립성

    /// <summary>지원자의 활동성, 독립성, 밀착도 스탯을 초기화합니다.</summary>
    public ApplicantVariable(int _activity, int _independence, int _closeness)
    {
        activity = _activity;
        independence = _independence;
        closeness = _closeness;
    }

    /// <summary>추가 런타임 초기화가 필요할 때 사용할 확장 지점입니다.</summary>
    public void Initialize()
    {

    }
}

[System.Serializable]
/// <summary>집사 지원자 한 명의 인적 정보, 성향, 면접 반응을 저장합니다.</summary>
public class ApplicantData : IData
{
    public int id;              // 지원자를 구분하는 고유 ID입니다.
    public string name;         // 지원자의 이름입니다.
    public string job;          // 지원자의 직업입니다.
    public int age;             // 나이

    public string feature1;     // 특징
    public string feature2;     // 특징
    public string feature3;     // 특징

    public string reaction_approach;     // 고양이가 다가갈 때의 기본 반응입니다.
    public string reaction_approach_ex1; // 다가가기 추가 행동 1에 대한 반응입니다.
    public string reaction_approach_ex2; // 다가가기 추가 행동 2에 대한 반응입니다.
    public string reaction_stare;        // 고양이가 노려볼 때의 기본 반응입니다.
    public string reaction_stare_ex1;    // 노려보기 추가 행동 1에 대한 반응입니다.
    public string reaction_stare_ex2;    // 노려보기 추가 행동 2에 대한 반응입니다.
    public string reaction_smell;        // 고양이가 냄새를 맡을 때의 기본 반응입니다.
    public string reaction_smell_ex1;    // 냄새 맡기 추가 행동 1에 대한 반응입니다.
    public string reaction_smell_ex2;    // 냄새 맡기 추가 행동 2에 대한 반응입니다.
    public string reaction_threat;       // 고양이가 위협할 때의 기본 반응입니다.
    public string reaction_threat_ex1;   // 위협하기 추가 행동 1에 대한 반응입니다.
    public string reaction_threat_ex2;   // 위협하기 추가 행동 2에 대한 반응입니다.

    public string pros; // 장점
    public string cons; // 단점

    public int closeness;       // 밀착도
    public int activity;        // 활동성
    public int independence;    // 독립성

    public string image_url;    // 지원자 이미지 리소스의 경로 또는 파일 이름입니다.

    public ApplicantVariable variable; // 게임 진행 중 사용하는 지원자의 가변 성향 정보입니다.

    /// <summary>목록 UI 등에 표시할 지원자 이름을 반환합니다.</summary>
    public string GetName()
    {
        return name;
    }

    /// <summary>지원자의 런타임 성향 스탯을 전달받은 값으로 생성합니다.</summary>
    public void Initialize(int _activity, int _independence, int _closeness)
    {
        variable = new ApplicantVariable(_activity, _independence, _closeness);
    }

    /// <summary>
    /// 스탯 타입에 따라 해쉬 태그로 변환해서 문자열 반환
    /// </summary>
    /// <param name="_type">스탯 타입</param>
    /// <returns>해쉬 태그</returns>
    public string ConvertToHashTag(StatType _type)
    {
        string result = string.Empty; // 변환 결과를 위한 예비 변수입니다.

        switch (_type)
        {
            case StatType.activity:
                {
                    // 활동성
                    if (variable.activity > 0 && variable.activity < 4)   // 내향적
                    {
                        return "내향적";
                    }
                    else if (variable.activity > 3 && variable.activity < 6)  // 활동적
                    {
                        return "활동적";
                    }
                    else
                    {
                        Debug.LogError("activity = " + variable.activity.ToString());
                    }
                }
                break;

            case StatType.independence:
                {
                    // 독립성
                    if (variable.independence > 0 && variable.independence < 4)
                    {
                        return "의존적";
                    }
                    else if (variable.independence > 3 && variable.independence < 6)
                    {
                        return "독립적";
                    }
                    else
                    {
                        Debug.LogError("activity = " + variable.independence.ToString());
                    }
                }
                break;

            case StatType.closeness:
                {
                    // 밀착도
                    if (variable.closeness > 0 && variable.closeness < 4)
                    {
                        return "개인파";
                    }
                    else if (variable.closeness > 3 && variable.closeness < 6)
                    {
                        return "애정파";
                    }
                    else
                    {
                        Debug.LogError("closeness = " + variable.closeness.ToString());
                    }
                }
                break;
            default:                
                break;
        }

        return null;       
    }
}

[System.Serializable]
/// <summary>JSON에서 불러온 전체 지원자 목록을 보관합니다.</summary>
public class ApplicantDatabase
{
    public List<ApplicantData> applicants = new List<ApplicantData>(); // 게임에 등록된 지원자 데이터입니다.
}

