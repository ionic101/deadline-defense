using UnityEngine;

public class CameraController : MonoBehaviour {

	public float panSpeed = 30f;
	public float panBorderThickness = 10f;

	public float scrollSpeed = 5f;

	public Vector3 startAreaControll = new Vector3(-10, -10, -10);
	public Vector3 endAreaControll = new Vector3(85, 10, -85);

    void Update () {

		if (GameManager.GameIsOver)
		{
			this.enabled = false;
			return;
		}

		if ((Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) && transform.position.z < startAreaControll.z)
		{
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
		}
		if ((Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness) && transform.position.z > endAreaControll.z)
		{
			transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
		}
		if ((Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) && transform.position.x < endAreaControll.x)
		{
			transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
		}
		if ((Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness) && transform.position.x > startAreaControll.x)
		{
			transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
		}

		float scroll = Input.GetAxis("Mouse ScrollWheel");

		Vector3 pos = transform.position;

		pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, startAreaControll.y, endAreaControll.y);

		transform.position = pos;

	}
}
