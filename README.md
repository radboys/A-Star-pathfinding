# A* Pathfinding Implementation in Unity

This project implements the A* pathfinding algorithm in Unity, providing a visual demonstration of pathfinding in a grid-based environment.

## Overview

The implementation consists of three main components:

1. `AStarNode.cs` - Defines the node structure and types
2. `AStarManager.cs` - Core A* algorithm implementation
3. `AstarTest.cs` - Unity test scene and visualization

## Components

### AStarNode.cs
- Defines the basic node structure used in the pathfinding grid
- Contains properties for:
  - Node coordinates (x, y)
  - Node type (Walkable, Unwalkable, HighCost)
  - Pathfinding values (fValue, gValue, hValue)
  - Parent node reference
  - Check status

### AStarManager.cs
- Implements the core A* pathfinding algorithm
- Features:
  - Singleton pattern implementation
  - Grid initialization
  - Path finding between two points
  - Open and closed list management
  - Node evaluation and sorting
  - Performance tracking

### AstarTest.cs
- Unity test scene implementation
- Features:
  - Visual grid representation
  - Interactive path selection
  - Performance metrics display
  - Different node type visualization
  - Mouse-based interaction

## Node Types

1. **Walkable** - Normal path nodes
2. **Unwalkable** - Obstacles that cannot be traversed
3. **HighCost** - Areas that can be traversed but with higher movement cost

## Usage

1. Set up the grid parameters in the Unity Inspector:
   - Map width and height
   - Grid offset values
   - Starting position coordinates
   - Material assignments for different node types

2. In the test scene:
   - Click once to set the start point
   - Click again to set the end point
   - The path will be automatically calculated and displayed
   - Performance metrics will be shown (time taken, node count, total cost)

## Performance Features

- Path calculation time tracking
- Node count tracking
- Total path cost calculation
- Visual feedback for different node states

## Visualization

- Red: Unwalkable nodes (obstacles)
- White: Normal path nodes
- Green: Calculated path
- Yellow: Start/end points
- Gray: High-cost areas (optional)
