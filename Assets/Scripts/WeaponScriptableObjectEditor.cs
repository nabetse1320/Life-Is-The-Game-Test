using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WeaponScriptableObject))]
public class WeaponScriptableObjectEditor : Editor
{
    #region SerializedProperties
    SerializedProperty weaponType;
    SerializedProperty bullet;
    SerializedProperty bulletSpeed;
    SerializedProperty explosionForce;
    SerializedProperty explosionRadius;
    SerializedProperty influenceRangeGravity;
    SerializedProperty intensity;
    SerializedProperty bulletUpSpeed;
    #endregion

    private void OnEnable()
    {
        weaponType = serializedObject.FindProperty("weaponType");
        bullet = serializedObject.FindProperty("bullet");
        bulletSpeed = serializedObject.FindProperty("bulletSpeed");

        explosionForce = serializedObject.FindProperty("explosionForce");
        explosionRadius = serializedObject.FindProperty("explosionRadius");

        influenceRangeGravity = serializedObject.FindProperty("influenceRangeGravity");
        intensity = serializedObject.FindProperty("intensity");

        bulletUpSpeed = serializedObject.FindProperty("bulletUpSpeed");
    }

    public override void OnInspectorGUI()
    {
        WeaponScriptableObject _weapon = (WeaponScriptableObject)target;
        //base.OnInspectorGUI();
        serializedObject.Update();
        EditorGUILayout.PropertyField(bullet);
        EditorGUILayout.PropertyField(bulletSpeed);
        EditorGUILayout.PropertyField(weaponType);
        if (_weapon.weaponType.ToString()== "GravityWeapon") 
        {
            
        }
        switch (_weapon.weaponType.ToString())
        {
            case "GravityWeapon":

                EditorGUILayout.PropertyField(influenceRangeGravity);
                EditorGUILayout.PropertyField(intensity);
                break;

            case "ParabolicWeapon":

                EditorGUILayout.PropertyField(bulletUpSpeed);
                break ;

            case "ExplosionWeapon":

                EditorGUILayout.PropertyField(explosionForce);
                EditorGUILayout.PropertyField(explosionRadius);
                break ;
        }

        serializedObject.ApplyModifiedProperties();

    }
}
