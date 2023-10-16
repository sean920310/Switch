using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewEntityData",menuName = "Entity/Create Entity Data")]
public class EntityData : ScriptableObject
{
    public float Heath;
    public float Regenerate;
    public float Attack;
    public float Defence;
    public float Speed;
}
