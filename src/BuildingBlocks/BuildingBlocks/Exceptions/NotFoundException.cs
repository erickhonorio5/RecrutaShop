﻿namespace BuildingBlocks.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException(string name, object key) : base($"A Entidade \"{name}\" ({key}) não foi encontrada.")
    {
    }
}