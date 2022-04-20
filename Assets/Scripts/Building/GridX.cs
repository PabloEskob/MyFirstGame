using System.Collections.Generic;
using UnityEngine;

public class GridX : MonoBehaviour
{
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private int _cellSize;
    [SerializeField] private Transform _originPosition;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private List<Tile> _list;
    [SerializeField] private Building _building;

    private Tile[,] _grid;

    private void Start()
    {
        _grid = new Tile[_width, _height];
        _list = new List<Tile>();

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                _grid[x, y] = Instantiate(_tilePrefab, GetWorldPosition(x, y), Quaternion.identity);
                _list.Add(_grid[x, y]);
            }
        }

        Init(_list);
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * _cellSize + _originPosition.position;
    }

    private void Init(List<Tile> tiles)
    {
        foreach (var tile in tiles)
        {
            tile.AddBuilding(_building);
        }
    }
}