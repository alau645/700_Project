﻿using UnityEngine;
using System.Collections;
using Parse;

public class AppManager {
	// list of scenes
	public const string START_SCENE = "StartScene";
	public const string TEACHER_LOGIN_SCENE = "TeacherLoginScene";
	public const string MAIN_MENU_SCENE = "MainMenuScene";
	public const string TASK_SELECTION_SCENE = "TaskSelectionScene";
	public const string START_SESSION_SCENE = "StartSessionScene";
	public const string TEACHER_SCENE = "TeacherScene";
	public const string TEACHER_COMPLETED_TASKS_SCENE = "TeacherCompletedTasksScene";

	public const string Y1Q1_SCENE = "Y1Q1Scene";
	public const string Y1Q2_SCENE = "Y1Q2Scene";
	public const string Y1Q3_SCENE = "Y1Q3Scene";
	public const string Y1Q4_SCENE = "Y1Q4Scene";
	public const string Y1Q5_SCENE = "Y1Q5Scene";
	public const string Y1Q6_SCENE = "Y1Q6Scene";
	public const string Y1Q7_SCENE = "Y1Q7Scene";
	public const string Y1Q8_SCENE = "Y1Q8Scene";
	public const string Y1Q9_SCENE = "Y1Q9Scene";
	public const string Y1Q10_SCENE = "Y1Q10Scene";
	public const string Y1Q11_SCENE = "Y1Q11Scene";
	public const string Y1Q12_SCENE = "Y1Q12Scene";


	public bool sound = false; //{ get; set; }
	public bool teacherMode = false; //{ get; set; }

	// player/student info
	public ParseObject student = null; // student object reference in Parse
	public string firstName = null;
	public string lastName = null;

	public string currentClass = null;
	public string currentTask = null;

	// Singleton
	private static readonly object padlock = new object();
	private static AppManager instance;
	private AppManager() {}
	public static AppManager Instance
	{
		get 
		{
			lock (padlock) // thread-safety
			{
				if (instance == null)
				{
					instance = new AppManager();
				}
				return instance;
			}
		}
	}

	public void setCurrentTask(string task) {
		if (student != null) {
			student["helpNeeded"] = "No"; // default to no helpNeeded
			student["currentTask"] = task;
			student.SaveAsync().ContinueWith(t => {
				if (t.IsFaulted || t.IsCanceled) {
					Debug.Log("Set currentTask failed");
				} else {
					// successful.
				}
			});
		}
	}

	public void setHelpNeeded(bool helpNeeded) {
		if (student != null) {
			if (helpNeeded) {
				student["helpNeeded"] = "Yes";
			} else {
				student["helpNeeded"] = "No";
			}
			student.SaveAsync().ContinueWith(t => {
				if (t.IsFaulted || t.IsCanceled) {
					Debug.Log("Set helpNeeded failed");
				} else {
					// successful.
				}
			});
		}
	}

	// append to Parse DB the completed task
	public void addCompletedTask(string task, int numStars) {
		if (student != null) {
			string append = task + "; Stars: " + numStars;
			if (student["completedTasks"] != "") {
				student["completedTasks"] += "\n" + append;
			} else {
				student["completedTasks"] += append;
			}
		}
	}

	// use this method for exiting a task scene instead of Application.LoadLevel
	public void exitTask(string scene) {
		Application.LoadLevel(scene);
		setCurrentTask("None");
	}

	// passing student completedTasks of a student in Teacher Scene
	public void storeCompletedTasks(string studentName, string tasks) {
		string s = studentName + "\n" + tasks;
		if (tasks.Equals(""))
			s += "Has not yet completed any tasks";
		PlayerPrefs.SetString ("COMPLETED_TASKS", s);	
	}

	public string loadCompletedTasks() {
		return PlayerPrefs.GetString ("COMPLETED_TASKS");
	}
}
