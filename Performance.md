# Performance Log

## Before peformance optimization
In the state of before any optimization done before prior to this lab assignment.

### 640x480 - 5 drops
> Debug: 660 ms
> Release: 133 ms

### 1280x720 - 10 drops
> Debug: 2529 ms
> Release: 483 ms

### 1920x1080 - 15 drops
> Debug: 5974 ms
> Release: 1133 ms

### 2560x1440 - 20 drops
> Debug: 100809 ms
> Release: 2066 ms

## After changing the marbling loop in surface
After changing the marbling loop in Surface to use ParallelForEach instead of regular ForEach

### 640x480 - 5 dops
> Debug: 257 ms
> Release: 198 ms

### 1280x720 - 10 drops
> Debug: 642 ms
> Release: 487 ms

### 1920x1080 - 15 drops
> Debug: 973 ms
> Release: 813 ms

### 2560x1440 - 20 drops
> Debug: 1409 ms
> Release: 1071 ms

## After changing the loop in the marble function in paintdrops
After changing the For loop in the actual marble function to use a ParallelFor loop instead of a normal For Loop

### 640x480 - 5 dops
> Debug: 93 ms
> Release: 64 ms

### 1280x720 - 10 drops
> Debug: 270 ms
> Release: 186 ms

### 1920x1080 - 15 drops
> Debug: 633 ms
> Release: 448 ms

### 2560x1440 - 20 drops
> Debug: 1012 ms
> Release: 749 ms