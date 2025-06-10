using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr  //��׼����
{
   
    
    private AudioMgr() { }

    private static AudioMgr _instance = null;

    public static AudioMgr Instance()
    {
        if (AudioMgr._instance == null)
        {
            AudioMgr._instance = new AudioMgr();
            AudioMgr._instance.init();
        }
        return AudioMgr._instance;
    }

    private AudioSource bgmAus = null;//ר���������ű�������
    private float bgmVolume = 1;//������������ , 0~1  ���������1
    private float soundVolume = 1;//��Ч���� , 0~1  ���������1

    private string bgmKey = "GameMusic";
    private string soundKey = "GameSound";

    //�ֵ�:���ֻ���
    private Dictionary<string, AudioClip> clipsBuffer = null;
    private AudioClip getClip(string name)
    {
        if (clipsBuffer.TryGetValue(name, out var clip))
        {
            return clip;
        }
        return null;
    }
    private void init()
    {
        bgmVolume = PlayerPrefs.GetFloat(bgmKey, 1);
        soundVolume = PlayerPrefs.GetFloat(soundKey, 1);

        clipsBuffer = new Dictionary<string, AudioClip>();
        //����������Դ
        AudioClip[] _clips = Resources.LoadAll<AudioClip>("Audio");
        foreach (var item in _clips)
        {
            clipsBuffer.Add(item.name, item);
        }
    }

    public void PlayBGM(string bgmName, GameObject go)
    {

        bgmAus = go.GetComponent<AudioSource>();
        if (bgmAus != null)
        {
            bgmAus.Stop();
        }
        else
        {
            bgmAus = go.AddComponent<AudioSource>();
        }

        bgmAus.clip = getClip(bgmName);
        bgmAus.loop = true;
        bgmAus.volume = bgmVolume;
        bgmAus.Play();
    }

    public void PlaySound(string soundName, GameObject go)
    {
        AudioSource aus = go.GetComponent<AudioSource>();
        if (aus == null)
        {
            aus = go.AddComponent<AudioSource>();
        }

        aus.Stop();
        aus.clip = getClip(soundName);
        aus.loop = false;
        aus.volume = soundVolume;
        aus.Play();
    }

    public float get_BGM_Volume()
    {
        bgmVolume = PlayerPrefs.GetFloat(bgmKey,1);
        return bgmVolume;
    }

    public void set_BGM_Volume(float _volume)
    {
        this.bgmVolume = _volume;
        if (bgmAus != null)
        {
            bgmAus.volume = this.bgmVolume;
        }
        PlayerPrefs.SetFloat(bgmKey, bgmVolume);
    }

    public float get_Sound_Volume()
    {
        soundVolume = PlayerPrefs.GetFloat(soundKey,1);
        return soundVolume;
    }
    public void set_Sound_Volume(float _volume)
    {
        this.soundVolume = _volume;
        PlayerPrefs.SetFloat(soundKey, soundVolume);
    }
}
