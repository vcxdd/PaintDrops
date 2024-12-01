# PaintDrops
This application is about our take on paint drops simulation on a surface. 

## Core Features
- Using the mouse, you can left-click to create a paint drop (a circle)
- Right-clicking clears the application of any paint drop.
- Pressing M on the keyboard starts pattern generation
- Pressing E on the keyboard stops the phyllotaxis generation (allows to continue from where it stops)
- Pressing D adds a delay on the pattern generation
- Pressin J increases the radius of the drops (Max: 64) (Default: 16)
- Pressing K decreases the radius of the drops (Min: 4) (Default: 16)
- Paint drops outside the border of the screen gets deleted
- Adding more paint drops shapes other drops and make space for the new drop. 
- This also features a scalable screen where the change in screen size scales with everything happening in the application (clicks, drawings, game screen size).

- (NEW) benchmark testing, run the console app PaintDropSimulationBenchmarking to test the performance of the app (Program.cs)
- (NEW) Pressing P toggles between different pattern generationss (phyllotaxis or spiral)
- (NEW) Pressing M generates a pattern depending on the selected pattern from toggle (default: phyllotaxis)

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
