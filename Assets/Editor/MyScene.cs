using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using System.IO;

public class MyScene : EditorWindow
{
    Vector2 scrollPosition = Vector2.zero;
    // Add menu item named "My Window" to the Window menu
    [MenuItem("SSB/My Scenes")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(MyScene));
    }

    void OnGUI()
    {
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, true, true, GUILayout.MinWidth(100), GUILayout.MaxWidth(1000), GUILayout.ExpandWidth(true), GUILayout.MinHeight(100), GUILayout.MaxHeight(1000), GUILayout.ExpandHeight(true));
        //GUILayout.BeginArea(new Rect(0, 0, 300, 300));    //Does not display correctly if this is not commented out!



        GUILayout.Label("Game Saves");
        if (GUILayout.Button("Clear Prefs"))
        {
            PlayerPrefs.DeleteAll();
        }

        if (GUILayout.Button("Reset Save Data"))
        {
            if (File.Exists(GetSavePath()))
            {
                File.Delete(GetSavePath());
            }
        }

        GUILayout.Label("Scenes");

        int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        string[] scenes = new string[sceneCount];

        for (int i = 0; i < sceneCount; i++)
        {
            scenes[i] = System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i));
            string path = System.IO.Path.GetFullPath(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i));

            if (GUILayout.Button(scenes[i].ToString()))
            {
                EditorSceneManager.SaveOpenScenes();
                EditorSceneManager.OpenScene(path);
            }
        }

        //if (GUILayout.Button("Fix Anchors"))
        //{
        //    uGUITools.AnchorsToCorners();
        //}
        //GUILayout.EndArea();
        GUILayout.EndScrollView();
    }

    private static string GetSavePath()
    {
        return Path.Combine(Application.persistentDataPath, "SavedGame.json");
    }


}