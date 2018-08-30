using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CharacterType")]
public class CharacterType : ScriptableObject
{
    [SerializeField] private GeneralData generalData;
    [SerializeField] private MovementData movementData;
    [SerializeField] private HealthData healthData;
    [SerializeField] private HabilitiesData skillData;

    public GeneralData GeneralData
    {
        get
        {
            return generalData;
        }
    }
    public MovementData MovementData
    {
        get
        {
            return movementData;
        }
    }
    public HealthData HealthData
    {
        get
        {
            return healthData;
        }
    }
    public HabilitiesData SkillData
    {
        get
        {
            return skillData;
        }
    }
}
