using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class BackgroundControllerV2 : MonoBehaviour
{

    private Transform player;
    public List<Transform> stars;
    
    public static float parallaxDispertion = 0.8f;
    public static float parallaxEffectAmount = 0.5f;
    public int starsInChunk = 60;
    public float chunkSize = 15f;
    public GameObject starPrefab;
    //public int chunksAround = 12;
    public int rows = 5;
    public int cols = 5;
    
    private List<StarsChunk> chunks;

    public class StarsChunk
    {
        public List<Transform> stars;
        private Vector2 leftBottom;
        private Vector2 rightTop;
        private int starsAmount;
        private GameObject starPrefab;

        public StarsChunk(Vector2 leftBottom, Vector2 rightTop, int starsAmount, GameObject starPrefab )
        {
            this.stars = new List<Transform>();
            this.leftBottom = leftBottom;
            this.rightTop = rightTop;
            this.starsAmount = starsAmount;
            this.starPrefab = starPrefab;
        }

        public void clearStars()
        {
            for (int i = this.stars.Count - 1; i >= 0; i--)
            {
                Destroy(this.stars[i].gameObject);
                this.stars.RemoveAt(i);
            }
        }
        
        public void spawnStarsInChunk()
        {
            for (int i = 0; i < starsAmount; i++)
            {
                GameObject star = Instantiate(starPrefab,
                    new Vector3(Random.Range(leftBottom.x, rightTop.x), Random.Range(leftBottom.y, rightTop.y)), Quaternion.identity);
                this.stars.Add(star.transform);
                
                star.GetComponent<StarController>().parallaxEffectAmount = BackgroundControllerV2.parallaxEffectAmount;
                star.GetComponent<StarController>().distance =
                    Random.Range(15, BackgroundControllerV2.parallaxDispertion * 100f);
            }
        }

        public bool includes(Vector2 pos, float padding)
        {
            return pos.x > this.leftBottom.x - padding && pos.x < this.rightTop.x + padding && pos.y  > this.leftBottom.y- padding &&
                   pos.y  < this.rightTop.y + padding;
        }
    }

    void spawnStarChunks()
    {
        Vector2 startPosition = new Vector2(-(cols / 2) * chunkSize, -(rows / 2) * chunkSize);

        for (int i = 0; i < rows; i++)
        {
            Vector2 rowStartPosition = startPosition;
            for (int j = 0; j < cols; j++)
            {
                Debug.Log(startPosition);
                StarsChunk chunk = new StarsChunk(startPosition,
                    new Vector2(rowStartPosition.x + chunkSize, rowStartPosition.y + chunkSize), starsInChunk, starPrefab);
                chunk.spawnStarsInChunk();
                chunks.Add(chunk);
                rowStartPosition.x += chunkSize;
            }

            startPosition.y += chunkSize;
        }
    }

    void Awake()
    {
        chunks = new List<StarsChunk>();
        spawnStarChunks();

        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        foreach (var chunk in chunks)
        {
            if (!chunk.includes(player.position, 10f))
            {
                chunk.clearStars();
            } else if (chunk.stars.Count == 0)
            {
                chunk.spawnStarsInChunk();
            }
        }
        
    }

    
}
