using System.ComponentModel;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[DisplayName("Jump/JumpMarker")]
[CustomStyle("JumpMarker")]
public class JumpMarker : Marker, INotification, INotificationOptionProvider
{
    [SerializeField] public DestinationMarker destinationMarker;
    [SerializeField] public bool emitOnce;
    [SerializeField] public bool emitInEditor;

    public PropertyName id { get; }
        
    NotificationFlags INotificationOptionProvider.flags =>
        (emitOnce ? NotificationFlags.TriggerOnce : default) |
        (emitInEditor ? NotificationFlags.TriggerInEditMode : default); 
}
