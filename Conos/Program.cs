

///Task

//Console.WriteLine("Nece element");
//int elementsCount = int.Parse(Console.ReadLine());
//int[] masiv = new int[elementsCount];


//for (int i = 0; i < masiv.Length; i++)
//{
//    Console.WriteLine("Massiv elementi nomre" + " " + i);
//    masiv[i] = int.Parse(Console.ReadLine());
//}

//int a = masiv.Max();
//int b = masiv.Min();
//Console.WriteLine(a+b);




//////Task 

Console.WriteLine("Vvedite visotu");
int height = int.Parse(Console.ReadLine());
Console.WriteLine("Vivedite shirinu");
int width = int.Parse(Console.ReadLine());

for (int i = 0; i < height; i++)
{
    for (int k = 0; k < width; k++)
    {
        Console.Write("#");
    }
    Console.WriteLine("#");
}



/////////Task

//int[,] myMap =
//{
//    {0,0,0,1 },
//    {0,1,0,1 },
//    {0,0,0,1 },
//    {1,1,0,1 }
//};

//for (int i = 0; i < 4; i++)
//{
//    for (int j = 0; j < 4; j++)
//    {
//        var reqemler = myMap[i,j];
//        Console.Write(reqemler);
//    }
//    Console.WriteLine();
//}