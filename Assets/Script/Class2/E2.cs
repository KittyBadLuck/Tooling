using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class E2 : MonoBehaviour
{
    public string NickName;
    public float Height;
    public string FirstName;
    public string LastName;
    public string Bio;

}

[CustomEditor(typeof(E2))]
public class E2Editor : Editor
{
    private bool _showNickcame;
    public override void OnInspectorGUI()
    {
        var e2 = (E2)target;
        
        GUILayout.BeginHorizontal();
         GUILayout.BeginVertical();
          GUILayout.Label("Prénom");
          e2.FirstName = GUILayout.TextField(e2.FirstName);
         GUILayout.EndVertical();

         GUILayout.BeginVertical();
          GUILayout.Label("Nom de Famille");
          e2.LastName = GUILayout.TextField(e2.LastName);
         GUILayout.EndVertical();

        GUILayout.EndHorizontal();


        if(!_showNickcame)
        {
          
          e2.NickName = EditorGUILayout.PasswordField("Surnom", e2.NickName);

        }
        else
        {
            e2.NickName = EditorGUILayout.TextField("Surnom", e2.NickName);
        }

        GUILayout.BeginHorizontal();
         GUILayout.FlexibleSpace();
         _showNickcame = GUILayout.Toggle(_showNickcame, "Montrer le surnom");
        GUILayout.EndHorizontal();

        GUILayout.Space(12);


        EditorGUILayout.LabelField("Biographie");
        e2.Bio = EditorGUILayout.TextArea(e2.Bio);

        EditorGUILayout.LabelField(new GUIContent("Hauteur", "mesuré en cm"));
        e2.Height = EditorGUILayout.Slider(e2.Height, 150, 200);

        





       
       

       
		//your code goes here
	}
}
