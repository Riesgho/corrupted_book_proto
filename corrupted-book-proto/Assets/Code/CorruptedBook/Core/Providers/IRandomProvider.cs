﻿namespace CorruptedBook.Core.Providers
{
    public interface IRandomProvider
    {
        int GetRandomValue(int from, int to);
    }
}