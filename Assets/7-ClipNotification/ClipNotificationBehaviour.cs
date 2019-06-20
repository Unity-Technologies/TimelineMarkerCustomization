using UnityEngine.Playables;

namespace ClipNotification
{
    public class ClipNotificationBehaviour : PlayableBehaviour
    {
        double m_PreviousTime;

        public override void OnGraphStart(Playable playable)
        {
            m_PreviousTime = 0;
        }
        
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            if ((int)m_PreviousTime < (int)playable.GetTime())
            {
                info.output.PushNotification(playable, new MyNotification());
            }

            m_PreviousTime = playable.GetTime();
        }
    }
}
