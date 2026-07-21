using System.Collections.Generic;
using UnityEngine;

public enum StatType
{
    activity = 0,
    independence,
    closeness
}

[System.Serializable]
public class ApplicantVariable
{
    public int closeness;       // 밀착도
    public int activity;        // 활동성
    public int independence;    // 독립성

    public ApplicantVariable(int _activity, int _independence, int _closeness)
    {
        activity = _activity;
        independence = _independence;
        closeness = _closeness;
    }

    public void Initialize()
    {

    }
}

[System.Serializable]
public class ApplicantData : IData
{
    public int id;
    public string name;
    public string job;
    public int age;             // 나이
    public string feature1;     // 특징
    public string feature2;     // 특징
    public string feature3;     // 특징
    public string reaction_approach;
    public string reaction_approach_ex1;
    public string reaction_approach_ex2;
    public string reaction_stare;
    public string reaction_stare_ex1;
    public string reaction_stare_ex2;
    public string reaction_smell;
    public string reaction_smell_ex1;
    public string reaction_smell_ex2;
    public string reaction_ignore;
    public string reaction_ignore_ex1;
    public string reaction_ignore_ex2;
    public string pros; // 장점
    public string cons; // 단점    
    public string image_url;

    public ApplicantVariable variable;

    public string GetName()
    {
        return name;
    }

    public void Initialize(int _activity, int _independence, int _closeness)
    {
        // TEST
        //variable = new ApplicantVariable(3, 5, 4);
        // TEST

        variable = new ApplicantVariable(_activity, _independence, _closeness);
    }

    /// <summary>
    /// 스탯 타입에 따라 해쉬 태그로 변환해서 문자열 반환
    /// </summary>
    /// <param name="_type">스탯 타입</param>
    /// <returns>해쉬 태그</returns>
    public string ConvertToHashTag(StatType _type)
    {
        string result = string.Empty;

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
public class ApplicantDatabase
{
    public Dictionary<int, ApplicantData> ApplicantsDictionary = new Dictionary<int, ApplicantData>();
}
