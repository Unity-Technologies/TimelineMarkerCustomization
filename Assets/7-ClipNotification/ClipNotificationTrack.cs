using UnityEngine.Timeline;

namespace ClipNotification
{
    [TrackBindingType(typeof(NotificationReceiver))]
    [TrackClipType(typeof(ClipNotificationAsset))]
    public class ClipNotificationTrack : TrackAsset { }
}
