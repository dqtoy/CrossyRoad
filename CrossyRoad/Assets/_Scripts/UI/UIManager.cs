﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

	// Use this for initialization
	public GameObject PanelParent, btNoSadow, btblockRotation;
	// For Bt More
	public GameObject btPet, btMap, btXhang;
	// Sprite
	public GameObject[] PanelUnActive, PanelActive;

	public Sprite imageBt;
	private Sprite currentImageBt;
	private Image image;
	private bool ON = true;
	private GameObject DirectionalLight;


	private void Start()
	{
		image = GetComponent<Image>();
		if (image != null)
			currentImageBt = image.sprite;

		
	}

	public void setMute()
	{
		if (ON)
			AudioListener.volume = 0;
		else
			AudioListener.volume = 1;
		
	}
	public void setQuality()
	{
		if (ON)
			QualitySettings.SetQualityLevel(1);
		else
			QualitySettings.SetQualityLevel(5);
	}
	public void setMore()
	{
		if (ON)
		{
			btPet.SetActive(false);
			btXhang.SetActive(false);
			btMap.SetActive(false);
		}
		else
		{
			btPet.SetActive(true);
			btXhang.SetActive(true);
			btMap.SetActive(true);
		}

	}
	public void setBack()
	{
		PanelParent.SetActive(false);
	}
	public void setActivePanel()
	{
		foreach(GameObject ob in PanelActive)
		{
			ob.SetActive(true);
		}
		foreach(GameObject ob in PanelUnActive)
		{
			ob.SetActive(false);
		}
	}
	public void turnOffShadow()
	{
		DirectionalLight = GameObject.Find("Directional Light");
		Light light = DirectionalLight.GetComponent<Light>();
		if (light != null)
		{
			if (ON)
			{
				light.shadows = LightShadows.None;
				return;
			}
			light.shadows = LightShadows.Soft;

		}
	}
	public void LockRotation()
	{
		if (ON)
		{
			Screen.orientation = ScreenOrientation.LandscapeLeft;
		}
		else
			Screen.orientation = ScreenOrientation.AutoRotation;
	}
	public void ChangeSpriteWhenPress()
	{
		if (ON)
		{
			image.sprite = imageBt;
			ON = false;
			return;
		}	
		image.sprite = currentImageBt;
		ON = true;
		

	}
}
