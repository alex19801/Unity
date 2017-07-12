using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class ScreenListItem
{
	public string name;
	public List<ScreenButton> button_list;

	public ScreenListItem()
	{
		button_list = new List<ScreenButton>();
	}
	public ScreenListItem(string screen_name):this()
	{
		name = screen_name;
	}

}

public class ScreenButton
{
	public string name;
	public ScreenButton()
	{ 
	}

	public ScreenButton(string _name)
	{
		name = _name;
	}
}

public class UI_LogicWindow : EditorWindow
{


	[MenuItem("UserInterface/UI_LogicWindow")]
	static void Init()
	{

		UI_LogicWindow window = (UI_LogicWindow)EditorWindow.GetWindow(typeof(UI_LogicWindow));
		window.Show();
	}



	public static List<ScreenListItem> screen_list = new List<ScreenListItem>();
	ScreenListItem screen;
	void OnGUI()
	{
		if (GUILayout.Button("Сохранить"))
		{

		}

		if(GUILayout.Button("Добавить Экран"))
		{
			screen_list.Add(new ScreenListItem("Экран "+screen_list.Count));
		}

		for (int i = 0; i < screen_list.Count; i++)
		{
			GUILayout.BeginHorizontal();

			if (GUILayout.Button(screen_list[i].name))
			{
			}
			if (GUILayout.Button("Добавить кнопку"))
			{
				screen_list[i].button_list.Add(new ScreenButton("Кнопка"));
			}
			if (GUILayout.Button("X"))
			{
				screen_list.Remove(screen_list[i]);
				continue;
			}
			GUILayout.EndHorizontal();

			for (int j = 0; j < screen_list[i].button_list.Count; j++)
			{
				GUILayout.BeginHorizontal();
				if (GUILayout.Button(screen_list[i].button_list[j].name))
				{

				}
				if (GUILayout.Button("x"))
				{
					screen_list[i].button_list.Remove(screen_list[i].button_list[j]);
				}
				GUILayout.EndHorizontal();
			}
		}

	}
}
