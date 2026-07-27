using System;
using UnityEngine;

public class ResumeModel : MonoBehaviour
{
    [HideInInspector] public ApplicantData applicantData;
    public int id = 1;
    
    private void Start()
    {
        Debug.Log(GameDatabase.Instance.Applicants.applicants[0]);
        applicantData = GameDatabase.Instance.Applicants.applicants[0];
        applicantData.Initialize(3, 3, 3);
    }
}
