using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

static class Utils
{
    static Type s_InternalEditorUtility;
    static Action s_DomainReload;
    static Action s_RepainAllViews;
    
    static Utils()
    {
        var editorAssembly = typeof(EditorGUIUtility).Assembly;
        s_InternalEditorUtility = editorAssembly.GetTypes().First(t => t.Name == "InternalEditorUtility");
        var domainReload = s_InternalEditorUtility.GetMethod("RequestScriptReload", BindingFlags.Public | BindingFlags.Static);
        s_DomainReload = () => domainReload.Invoke(null, new object[0]);

        var repaintAllViews = s_InternalEditorUtility.GetMethod("RequestScriptReload", BindingFlags.Public | BindingFlags.Static);
        s_RepainAllViews = () => repaintAllViews.Invoke(null, new object[0]);
    }

    [MenuItem("Tools/Reload Styles &r", false, 17000)]
    static void ReloadEditorResourcesBundle()
    {
        Debug.Log("Refreshing...");
        EditorApplication.delayCall += () =>
        {
            AssetDatabase.Refresh();
            s_DomainReload();
            s_RepainAllViews();
        };
    }
}
