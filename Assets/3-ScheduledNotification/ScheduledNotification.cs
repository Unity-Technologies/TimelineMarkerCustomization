using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class ScheduledNotification : MonoBehaviour
{
    PlayableGraph m_Graph;
    ReceiverExample m_Receiver;

    void Start()
    {
        m_Graph = PlayableGraph.Create("NotificationGraph");
        var output = ScriptPlayableOutput.Create(m_Graph, "NotificationOutput");
        
        //Create and register a receiver
        m_Receiver = new ReceiverExample();
        output.AddNotificationReceiver(m_Receiver);

        //Create a TimeNotificationBehaviour
        var timeNotificationPlayable = ScriptPlayable<TimeNotificationBehaviour>.Create(m_Graph);
        output.SetSourcePlayable(timeNotificationPlayable);
        
        //Add a notification on the time notification behaviour
        var notificationBehaviour = timeNotificationPlayable.GetBehaviour();
        notificationBehaviour.AddNotification(2.0, new MyNotification());
        
        m_Graph.Play();
    }

    void OnDestroy()
    {
        m_Graph.Destroy();
    }
}