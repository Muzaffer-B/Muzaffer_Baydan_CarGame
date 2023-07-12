using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class RecordTransform : MonoBehaviour
{
    public AnimationClip clip;

    private GameObjectRecorder m_Recorder;

    void Start()
    {
        if (GameManager.instance.IsGameState())
        {
            clip = GameManager.instance.GetAnimation();

        }
        Debug.Log("Clip name"+clip.name);
        PlayerLayer.onObstacleTouched += ResetRecord;
        PlayerLayer.onExitTouched += SaveRecord;

        // Create recorder and record the script GameObject.
        m_Recorder = new GameObjectRecorder(this.gameObject);

        // Bind all the Transforms on the GameObject and all its children.
        m_Recorder.BindComponentsOfType<Transform>(this.gameObject, true);
    }
    private void OnDestroy()
    {
        PlayerLayer.onObstacleTouched -= ResetRecord;
        PlayerLayer.onExitTouched -= SaveRecord;

    }
    void LateUpdate()
    {
        if (clip == null)
            return;

        // Take a snapshot and record all the bindings values for this frame.
        m_Recorder.TakeSnapshot(Time.deltaTime);
    }

    //void OnDisable()
    //{
    //    if (clip == null)
    //        return;

    //    if (m_Recorder.isRecording)
    //    {
    //        // Save the recorded session to the clip.
    //        m_Recorder.SaveToClip(clip);
           
    //    }
    //}

    public void SaveRecord()
    {
        if (clip == null)
            return;

        if (m_Recorder.isRecording)
        {
            // Save the recorded session to the clip.
            m_Recorder.SaveToClip(clip);
            Debug.Log("Clip Recorded");
        }
    }

    public void ResetRecord()
    {
        if (clip == null)
            return;

        m_Recorder.ResetRecording();
        m_Recorder = new GameObjectRecorder(this.gameObject);

        m_Recorder.BindComponentsOfType<Transform>(this.gameObject, true);
    }
}
