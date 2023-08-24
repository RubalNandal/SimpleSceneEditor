# Unity Scene Editor Project

This project is a Unity-based scene editor that demonstrates various design patterns and features. It allows users to spawn, select, move objects, and save/load scenes.

## Getting Started

1. Clone or download the repository.
2. Open the project in Unity (version 2022.1.24f1).
3. Open the `MainScene` to control the camera and interact with the scene.

## Controls

- W, A, S, D: or up , down, left , right key to Move the camera.
- Mouse movement: Control camera rotation.
- Left-click on object: Select an object.
- Mouse scroll or Z, X to zoom in and zoom out selected object.
- Drag and drop selected object: Move the object.

## Highlights

- Utilizes the new Unity Input System for camera control.
- Implements a scriptable object-based event system for communication between components.
- Uses the Command Pattern for undo/redo functionality.
- Decouples the ViewScene and ControllerScene for improved modularity.

## Running Tests

1. Open the `Test runner` folder.
2. Click on Play mode
3. Click on "Run All" to run all the test cases
4. Check the TestRUnner for test results and assertions.

## Design Choices and Assumptions

- The project focuses on demonstrating specific design patterns and Unity features.
- The separation of the ViewScene and ControllerScene enhances maintainability and extensibility.
- Objects are selected using left-click, and the camera is controlled using WASD and mouse.
- The new Unity Input System improves user interactions.
- Save and load functionality is demonstrated using JSON serialization.
- The project assumes basic Unity knowledge and familiarity with design patterns.
- Test cases cover main functionality of the project  (whole porject unit testing not implemented)

## Contributions

Contributions are welcome! Feel free to submit issues and pull requests to enhance the project.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.