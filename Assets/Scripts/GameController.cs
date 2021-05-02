using UnityEngine;
public class GameController : MonoBehaviour{
    public GameObject player;// geting the player distance...
    public int platformCount = 10;

    public Transform levelPart_Start;// geting the position of starting level part 
    public Transform platform1;// to generate the first type of platform
   public Transform platform2;
    public Transform platform3;
   public  Transform enemyPlatform1;
    public Transform enemyPlatform2;
    public Transform enemyPlatform3;
  public   Transform holePlatfrom;

    private Vector3 lastEndPositioin;// to geting the last end position of platform
    public void ResetStartingPlatform() {
        Instantiate(platform1, new Vector3(0,-3.62f,0), Quaternion.identity);
        lastEndPositioin = platform1.Find("EndPosition").position;

       // Destroy(platform1);Destroy(platform2);Destroy(platform3);
      //  Destroy(enemyPlatform1); Destroy(holePlatfrom);
    }
    private void ScoreCalculate()
    {
        PlayerController.score = (uint)lastEndPositioin.y;
        Debug.Log(PlayerController.score);
       
    }
    private void SpawnPlatform1() {// geting the endposition of the last platform
        Transform lastLevelPartTransform = SpawnPlatform1(lastEndPositioin);
        lastEndPositioin = lastLevelPartTransform.Find("EndPosition").position;
    }
    
    private void SpawnPlatform2()
    {// geting the endposition of the last platform2
        Transform lastLevelPartTransform = SpawnPlatform2(lastEndPositioin);
        lastEndPositioin = lastLevelPartTransform.Find("EndPosition").position;
    }
    private void SpawnPlatform3()
    {// geting the endposition of the last platform2
        Transform lastLevelPartTransform = SpawnPlatform3(lastEndPositioin);
        lastEndPositioin = lastLevelPartTransform.Find("EndPosition").position;
    }
    private void SpawnenemyPlatform1()
    {// geting the endposition of the last platform2
        Transform lastLevelPartTransform = SpawnEnemyPlatform1(lastEndPositioin);
        lastEndPositioin = lastLevelPartTransform.Find("EndPosition").position;
    }
    private void SpawnenemyPlatform2()
    {// geting the endposition of the last platform2
        Transform lastLevelPartTransform = SpawnEnemyPlatform2(lastEndPositioin);
        lastEndPositioin = lastLevelPartTransform.Find("EndPosition").position;
    }
    private void SpawnenemyPlatform3()
    {// geting the endposition of the last platform2
        Transform lastLevelPartTransform = SpawnEnemyPlatform3(lastEndPositioin);
        lastEndPositioin = lastLevelPartTransform.Find("EndPosition").position;
    }
    private void SpawnholePlatform()
    {// geting the endposition of the last hole platform
        Transform lastLevelPartTransform = SpawnHolePlatform(lastEndPositioin);
        lastEndPositioin = lastLevelPartTransform.Find("EndPosition").position;
    }
    private Transform SpawnPlatform1(Vector3 spawnPosition) {// generating the first type of platform
        spawnPosition.y += Random.Range(1f, 2f);
        spawnPosition.x = Random.Range(-1.9f, 1.9f);     
        Transform levelPartTransform = Instantiate(platform1, spawnPosition, Quaternion.identity);   
        return levelPartTransform;
    }
    private Transform SpawnPlatform2(Vector3 spawnPosition)
    {// generating the Second type of platform
        spawnPosition.y += Random.Range(1f, 2f);
        spawnPosition.x = Random.Range(-1.9f, 1.9f);
        Transform levelPartTransform = Instantiate(platform2, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
    private Transform SpawnPlatform3(Vector3 spawnPosition)
    {// generating the Second type of platform
        spawnPosition.y += Random.Range(1f, 2.5f);
        spawnPosition.x = Random.Range(-1.9f, 1.9f);
        Transform levelPartTransform = Instantiate(platform3, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
    private Transform SpawnEnemyPlatform1(Vector3 spawnPosition)
    {// generating the Second type of platform
        spawnPosition.y += Random.Range(1f, 3f);
        spawnPosition.x = Random.Range(-1.9f, 1.9f);
        Transform levelPartTransform = Instantiate(enemyPlatform1, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
    private Transform SpawnEnemyPlatform2(Vector3 spawnPosition)
    {// generating the Second type of platform
        spawnPosition.y += Random.Range(1f,2f);
        spawnPosition.x = Random.Range(-1.9f, 1.9f);
        Transform levelPartTransform = Instantiate(enemyPlatform2, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
    private Transform SpawnEnemyPlatform3(Vector3 spawnPosition)
    {// generating the Second type of platform
        spawnPosition.y += Random.Range(1f, 2f);
        spawnPosition.x = Random.Range(-1.9f, 1.9f);
        Transform levelPartTransform = Instantiate(enemyPlatform3, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
    private Transform SpawnHolePlatform(Vector3 spawnPosition)
    {// generating the Second type of platform
        spawnPosition.y += Random.Range(1f, 2f);
        spawnPosition.x = Random.Range(-1.9f, 1.9f);
        Transform levelPartTransform = Instantiate(holePlatfrom, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
    void Start(){
        lastEndPositioin = levelPart_Start.Find("EndPosition").position;
        for (int i = 0; i < 5; i++){
            SpawnPlatform1(); 
        }
    }
    void Update() {
        ScoreCalculate();// give the score 

        if (Vector3.Distance(player.transform.position, lastEndPositioin) < 10){
            if (PlayerController.score < 20)
            {
                SpawnPlatform1();
            }
            else if (PlayerController.score >=20 && PlayerController.score<40){
                int num = Random.Range(0, 2);
              switch (num){
                   case 0: SpawnPlatform1(); 
                        break;
                    case 1: SpawnPlatform2();
                        break;
                }
                EnemyGenerator();
            }
           else{
               PlatformGenerator();EnemyGenerator();
            }
        }

        if (Vector3.Distance(player.transform.position, lastEndPositioin) > 50) {
            Debug.Log("Game is over...");
            PlayMenuUIController.msg = "Game Over";
            Time.timeScale = 0f;
        }

    }

    void EnemyGenerator(){
        int num = Random.Range(0, 40);
        switch (num){
            case 0: SpawnenemyPlatform1();
                break;
            case 10:SpawnenemyPlatform2();
                break;
            case 20: SpawnenemyPlatform3();
                break;
            case 30:
                SpawnholePlatform();
                break;
        }
    }
    void PlatformGenerator() {
        
       
            int num = Random.Range(0, 3);
            switch (num)
            {
                case 0:
                    SpawnPlatform1();
                    break;
                case 1:
                    SpawnPlatform2();
                    break;
                case 2:
                    SpawnPlatform3();
                    break;
            
        }
        
    }
  
  
   
}
