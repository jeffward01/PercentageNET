﻿using System;
using System.Diagnostics.Contracts;

namespace PercentageNET;

public static class PercentageHelper
{
    public enum AddMode
    {
        Simple,
        Upcharge
    }

    [Pure]
    public static decimal Count(decimal inputNumber, decimal percentageAmount)
    {
        decimal number = Math.Abs(inputNumber);
        decimal percentage = Math.Abs(percentageAmount);
        decimal amount = number * (percentage / 100);

        return amount;
    }

    [Pure]
    public static decimal Substract(decimal inputNumber, decimal percentageAmount)
    {
        decimal number = Math.Abs(inputNumber);
        return number - Count(inputNumber, percentageAmount);
    }

    [Pure]
    public static decimal Add(decimal inputNumber, decimal percentageAmount, AddMode mode = AddMode.Simple)
    {
        decimal number = Math.Abs(inputNumber);

        if (mode == AddMode.Simple)
        {
            return number + Count(inputNumber, percentageAmount);
        }
        else
        {
            // upcharging the input amount by percentage
            // for example: you want to add "real" 20% to 1000 = 1250
            // 1250 - 20% = 1000
            decimal upchargeAmount  = number / (1 - percentageAmount / 100);
            return upchargeAmount;
        }

    }

}
