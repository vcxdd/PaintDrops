# PaintDrops
This application is about our take on paint drops simulation on a surface. Using the mouse, you can left-click to create a paint drop (a circle) and adding more paint drops shapes other drops and make space for the new drop. Right-clicking clears the application of any paint drop. This also features a scalable screen where the change in screen size scales with everything happening in the application (clicks, drawings, game screen size).

## Setup

1. Clone Repository
2. Change directory to root of project
3. Run the solution file
```bash
devenv PaintDrops.sln
```
4. Run the program

## Run locally
1. Download artifact (artifact.zip)
2. Unzip Game.tar
3. Go to inside PaintDropsArtifact
4. Find PaintDrops.exe and run it

## Testing

1. Repeat Steps 1 and 2 of Setup
2. Run test in IDE of choice or:
```bash
dotnet test
```

View ./ShapeLibraryTests/ for detailed test cases for Shapes
View ./PaintDropTests/ for detailed test cases for Simulation
