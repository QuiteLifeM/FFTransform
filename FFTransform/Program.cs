using System.Numerics;
using FFTransform;
using MathNet.Numerics;

class Program
{
    private const string InputMessage = "Введите длину";

    public static void Main()
    {
        FourierTransformator fourierTransformator = new FourierTransformator();
        
        Console.WriteLine(InputMessage);
        int inputLength = Convert.ToInt32(Console.ReadLine());
        Complex[] randomComplexValues = GenerateRandomComplexValues(inputLength);
        Complex[] fastForwardValues = fourierTransformator.FastForwardTransform(randomComplexValues);
        Complex[] inverseValues = fourierTransformator.InverseTransform(fastForwardValues);

        double error = CalculateError(randomComplexValues, inverseValues);
        Console.WriteLine($"Ошибка между входными и выходными данными: {error}");
    }

    private static Complex[] GenerateRandomComplexValues(int length)
    {
        Random random = new Random();
        Complex[] values = new Complex[length];

        for (int i = 0; i < length; i++)
        {
            values[i] = new Complex(random.NextDouble(), random.NextDouble());
        }

        return values;
    }

    private static double CalculateError(Complex[] inputValues, Complex[] outputValues)
    {
        double sumSquaredError = 0.0;
        
        for (int i = 0; i < inputValues.Length; i++)
        {
            Complex difference = inputValues[i] - outputValues[i];
            sumSquaredError += difference.MagnitudeSquared();
        }

        double MeanSquaredError = sumSquaredError / inputValues.Length;
        double rootMeanSquareError = Math.Sqrt(MeanSquaredError);

        return rootMeanSquareError;
    }
}