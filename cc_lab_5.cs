using System;
using System.Collections.Generic;

class SymbolTable
{
    private const int TableSize = 100;
    private List<SymbolEntry>[] hashTable;

    public SymbolTable()
    {
        hashTable = new List<SymbolEntry>[TableSize];
        for (int i = 0; i < TableSize; i++)
        {
            hashTable[i] = new List<SymbolEntry>();
        }
    }

    public void Insert(string name, string type)
    {
        int hash = HashFunction(name);
        SymbolEntry entry = new SymbolEntry(name, type);

        // Check if the symbol is already in the table
        if (!Contains(name))
        {
            hashTable[hash].Add(entry);
            Console.WriteLine($"Inserted: {name}, Type: {type}");
        }
        else
        {
            Console.WriteLine($"Duplicate entry: {name}, Type: {type}");
        }
    }

    public bool Contains(string name)
    {
        int hash = HashFunction(name);
        List<SymbolEntry> bucket = hashTable[hash];

        foreach (SymbolEntry entry in bucket)
        {
            if (entry.Name == name)
            {
                return true; // Symbol found
            }
        }

        return false; // Symbol not found
    }

    public string GetType(string name)
    {
        int hash = HashFunction(name);
        List<SymbolEntry> bucket = hashTable[hash];

        foreach (SymbolEntry entry in bucket)
        {
            if (entry.Name == name)
            {
                return entry.Type; // Return the type of the symbol
            }
        }

        return null; // Symbol not found
    }

    private int HashFunction(string key)
    {
        int hash = 0;
        foreach (char c in key)
        {
            hash = (hash + c) % TableSize;
        }
        return hash;
    }

    class SymbolEntry
    {
        public string Name { get; }
        public string Type { get; }

        public SymbolEntry(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }
}

class Program
{
    static void Main()
    {
        SymbolTable symbolTable = new SymbolTable();

        // Insert symbols into the table
        symbolTable.Insert("variable1", "int");
        symbolTable.Insert("variable2", "float");
        symbolTable.Insert("variable1", "char"); // Duplicate entry

        // Check if symbols are in the table
        Console.WriteLine($"Contains variable1: {symbolTable.Contains("variable1")}");
        Console.WriteLine($"Contains variable3: {symbolTable.Contains("variable3")}"); // Not inserted

        // Get the type of symbols
        Console.WriteLine($"Type of variable1: {symbolTable.GetType("variable1")}");
        Console.WriteLine($"Type of variable3: {symbolTable.GetType("variable3")}"); // Not inserted
    }
}
