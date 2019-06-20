using UnityEngine;
using UnityEngine.Timeline;

[CustomStyle("Annotation")]
public class Annotation : Marker
{
    [TextArea] public string annotation;
}
