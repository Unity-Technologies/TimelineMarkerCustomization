using System;
using UnityEngine;
using UnityEngine.Playables;

public class ManualNotification : MonoBehaviour
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

        //Push a notification on the output
        output.PushNotification(Playable.Null, new MyNotification());
        
        m_Graph.Play();
    }

    void OnDestroy()
    {
        m_Graph.Destroy();
    }
}