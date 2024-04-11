using System.Numerics;
using MathNet.Numerics.IntegralTransforms;

namespace FFTransform;

class FourierTransformator
{
    private const int ZeroValue = 0;
    private const int TwoMultiplicity = 2;
    private const int ThreeMultiplicity = 3;
    private const int FiveMultiplicity = 5;

    private string _errorConversionMessage =
        $"Ошибка, длина преобразования не кратна {TwoMultiplicity},{ThreeMultiplicity},{FiveMultiplicity}";

    public Complex[] FastForwardTransform(Complex[] values)
    {
        if (!CheckLengthMultiplicity(values.Length))
        {
            throw new ArgumentException(_errorConversionMessage);
        }

        Fourier.Forward(values);

        return values;
    }

    public Complex[] InverseTransform(Complex[] values)
    {
        if (!CheckLengthMultiplicity(values.Length))
        {
            throw new AggregateException(_errorConversionMessage);
        }

        Fourier.Inverse(values);

        return values;
    }

    private bool CheckLengthMultiplicity(int length)
    {
        bool isValid = length > ZeroValue && length % TwoMultiplicity == 0 && length % ThreeMultiplicity == 0 &&
                       length % FiveMultiplicity == 0;

        return isValid;
    }
}