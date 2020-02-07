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
public enum Organ { NONE, HEART, BRAIN, LIVER, VEINS, SKULL, RIGHT_LUNG, KIDNEY }
public enum Prefab { HEART_HEALTHY, HEART_DISEASED, SKULL, BRAIN_VARIANT, RIGHTLUNG_HEALTHY, LIVER_HEALTHY, KIDNEY_HEALTHY }
public enum Bundle { HEART, HEART_DISEASED, SKULL, BRAIN, RIGHT_LUNG, KIDNEY, LIVER }

public static class OrganDataUtils
{
    public static string Name(this BodySystem system)
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
            default: return "";
        }
    }

    public static string Name(this Prefab prefab)
    {
        switch (prefab)
        {
            case Prefab.HEART_HEALTHY: return "Heart_Healthy";
            case Prefab.HEART_DISEASED: return "Heart_Diseased";
            case Prefab.SKULL: return "Skull";
            case Prefab.BRAIN_VARIANT: return "Brain_Variant";
            default: return "";
        }
    }
}
