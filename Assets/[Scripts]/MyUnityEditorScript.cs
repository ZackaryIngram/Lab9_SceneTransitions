using UnityEngine;
using UnityEditor;

public class MyUnityEditorScript : EditorWindow
{
    Color colour;

    //Nmae inside the window drop down menu
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
         colour = EditorGUILayout.ColorField("Colour", colour);

        if(GUILayout.Button("Change Colour"))
        {
          ChangeColour();
        }       

    }

    void ChangeColour()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.sharedMaterial.color = colour;
            }
        }
    }
}
