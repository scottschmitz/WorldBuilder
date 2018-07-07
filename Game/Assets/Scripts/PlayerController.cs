using UnityEngine;

public class PlayerController : Character {

    public float moveSpeed = 5.0f;

    public Action action1;
    public Action action2;

    private Animator animator;

    private void Start() {
        ActionBar.Instance.setAction1(action1);
        ActionBar.Instance.setAction2(action2);

        animator = GetComponent<Animator>();
    }

    private void Update() {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        float modifier = moveSpeed * Time.deltaTime;
        transform.Translate(new Vector3(horizontalInput * modifier, verticalInput * modifier, 0f));

        // TODO: When Animator is Setup Correctly
        //animator.SetFloat("MoveX", horizontalInput);
        //animator.SetFloat("MoveY", verticalInput);   
    }
}
