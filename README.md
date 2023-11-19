# .NET Console App - Celestial Body Gravitational Field Estimator

This console application provides estimations for the behavior of celestial bodies in a Uniform Gravitational Field.

This program expects input in the following format:
GravitationalForceSourceMass GravitationalForceAffectedPositionX,GravitationalForceAffectedPositionY GravitationalForceAffectedSpeedX,GravitationalForceAffectedSpeedY ElapsedTime,IntervalsAmount

## Usage

1. Publish Console App
2. Open a terminal in the published folder:
    Run the command (Windows):
    ```
    GravitationalFieldEstimator.exe 00000 100,90 10,0 1,100 1,10
    ```
    Run the command (MacOS):
    ```
    dotnet GravitationalFieldEstimator.dll 100000 100,90 10,0 1,100 1,10
    ```

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
