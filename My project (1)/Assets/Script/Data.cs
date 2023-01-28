using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Zombie Data", menuName = "Scroptable Object/Zombie Data", order = int.MaxValue)]
public class Data : ScriptableObject
{
    [SerializeField]
    private string zombieName;
    public string ZombieName {get {return zombieName;}}
    [SerializeField]
    private int hp;
    public int Hp{ get {return hp;} }
    [SerializeField]
    private int damage;
    public int Damage {get {return damage; } }


}
