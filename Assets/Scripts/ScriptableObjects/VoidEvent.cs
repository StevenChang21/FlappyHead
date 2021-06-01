using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/VoidEvents", fileName = "NewVoidEvents")]
public class VoidEvent : ScriptableObject
{
    public UnityEvent Event { get; set; }
}
