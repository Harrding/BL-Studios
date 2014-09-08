using System.Collections;
using UnityEngine;

public static class MasterClass
{
	static string POWERUPS_HS = "MostPowerUps";
	static string HIGHESTSCORE_HS = "HighestScore";
	static string OBSTACLES_HS = "ObstaclesHit";

	public static void saveHighestScore(int score) {
		PlayerPrefs.SetInt (HIGHESTSCORE_HS, score);
	}
	public static void savePUCollected(int num) {
		PlayerPrefs.SetInt (POWERUPS_HS, num);
	}
	public static void saveObstaclesHit(int num) {
		PlayerPrefs.SetInt(OBSTACLES_HS, num);
	}

	public static int getHighestScore() {
		return PlayerPrefs.GetInt(HIGHESTSCORE_HS);
	}
	public static int getPUCollected() {
		return PlayerPrefs.GetInt(POWERUPS_HS);
	}
	public static int getObstaclesHit() {
		return PlayerPrefs.GetInt(OBSTACLES_HS);
	}
}