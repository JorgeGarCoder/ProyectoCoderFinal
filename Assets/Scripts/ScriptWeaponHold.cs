using UnityEngine;

public class ScriptWeaponHold : MonoBehaviour
{
    //public ScriptGunSystem _scriptGunSystem;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, weaponHolderTransform, _camera;
    [SerializeField] float pickUpRange = 2f, dropForwardForce = 3f, dropUpwardForce = 3f;
    [SerializeField] bool IsEquiped = true;
    public static bool slotFull;

    private void Start()
    {
        if (!IsEquiped)
        {
            //_scriptGunSystem.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        else
        {
            //_scriptGunSystem.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        
        if (!IsEquiped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        {
            PickUp();
        }

        if (IsEquiped && Input.GetKeyDown(KeyCode.G))
        {
            Drop();
        }
    }

        
    void PickUp()
    {
        IsEquiped = true;
        slotFull = true;
        rb.isKinematic = true;
        coll.isTrigger = true;
        //_scriptGunSystem.enabled = true;
        
        //make the weapon a child of the camera and move to weapon hold
        transform.SetParent(weaponHolderTransform);
        this.transform.position = weaponHolderTransform.transform.position;
        
        this.transform.localPosition = Vector3.zero;
        this.transform.localRotation = Quaternion.Euler(Vector3.zero);        
    }
    
    void Drop()
    {
        IsEquiped = false;
        slotFull = false;
        
        //set parent to null
        transform.SetParent(null);
        rb.isKinematic = false;
        coll.isTrigger = false;

        rb.velocity = player.GetComponent<Rigidbody>().velocity;
        rb.AddForce(_camera.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(_camera.up * dropUpwardForce, ForceMode.Impulse);
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);
        
        //_scriptGunSystem.enabled = false;
    }
}
