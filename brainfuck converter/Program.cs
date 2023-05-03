using System.IO;
using static System.Console;
using System;

if (args.Length < 1)
{
    WriteLine("Passe o caminho do arquivo: ");
    return;
}

var path = args[0];

StreamReader reader = new StreamReader(path);
string code = reader.ReadToEnd();

int p = 0;
int[] memory = new int[1024];
int[] returnPoint = new int[1024];
int r = 0;

for (int i = 0; i < code.Length; i++)
{
    char character = code[i];
    switch (character)
    {
        case '+':
            memory[p]++;
            break;

        case '-':
            memory[p]--;
            break;

        case '>':
            p++;
            if (p > 1023)
            {
                WriteLine("Out of memory");
                break;
            }
            break;

        case '<':
            p--;
            if (p < 0)
            {
                WriteLine("Out of memory");
                break;
            }
            break;

        case '.':
            int value = memory[p];
            char charValue = (char)value;
            Write(charValue);
            break;

        case ',':
            ConsoleKeyInfo info = ReadKey(true);
            memory[p] = (int)info.KeyChar;
            break;

        case '[':
            r++;
            returnPoint[r] = i;
            break;

        case ']':
            if (memory[p] == 0) r--;
            else i = returnPoint[r];
            break;
    }
}
