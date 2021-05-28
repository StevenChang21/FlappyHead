using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] GameObject _ObstaclePrefab;
    [SerializeField] Transform _Player;
    [SerializeField] [Range(1, 40)] int max_ObstacleCount;
    [SerializeField] [Range(0f, 1f)] float _ObstacleHeightModifier = 0.5f;
    [SerializeField] [Range(1f, 10f)] float ease = 1.2f;
    [SerializeField] [Range(3, 8)] float max_ObstacleHeight;
    [SerializeField] [Range(-8, -3)] float min_ObstacleHeight;

    float smallest_space;
    Queue<GameObject> obstacles = new Queue<GameObject>();
    float x_distance;
    float last_x_pos;
    float _totalVerticalSpace;
    float _previousObstacleHeight;

    public float X_distance => x_distance;

    void Start()
    {
        _totalVerticalSpace = max_ObstacleHeight - min_ObstacleHeight;
        var playerHeight = _Player.localScale.y;
        smallest_space = (playerHeight / _totalVerticalSpace) * ease;
        x_distance = 20 / max_ObstacleCount;
    }

    void Update()
    {
        if (obstacles.Count / 2 < max_ObstacleCount)
        {
            var xpos = 0f;
            if (obstacles.Count >= 1)
            {
                xpos = last_x_pos;
            }
            GenerateObstacle(xpos);
        }
        if (obstacles.Count / 2 >= max_ObstacleCount)
        {
            if (obstacles.Peek().transform.position.x + 8f < _Player.position.x)
            {
                DisposePassedObstacles(obstacles.Dequeue());
                DisposePassedObstacles(obstacles.Dequeue());
            }
        }
    }

    private void DisposePassedObstacles(GameObject obstacle)
    {
        Destroy(obstacle, 2f);
    }

    private void GenerateObstacle(float previous_obstacle_xpos)
    {
        var percent_obstacle_total_height = 1 - (smallest_space * Random.Range(_ObstacleHeightModifier, 1f));
        var obstacle_total_height = _totalVerticalSpace * percent_obstacle_total_height;
        Calculate_Obstacle_Height_And_Ypos(obstacle_total_height, out var lower_obstacle_height, out var lower_obstacle_yPos, false,
                                            (float max_obstacle_height_mag, float obstacle_height) =>
                                            {
                                                return max_obstacle_height_mag + obstacle_height * 0.5f;
                                            });
        Calculate_Obstacle_Height_And_Ypos(obstacle_total_height, out var upper_obstacle_height, out var upper_obstacle_yPos, true,
                                            (float max_obstacle_height_mag, float obstacle_height) =>
                                            {
                                                return max_obstacle_height_mag + obstacle_height * -0.5f;
                                            });
        SpawnObstacle(previous_obstacle_xpos, lower_obstacle_height, lower_obstacle_yPos);
        SpawnObstacle(previous_obstacle_xpos, upper_obstacle_height, upper_obstacle_yPos);
    }

    private void Calculate_Obstacle_Height_And_Ypos(float obstacle_total_height, out float half_obstacle_height, out float half_obstacle_yPos, bool is_previous_pair, System.Func<float, float, float> GetHeightMethod)
    {
        if (is_previous_pair)
        {
            half_obstacle_height = obstacle_total_height - _previousObstacleHeight;
            half_obstacle_yPos = GetHeightMethod(max_ObstacleHeight, half_obstacle_height);
            _previousObstacleHeight = half_obstacle_height;
            return;
        }
        half_obstacle_height = obstacle_total_height * Random.Range(0f, 1f);
        half_obstacle_yPos = GetHeightMethod(min_ObstacleHeight, half_obstacle_height);
        _previousObstacleHeight = half_obstacle_height;
    }

    private void SpawnObstacle(float previous_obstacle_xpos, float obstacle_height, float obstacle_yPos)
    {
        var obstacle_gameObject = Instantiate(_ObstaclePrefab, new Vector3(previous_obstacle_xpos + x_distance, obstacle_yPos, 0f), Quaternion.identity);
        obstacle_gameObject.transform.localScale = new Vector3(obstacle_gameObject.transform.localScale.x, obstacle_height, obstacle_gameObject.transform.localScale.z);
        last_x_pos = obstacle_gameObject.transform.position.x;
        obstacles.Enqueue(obstacle_gameObject);
    }
}
