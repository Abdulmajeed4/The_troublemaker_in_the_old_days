using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    // مكونات المطلوبة للتحكم في الحركة
    public CharacterController controller; // مكون للتحكم في الحركة
    public Transform cam; // تحويل الكاميرا لتحديد اتجاه الدوران

    // متغيرات لتحديد سرعة الحركة وسلاسة الدوران
    public float speed = 6f; // سرعة الحركة
    public float turnSmoothTime = 0.1f; // زمن الانتقال السلس للدوران
    private float turnSmoothVelocity; // متغير مساعد لحساب الدوران السلس

    void Update()
    {
        // الحصول على مدخلات المحاور الأفقية والعمودية من لوحة المفاتيح أو الجويستك
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // إنشاء متجه اتجاه للحركة بناءً على مدخلات المستخدم
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // التحقق من وجود مدخلات للحركة (إذا كان اللاعب ضغط على أي مفتاح)
        if (direction.magnitude >= 0.1f)
        {
            // حساب الزاوية المستهدفة للدوران بناءً على اتجاه الحركة وزاوية الكاميرا
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            // استخدام دالة SmoothDampAngle لجعل الدوران أكثر سلاسة
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            // تحديث دوران الكائن (الشخصية) بالزاوية المحسوبة
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // حساب متجه الحركة الفعلي بناءً على الزاوية المستهدفة
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            // تحريك الشخصية باستخدام مكون CharacterController وسرعة الحركة وزمن الإطار
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}


//------------------------------------------------------------
// using UnityEngine;

// public class CharacterControllerMovement : MonoBehaviour
// {
//     // مكونات المطلوبة للتحكم في الحركة
//     public CharacterController controller;
//     public Transform cam;

//     // متغيرات للحركة والقفز
//     public float speed = 6f;
//     public float turnSmoothTime = 0.1f;
//     public float jumpHeight = 3f;
//     private float turnSmoothVelocity;
//     public Transform groundCheck;
//     public float groundDistance = 0.4f;
//     public LayerMask groundMask;
//     private bool isGrounded;

//     void Update()
//     {
//         // التحقق من وجود الأرض
//         isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

//         // الحصول على مدخلات المحاور الأفقية والعمودية من لوحة المفاتيح أو الجويستك
//         float horizontal = Input.GetAxisRaw("Horizontal");
//         float vertical = Input.GetAxisRaw("Vertical");

//         // إنشاء متجه اتجاه للحركة بناءً على مدخلات المستخدم
//         Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

//         // التحقق من وجود مدخلات للحركة (إذا كان اللاعب ضغط على أي مفتاح)
//         if (direction.magnitude >= 0.1f)
//         {
//             // حساب الزاوية المستهدفة للدوران بناءً على اتجاه الحركة وزاوية الكاميرا
//             float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
//             // استخدام دالة SmoothDampAngle لجعل الدوران أكثر سلاسة
//             float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
//             // تحديث دوران الكائن (الشخصية) بالزاوية المحسوبة
//             transform.rotation = Quaternion.Euler(0f, angle, 0f);

//             // حساب متجه الحركة الفعلي بناءً على الزاوية المستهدفة
//             Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
//             // تحريك الشخصية باستخدام مكون CharacterController وسرعة الحركة وزمن الإطار
//             controller.Move(moveDir.normalized * speed * Time.deltaTime);
//         }

//         // القفز
//         //  if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
//         // {
//         //     Vector3 velocity = controller.velocity;
//         //     velocity.y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
//         //     controller.Move(velocity * Time.deltaTime);
//         // }
//     }
// }


// using UnityEngine;

// public class RigidbodyMovement : MonoBehaviour
// {
//     public Rigidbody rb;
//     public Transform cam;

//     public float speed = 6f;
//     public float turnSmoothTime = 0.1f;
//     public float jumpHeight = 3f;
//     private float turnSmoothVelocity;

//     public Transform groundCheck;
//     public float groundDistance = 0.4f;
//     public LayerMask groundMask;
//     bool isGrounded;

//     void Update()
//     {
//         // التحقق من وجود الأرض
//         isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

//         // الحصول على مدخلات المحاور الأفقية والعمودية من لوحة المفاتيح أو الجويستك
//         float horizontal = Input.GetAxisRaw("Horizontal");
//         float vertical = Input.GetAxisRaw("Vertical");

//         // إنشاء متجه اتجاه للحركة بناءً على مدخلات المستخدم
//         Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

//         // التحقق من وجود مدخلات للحركة (إذا كان اللاعب ضغط على أي مفتاح)
//         if (direction.magnitude >= 0.1f)
//         {
//             // حساب الزاوية المستهدفة للدوران بناءً على اتجاه الحركة وزاوية الكاميرا
//             float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
//             // استخدام دالة SmoothDampAngle لجعل الدوران أكثر سلاسة
//             float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
//             // تحديث دوران الكائن (الشخصية) بالزاوية المحسوبة
//             transform.rotation = Quaternion.Euler(0f, angle, 0f);

//             // حساب متجه الحركة الفعلي بناءً على الزاوية المستهدفة
//             Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
//             // تحريك الشخصية باستخدام Rigidbody
//             rb.velocity = moveDir.normalized * speed;
//         }

//         // القفز
//         if (Input.GetButtonDown("Jump") && isGrounded)
//         {
//             rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
//         }
//     }
// }