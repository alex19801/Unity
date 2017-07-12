using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace My2d
{
	public class MyScript : MonoBehaviour
	{
		public int window = 10;
    
		//private Room rooms;
		private DateTime now = DateTime.Now.Date;
		//int room = 0;
		int height = 30;
		int widthDay = 30;
		private int period = 20;
		// days +-5
		private List<Rent> rentList;

		private static Room room1 = new Room { Id = 0, Name = "Двор1", Places = 3, Desc = "" };
		private static Room room2 = new Room { Id = 1, Name = "Двор2", Places = 2, Desc = "" };
		private static Room room3 = new Room { Id = 2, Name = "Двор3", Places = 4, Desc = "" };
		private static List<Room> roomList = new List<Room> () { room1, room2, room3 };

		void Awake ()
		{
			Guest guest1 = new Guest {
				Id = 0,
				Name = "Ларины",
				Peoples = 3,
				Phone = "0512111111",
				Childrens = 1,
				Animals = 0,
				Desc = ""
			};
			Guest guest2 = new Guest {
				Id = 1,
				Name = "Mama",
				Peoples = 3,
				Phone = "051212222221",
				Childrens = 0,
				Animals = 0,
				Desc = ""
			};
			Guest guest3 = new Guest {
				Id = 2,
				Name = "Света",
				Peoples = 3,
				Phone = "051213333331",
				Childrens = 2,
				Animals = 1,
				Desc = ""
			};
			rentList = new List<Rent> {
				new Rent { Room = room1, Guest = guest1, Start = now.AddDays (0), End = now.AddDays (2) },
				new Rent { Room = room1, Guest = guest1, Start = now.AddDays (3), Duration = 2 },
				new Rent { Room = room2, Guest = guest2, Start = now.AddDays (0), End = now.AddDays (0) },
				new Rent { Room = room2, Guest = guest3, Start = now.AddDays (1), End = now.AddDays (3) },
			};
		}

		private void Update ()
		{
			// var btn1 = GetComponents
		}

		void OnGUI ()
		{

			//GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200));
			GUI.BeginGroup (new Rect (0, 0, Screen.width, Screen.height));
        
			if (window == 1) {
				if (GUI.Button (new Rect (10, 30, 180, 30), "Играть")) {
					window = 2;
				}
				if (GUI.Button (new Rect (10, 70, 180, 30), "Настройки")) {
					window = 3;
				}
				if (GUI.Button (new Rect (10, 110, 180, 30), "Об Игре")) {
					window = 4;
				}
				if (GUI.Button (new Rect (10, 150, 180, 30), "Test")) {
					window = (int)layer.main;
				}
				if (GUI.Button (new Rect (10, 190, 180, 30), "Выход")) {
					window = 5;
				}
			}

			if (window == 2) {
				GUI.Label (new Rect (50, 10, 180, 30), "Выберите уровень");
				if (GUI.Button (new Rect (10, 40, 180, 30), "Уровень 1")) {
					Debug.Log ("Уровень 1 загружен");
					Application.LoadLevel (1);
				}
				if (GUI.Button (new Rect (10, 80, 180, 30), "Уровень 2")) {
					Debug.Log ("Уровень 2 загружен");
					Application.LoadLevel (2);
				}
				if (GUI.Button (new Rect (10, 120, 180, 30), "Уровень 3")) {
					Debug.Log ("Уровень 3 загружен");
					Application.LoadLevel (3);
				}
				if (GUI.Button (new Rect (10, 160, 180, 30), "Назад")) {
					window = 1;
				}
			}

			if (window == 3) {
				GUI.Label (new Rect (50, 10, 180, 30), "Настройки Игры");
				if (GUI.Button (new Rect (10, 40, 180, 30), "Игра")) {
				}
				if (GUI.Button (new Rect (10, 80, 180, 30), "Аудио")) {
				}
				if (GUI.Button (new Rect (10, 120, 180, 30), "Видео")) {
				}
				if (GUI.Button (new Rect (10, 160, 180, 30), "Назад")) {
					window = 1;
				}
			}

			if (window == 4) {
				GUI.Label (new Rect (50, 10, 180, 30), "Об Игре");
				GUI.Label (new Rect (10, 40, 180, 40), "Информация об разработчике и об игре");
				if (GUI.Button (new Rect (10, 90, 180, 30), "Назад")) {
					window = 1;
				}
			}

			if (window == 5) {
				GUI.Label (new Rect (50, 10, 180, 30), "Вы уже выходите?");
				if (GUI.Button (new Rect (10, 40, 180, 30), "Да")) {
					Application.Quit ();
				}
				if (GUI.Button (new Rect (10, 80, 180, 30), "Нет")) {
					window = 1;
				}
			}

			if (window == (int)layer.main) {

				//widthDay = Screen.width / period; // auto adjast
				int offsetY = 0;
            
				Label (10, offsetY + 0, 100, widthDay, "График:", Color.gray);

				offsetY = offsetY + height + 5;

				for (int per = 0; per < period; per++) {
					var day = now.AddDays (per);
					GUI.Button (new Rect (10 + per * height, offsetY, widthDay - 2, height - 2), day.Day.ToString ());
				}

				foreach (Room room in roomList) {
					offsetY = offsetY + height + 5;
					foreach (Rent rent in rentList.Where(i => i.Room.Id == room.Id)) {
						//if (rent.Start >= now && rent.End <= now.AddDays(period))
						{
							int offsetX = (rent.Start - now).Days;
							//Debug.Log(rent.Guest.Name +"End:" +rent.End + " now:" + now + "days:" + offsetX);
							GUI.Button (new Rect (10 + offsetX * widthDay, offsetY, widthDay * rent.Duration - 2, height - 2), rent.Guest.Name);
						}
					}
				}

				//GUI.Button(new Rect(10, 20+room * height, widthDay*3-2, height - 2), "Room1");

				if (GUI.Button (new Rect (10, 400, 180, 30), "Exit")) {
					Application.Quit ();
				}
				if (GUI.Button (new Rect (10, 480, 180, 30), "Back")) {
					window = 1;
				}
			}
			GUI.EndGroup ();
		}

		public void Label (int x, int y, int height, int width, string text, Color color)
		{
			Color oldColor = GUI.color;
			GUI.color = color;
			GUI.Label (new Rect (x, y, height, width), text);
			GUI.color = oldColor;
		}
	}

	public enum layer
	{
		main = 10,
		m2,
	}

	public class Guest
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Phone { get; set; }

		public int Peoples { get; set; }

		public int Childrens { get; set; }

		public int Animals { get; set; }

		public string Desc { get; set; }
	}

	public class Room
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int Places { get; set; }

		public string Desc { get; set; }
	}

	public class Rent
	{
		public Room Room { get; set; }

		public Guest Guest { get; set; }

		public DateTime Start { get; set; }

		public DateTime End { get; set; }

		public int Duration {
			get {
				return (End - Start).Days + 1;
			}
			set {
				if (Start > DateTime.MinValue) {
					End = Start.AddDays (value - 1);
				}
			}
		}
	}
}