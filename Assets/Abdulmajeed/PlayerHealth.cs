// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;
// using System.Collections.Generic;


// public class PlayerHealth : MonoBehaviour
// {
//     public int maxHealth = 100;
//     public int currentHealth;
//     // public float timeLimit = 90f;


//     public HealthBar healthBar; 

//     void Start()
//     {
//         currentHealth = maxHealth;
//         healthBar.SetMaxHealth(maxHealth); 
//     }

//     //  void Update()
//     // {
//     //     if (timeRemaining > 0)
//     //     {
//     //         timeRemaining -= Time.deltaTime;
//     //         timerText.text = "Time left: " + Mathf.RoundToInt(timeRemaining) + " seconds";

//     //         // التحقق من الوقت المنخفض، تغيير لون النص، وتشغيل الصوت
//     //         if (timeRemaining <= 11)
//     //         {
//     //             timerText.color = Color.red;
//     //             if (audioSource != null && !audioSource.isPlaying) // تحقق إذا كان AudioSource موجودًا ولا يتم تشغيله
//     //             {
//     //                 audioSource.PlayOneShot(lowTimeSound);
//     //             }
//     //         }
//     //         else
//     //         {
//     //             timerText.color = Color.black;
//     //         }

//     //         // التحقق من انتهاء الوقت
//     //         if (timeRemaining <= 0)
//     //         {
//     //             SceneManager.LoadScene("lost"); // انتقل إلى مشهد الخسارة
//     //         }
//     //     }

//     private void OnCollisionEnter(Collision collision)
//     {
//         if (collision.gameObject.tag == "Enemy")
//         {
//             TakeDamage(25);
//         }
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.gameObject.tag == "Health")
//         {
//             Heal(25);
//             Destroy(other.gameObject); 
//         }
//     }

//     void TakeDamage(int damage)
//     {
//         currentHealth -= damage;
//         if (currentHealth <= 0)
//         {
//             currentHealth = 0;
//             Debug.Log("You Lose!"); 
//             SceneManager.LoadScene("lost");
//         }
//         healthBar.SetHealth(currentHealth); 
//     }

//     void Heal(int healAmount)
//     {
//         currentHealth += healAmount;
//         if (currentHealth > maxHealth)
//         {
//             currentHealth = maxHealth;
//         }
//         healthBar.SetHealth(currentHealth); 
//     }
// }




//------------------------



// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;

// public class PlayerHealth : MonoBehaviour
// {
//     public int maxHealth = 100;
//     public int currentHealth;

//     public HealthBar healthBar; // شريط الصحة

//     // نظام الوقت
//     public float timeLimit = 90f;
//     private float timeRemaining;
//     public Text timerText; // نص لعرض الوقت المتبقي
//     public AudioClip lowTimeSound; // صوت تحذير عند اقتراب الوقت من الانتهاء
//     private AudioSource audioSource;

//     private void Start()
//     {
//         currentHealth = maxHealth;
//         healthBar.SetMaxHealth(maxHealth);

//         // تهيئة نظام الوقت
//         timeRemaining = timeLimit;
//         audioSource = GetComponent<AudioSource>(); // افترض أن AudioSource متصل بهذا الأبجكت
//         controller = GetComponent<CharacterController>();

//     }

//     private void Update()
//     {
//         // تحديث الوقت المتبقي
//         if (timeRemaining > 0)
//         {
//             timeRemaining -= Time.deltaTime;
//             timerText.text = $"Time left: {Mathf.RoundToInt(timeRemaining)} seconds";

//             // التحقق من الوقت المنخفض، تغيير لون النص، وتشغيل الصوت
//             if (timeRemaining <= 10)
//             {
//                 timerText.color = Color.red;
//                 if (audioSource != null && !audioSource.isPlaying)
//                 {
//                     audioSource.PlayOneShot(lowTimeSound);
//                 }
//             }
//             else
//             {
//                 timerText.color = Color.black;
//             }

//             // التحقق من انتهاء الوقت
//             if (timeRemaining <= 0)
//             {
//                 SceneManager.LoadScene("PreLosing"); // انتقل إلى مشهد الخسارة
//             }
//         }

//         // ... (بقية الكود الخاص بالتصادمات والشفاء)
//     }

//      private CharacterController controller;

    

//     private void OnControllerColliderHit(ControllerColliderHit hit)
//     {
//         if (hit.gameObject.CompareTag("Enemy"))
//         {
//             TakeDamage(25);
//         }
//         else if (hit.gameObject.CompareTag("Health"))
//         {
//             Heal(25);
//             Destroy(hit.gameObject);
//         }
//     }



//     // private void OnCollisionEnter(Collision collision)
//     // {
//     //     if (collision.gameObject.tag == "Enemy")
//     //     {
//     //         TakeDamage(25);
//     //     }
//     // }

//     // private void OnTriggerEnter(Collider other)
//     // {
//     //     if (other.gameObject.tag == "Health")
//     //     {
//     //         Heal(25);
//     //         Destroy(other.gameObject); 
//     //     }
//     // }

//     void TakeDamage(int damage)
//     {
//         currentHealth -= damage;
//         if (currentHealth <= 0)
//         {
//             currentHealth = 0;
//             Debug.Log("You Lose!"); 
//             SceneManager.LoadScene("lost");
//         }
//         healthBar.SetHealth(currentHealth); 
//     }

//     void Heal(int healAmount)
//     {
//         currentHealth += healAmount;
//         if (currentHealth > maxHealth)
//         {
//             currentHealth = maxHealth;
//         }
//         healthBar.SetHealth(currentHealth); 
//     }
// }


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar; // شريط الصحة

    // نظام الوقت
    public float timeLimit = 90f;
    private float timeRemaining;
    public Text timerText; // نص لعرض الوقت المتبقي
    public AudioClip lowTimeSound; // صوت تحذير عند اقتراب الوقت من الانتهاء
    private AudioSource audioSource;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        // تهيئة نظام الوقت
        timeRemaining = timeLimit;
        audioSource = GetComponent<AudioSource>(); // افترض أن AudioSource متصل بهذا الأبجكت
        controller = GetComponent<CharacterController>();

    }

    private void Update()
    {
        // تحديث الوقت المتبقي
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = $"Time left: {Mathf.RoundToInt(timeRemaining)} seconds";

            // التحقق من الوقت المنخفض، تغيير لون النص، وتشغيل الصوت
            if (timeRemaining <= 15)
            {
                timerText.color = Color.red;
                if (audioSource != null && !audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(lowTimeSound);
                }
            }
            else
            {
                timerText.color = Color.black;
            }

            // التحقق من انتهاء الوقت
            if (timeRemaining <= 0)
            {
                SceneManager.LoadScene("PreLosing"); // انتقل إلى مشهد الخسارة
            }
        }

        // ... (بقية الكود الخاص بالتصادمات والشفاء)
    }

     private CharacterController controller;

    

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
        else if (hit.gameObject.CompareTag("Health"))
        {
            Heal(25);
            Destroy(hit.gameObject);
        }
    }



    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.tag == "Enemy")
    //     {
    //         TakeDamage(25);
    //     }
    // }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.tag == "Health")
    //     {
    //         Heal(25);
    //         Destroy(other.gameObject); 
    //     }
    // }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("You Lose!"); 
            SceneManager.LoadScene("Lose_Scene");
        }
        healthBar.SetHealth(currentHealth); 
    }

    void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth); 
    }
}