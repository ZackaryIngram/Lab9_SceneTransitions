using UnityEngine;
using UnityEditor;

public class MyUnityEditorScript : EditorWindow
{
    Color color;

    //Nme inside the window drop down menu
    [MenuItem("Window/Colour_Changer")]
    public static void ShowWindow()
    {
       GetWindow<MyUnityEditorScript>("Colour Changer");
    }
    private void OnGUI()
    {
        //A label that tells developer what to do
        GUILayout.Label("Colour selected objects", EditorStyles.boldLabel);

        //Setup color variable to = a color field color
         color = EditorGUILayout.ColorField("Colour", color);

        if(GUILayout.Button("Change Colour"))
        {
          ChangeColour();
        }       

    }

    void ChangeColour()
    {
        //For each game object selected change the colour
        foreach (GameObject obj in Selection.gameObjects)
        {
            //object must have a renderer component
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.sharedMaterial.color = color;
            }
        }
    }
}
