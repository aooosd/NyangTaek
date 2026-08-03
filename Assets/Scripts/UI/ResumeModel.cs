using System;
using UnityEngine;

public class ResumeModel : MonoBehaviour
{
    [HideInInspector] public ApplicantData applicantData;
    public int index = 0;
    
    private void OnEnable()
    {
        applicantData = GameDatabase.Instance.Applicants.applicants[index];
        //applicantData.Initialize(3, 3, 3);
    }
}
