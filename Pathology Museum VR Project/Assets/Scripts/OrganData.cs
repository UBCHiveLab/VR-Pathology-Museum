using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Organ", menuName = "Museum/Organ", order = 1)]
public class OrganData : ScriptableObject
{
    public BodySystem system; 
    public Organ organ;
    public string disease;
    public Prefab model;
    public Bundle bundlePath;
    [TextArea] public string info;
}

public enum BodySystem { NONE, CARDIOVASCULAR, NERVOUS, GASTROINTESTINAL, RESPIRATORY, MALE_REPRODUCTIVE, FEMALE_REPRODUCTIVE, SKELETAL }
public enum Organ { NONE, HEART, BRAIN, LIVER, VEINS, SKULL, KIDNEY, RIGHT_LUNG }
public enum Prefab { HEART_HEALTHY, HEART_DISEASED, SKULL_HEALTHY, BRAIN_HEALTHY, KIDNEY, RIGHT_LUNG, LIVER }
public enum Bundle { HEART, HEART_DISEASED, SKULL, BRAIN, KIDNEY, RIGHT_LUNG, LIVER }

public static class OrganDataUtils
{
    public static string Name (this BodySystem system)
    {
        switch (system)
        {
            case BodySystem.CARDIOVASCULAR: return "Cardio-vascular";
            case BodySystem.NERVOUS: return "Nervous";
            case BodySystem.GASTROINTESTINAL: return "Gastro-intestinal";
            case BodySystem.RESPIRATORY: return "Respiratory";
            case BodySystem.MALE_REPRODUCTIVE: return "Male Reproductive";
            case BodySystem.FEMALE_REPRODUCTIVE: return "Female Reproductive";
            case BodySystem.SKELETAL: return "Skeletal";
            default: return "";
        }
    }

    public static string Name(this Organ organ)
    {
        switch (organ)
        {
            case Organ.HEART: return "Heart";
            case Organ.BRAIN: return "Brain";
            case Organ.SKULL: return "Skull";
            case Organ.KIDNEY: return "Kidney";
            case Organ.LIVER: return "Liver";
            case Organ.RIGHT_LUNG: return "Right Lung";
            default: return "";
        }
    }

    public static string Name(this Bundle bundle)
    {
        switch (bundle)
        {
            case Bundle.HEART: return "heart";
            case Bundle.HEART_DISEASED: return "heart_diseased";
            case Bundle.SKULL: return "skull";
            case Bundle.BRAIN: return "brain";
            case Bundle.RIGHT_LUNG: return "right_lung";
            case Bundle.KIDNEY: return "kidney";
            case Bundle.LIVER: return "liver";
            default: return "";
        }
    }

    public static string Name(this Prefab prefab)
    {
        switch (prefab)
        {
            case Prefab.HEART_HEALTHY: return "Heart_Healthy";
            case Prefab.HEART_DISEASED: return "Heart_Diseased";
            case Prefab.SKULL_HEALTHY: return "Skull_Healthy";
            case Prefab.BRAIN_HEALTHY: return "Brain_Healthy";
            case Prefab.LIVER: return "Liver_Healthy";
            case Prefab.KIDNEY: return "Kidney_Healthy";
            case Prefab.RIGHT_LUNG: return "RightLung_Healthy";
            default: return "";
        }
    }
}
