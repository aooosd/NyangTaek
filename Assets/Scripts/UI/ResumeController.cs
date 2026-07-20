using System;
using UnityEngine;

public class ResumeController : MonoBehaviour
{
    public ResumeModel resumeModel;
    public ResumeView resumeView;


    private void Awake()
    {
        resumeModel = GetComponent<ResumeModel>();
        resumeView = GetComponent<ResumeView>();
    }
}
