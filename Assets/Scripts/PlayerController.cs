using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed; //can make changes in the editor!

	private Rigidbody rb;
	private int count;

	public Text countText;
	public Text winText;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate() //called before doing any physics calculations
	{
		float moveHoriztonal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHoriztonal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
			if (count >= 13) 
			{
				winText.text = "You Won!";
			}
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
	}
}
