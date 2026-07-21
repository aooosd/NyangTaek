using System;
using UnityEngine;

public class ResumeModel : MonoBehaviour
{
    [HideInInspector] public ApplicantData applicantData;
    public int id = 1;
    
    private void Start()
    {
        GameDatabase gameDatabase = FindAnyObjectByType<GameDatabase>();
        Debug.Log(gameDatabase.Applicants.applicants[0]);
        applicantData = gameDatabase.Applicants.applicants[0];
    }
}
