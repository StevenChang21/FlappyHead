using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/VoidEvents", fileName = "NewVoidEvents")]
public class VoidEvent : ScriptableObject
{
    private UnityEvent @event;

    public UnityEvent Event
    {
        get
        {
            if (@event == null)
            {
                return new UnityEvent();
            }
            return @event;
        }
        set => @event = value;
    }
}
