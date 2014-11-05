using UnityEngine;
using System.Collections;

public class Window : MonoBehaviour {

	public GUISkin SkinButtons;
	public GUISkin SkinWindows;
	private bool render = true;
	private bool planet_clicked = false;
	private string time;
	private string date;

	private Rect windowRect = new Rect (Screen.width-(Screen.width/3)-30,Screen.height/2-30, 500, 300);
	private Vector2 scrollViewVector = Vector2.zero;
	private string innerText = "Lorem ipsum dolor sit amet,nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem. Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien ut libero venenatis faucibus. Nullam quis ante. Etiam sit amet orci eget eros faucibus tincidunt. Duis leo. Sed fringilla mauris sit amet nibh. Donec sodales sagittis magna. Sed consequat, leo eget bibendum sodales, augue velit cursus nunc, Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem. Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien ut libero venenatis faucibus. Nullam quis ante. Etiam sit amet orci eget eros faucibus tincidunt. Duis leo. Sed fringilla mauris sit amet nibh. Donec sodales sagittis magna. Sed consequat, leo eget bibendum sodales, augue velit cursus nunc, n";
	public Texture2D earth;
	public Texture2D close;

	public void ShowWindow() {
	
		render = true;
	}
	
	public void HideWindow() {
		render = false;
	}

	void Update()
	{   
		time = System.DateTime.Now.ToString("HH:mm");
		date = System.DateTime.Now.ToString("MM-dd-yyyy");
			
	}
	
	
	void OnGUI () {
		
		GUI.skin = SkinButtons;
		
		GUILayout.BeginArea (new Rect (15, Screen.height/2-30, Screen.width/7, Screen.height/4), "button");
		GUILayout.BeginVertical();
		GUILayout.Button ("Button 1");
		GUILayout.Button ("Button 2");
		GUILayout.Button ("Button 3");
		GUILayout.BeginVertical();
		GUILayout.EndArea ();
		
		
		GUI.Button(new Rect (Screen.width/2-120, Screen.height-80, 230, 35), date + "   |   " + time, "button");
		GUI.Button (new Rect (Screen.width/2+120, Screen.height-80, 90, 35), "Foooo", "button");


		GUI.skin = SkinWindows;

		if(render)
		{
			windowRect = GUI.Window (0, windowRect, WindowFunction, "", "window");
		}

	
	}
	
	void WindowFunction (int windowID) {

		if (GUI.Button (new Rect (460, 8, 30, 30), close)) {
			HideWindow();

		}

		GUI.Label (new Rect (280,30,150,80), "Die Erde", "label");
		GUI.Label (new Rect (25,35,230,230), earth);

		// Begin the ScrollView
		//The first Rect defines the location and size of the viewable ScrollView area on the screen. 
		//The second Rect defines the size of the space contained inside the viewable area.
		scrollViewVector = GUI.BeginScrollView (new Rect (280, 60, 200, 210), scrollViewVector, new Rect (0, 0, 180, 900));
		
		// Put something inside the ScrollView
		//Size of the storage area
		innerText = GUI.TextArea (new Rect (0, 0, 200, 900), innerText, "textarea");
		
		// End the ScrollView
		GUI.EndScrollView();

		GUI.DragWindow ();
	}
	
}

