using System;
using UnityEngine;

public class ResumeModel : MonoBehaviour
{
    public ApplicantData applicantData;
    public int id = 1;
    
    private void Awake()
    {
        GameDatabase gameDatabase = FindAnyObjectByType<GameDatabase>();
        applicantData = gameDatabase.Applicants.ApplicantsDictionary[id];
    }
}
