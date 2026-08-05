using System;
using UnityEngine;

/// <summary>이력서 화면이 표시할 지원자 데이터와 선택 인덱스를 보관합니다.</summary>
public class ResumeModel : MonoBehaviour
{
    [HideInInspector] public ApplicantData applicantData; // 현재 화면에 표시할 지원자 데이터입니다.
    public int index = 0;                                 // 지원자 데이터베이스에서 사용할 배열 인덱스입니다.
    
    /// <summary>패널이 활성화될 때 선택 인덱스에 해당하는 지원자 데이터를 가져옵니다.</summary>
    private void OnEnable()
    {
        applicantData = GameDatabase.Instance.Applicants.applicants[index];
        //applicantData.Initialize(3, 3, 3);
    }

}

