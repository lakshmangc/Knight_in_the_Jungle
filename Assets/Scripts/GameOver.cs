using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
	public GameObject gameOverText;
	public GameObject restartButton;
	public GameObject mainMenuButton;


	private IEnumerator OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			yield return new WaitForSeconds(.5f);
			gameOverText.SetActive(true);
			yield return new WaitForSeconds(2.0f);
			restartButton.SetActive(true);
			yield return new WaitForSeconds(1.0f);
			mainMenuButton.SetActive(true);

		}
	}

}
