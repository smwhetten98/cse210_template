using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = _bottom = 1;
    }

    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public int GetTop()
    {
        return _top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetTop(int newTop)
    {
        _top = newTop;
    }

    public void SetBottom(int newBottom)
    {
        _bottom = newBottom;
    }

    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue()
    {
        return EvaluateFraction(_top, _bottom);
    }

    private double EvaluateFraction(int top, int bottom)
    {
        return (double)top/bottom;
    }
}