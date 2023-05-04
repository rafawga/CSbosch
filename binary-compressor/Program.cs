﻿// variable for change
int vetorSize = 6;
//

byte binary1, binary2, binary3, fist4, last4;

byte[] vetor = RandomNumbers(vetorSize);
byte[] zippedVetor = zipbinary(vetor);
byte[] unzipped = Unzippedbinary(zippedVetor);
PrintZipped(zippedVetor);
Unzippedbinary(zippedVetor);
PrintUnzipped(unzipped);


byte[] RandomNumbers(int tamanhoVetor)
{
    byte[] vetor = new byte[tamanhoVetor];
    Random random = new Random();
    Console.WriteLine();
    for (int i = 0; i < tamanhoVetor; i++)
    {
        vetor[i] = (byte)random.Next(0, 256);
        Console.Write($"{i + 1}° número: {vetor[i].ToString("D3")}");
        Console.WriteLine($"| binário: {Convert.ToString(vetor[i], 2).PadLeft(8, '0')}");
    }
    Console.WriteLine();
    return vetor;
}

byte[] zipbinary(byte[] vetor)
{
    int count = 0;
    byte[] zipped = new byte[vetor.Length / 2];
    for (int i = 0; i < (vetor.Length); i = i + 2)
    {
        binary1 = (byte)((vetor[i] >> 4));
        binary2 = (byte)((vetor[i + 1] >> 4));
        binary3 = (byte)((binary1 << 4) | binary2);
        zipped[count] = binary3;
        count++;
        Console.WriteLine($"{i + 1}° zipped: {Convert.ToString(binary1, 2).PadLeft(4, '0')}");
        Console.WriteLine($"{i + 2}° zipped: {Convert.ToString(binary2, 2).PadLeft(4, '0')}");
    }
    return zipped;
}

void PrintZipped(byte[] zippedVetor)
{
    Console.WriteLine();
    for (int j = 0; j < zippedVetor.Length; j++)
    {
        Console.WriteLine($"{j + 1}° concatenated: {Convert.ToString(zippedVetor[j], 2).PadLeft(8, '0')}");
    }
}

byte[] Unzippedbinary(byte[] zippedVetor)
{

    byte[] unzipped = new byte[zippedVetor.Length * 2];
    for (int i = 0; i < (zippedVetor.Length); i++)
    {
        fist4 = (byte)(zippedVetor[i] >> 4);
        last4 = (byte)(zippedVetor[i] & 0b00001111);
        fist4 <<= 4;
        last4 <<= 4;

        unzipped[i * 2] = fist4;
        unzipped[i * 2 + 1] = last4;

    }
    return unzipped;
}

void PrintUnzipped(byte[] unzipped)
{
    Console.WriteLine();
    for (int i = 0; i < unzipped.Length; i++)
    {
        Console.WriteLine($"{i + 1}° unzipped: {Convert.ToString(unzipped[i], 2).PadLeft(8, '0')}");
    }
    Console.WriteLine();
}
