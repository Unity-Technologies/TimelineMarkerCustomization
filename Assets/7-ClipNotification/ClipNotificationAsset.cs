using UnityEngine;
using UnityEngine.Playables;

namespace ClipNotification
{
    public class ClipNotificationAsset : PlayableAsset
    {
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<ClipNotificationBehaviour>.Create(graph);
        }
    }
}
