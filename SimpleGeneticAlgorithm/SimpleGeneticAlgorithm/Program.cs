 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGeneticAlgorithm
{
    class Program
    {
        public static Random random = new Random();
        private static string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static StreamWriter streamWriter = new StreamWriter(folder + @"\SimpleGeneticAlgorithmMN.txt");
        static void Main(string[] args)
        {

            int numberOfRuns;
            double mutationRate;
            double crossRate;

            const int numberOfPopulations = 5;
            const int numberOfSubjectsInPopulation = 30;

            List<int> populationIntValues = new List<int>();
            List<int> fxValues = new List<int>();

            //Parametry funkcji kwadratowej
            fxValues.Add(4);
            fxValues.Add(7);
            fxValues.Add(2);

            Console.Write("Wprowadź prawdopodobieństwo mutacji (w %): ");
            mutationRate = double.Parse(Console.ReadLine()) * 0.01;
            Console.Write("Wprowadź prawdopodobnieństwo krzyżowania (w %): ");
            crossRate = double.Parse(Console.ReadLine()) * 0.01;
            Console.Write("Wprowadź liczbę uruchomień programu: ");
            numberOfRuns = int.Parse(Console.ReadLine());
            

            for (int i = 0; i < numberOfSubjectsInPopulation; i++)
            {
                populationIntValues.Add(random.Next(256));
            }
            Console.WriteLine("Wysolosowano populacje");
            streamWriter.WriteLine("MaxOsobnik     F(x)MAX");

            //iteracje
            for (int iterationNumber = 1; iterationNumber <= numberOfRuns; iterationNumber++)
            {
                double maxFxValue = 0;
                int maxValue = 0;

                Console.WriteLine("Iteracja nr: " + iterationNumber);
                Console.WriteLine();

                //populacje
                for (int populationNumber = 1; populationNumber < numberOfPopulations; populationNumber++)
                {
                    ToByteConverter toByteConverter = new ToByteConverter();

                    List<StringBuilder> populationByteValues = toByteConverter.ConvertIntToByte(populationIntValues);

                    Console.WriteLine("Populacja w bajtach: ");
                    
                    foreach (StringBuilder byteValue in populationByteValues)
                    {
                        Console.WriteLine(byteValue);
                    }
                    Console.WriteLine();

                    //Losowe rozmieszczenie elementów na liście
                    List<StringBuilder> populationByteValuesRandom = new List<StringBuilder>();
                    int tempLength = populationByteValues.Count;
                    int tempIndex = 0;

                    while (tempLength > 0)
                    {
                        tempIndex = random.Next(0, tempLength);
                        populationByteValuesRandom.Add(populationByteValues[tempIndex]);
                        populationByteValues.RemoveAt(tempIndex);
                        tempLength = populationByteValues.Count;
                    }

                    populationByteValues = new List<StringBuilder>();
                    populationByteValues = populationByteValuesRandom;

                    Console.WriteLine("Populacja w bajtach po przelosowaniu pozycji: ");
                    foreach (StringBuilder byteValue in populationByteValues)
                    {
                        Console.WriteLine(byteValue);
                    }
                    Console.WriteLine();

                    //Krzyżowanie
                    Crossing crossing = new Crossing();
                    List<StringBuilder> nextPopulationInByte = crossing.CrossingSubjects(populationByteValues, crossRate);

                    Console.WriteLine("Populacja w bajtach po krzyżowaniu: ");
                    foreach (StringBuilder byteValue in nextPopulationInByte)
                    {
                        Console.WriteLine(byteValue);
                    }
                    Console.WriteLine();

                    //Mutowanie
                    Mutation mutation = new Mutation();
                    nextPopulationInByte = mutation.Mutating(nextPopulationInByte, mutationRate);

                    Console.WriteLine("Populacja w bajtach po mutacji: ");
                    foreach (StringBuilder byteValue in nextPopulationInByte)
                    {
                        Console.WriteLine(byteValue);
                    }
                    Console.WriteLine();

                    //Konwersja na int
                    ToIntConverter toIntConverter = new ToIntConverter();
                    List<int> nextpopulationIntValues = toIntConverter.ConvertByteToItn(nextPopulationInByte);

                    Console.WriteLine("Populacja po mutacji: ");
                    foreach (int value in nextpopulationIntValues)
                    {
                        Console.WriteLine(value);
                    }
                    Console.WriteLine();

                    //Obliczenie wartosci funkcji kwadratowej
                    SqareFunction sqareFunction = new SqareFunction();
                    List<FxObject> fxValuesList = sqareFunction.CreateFxValuesList(nextpopulationIntValues, fxValues);

                    Console.WriteLine("Populacja z szansami: ");
                    foreach (FxObject value in fxValuesList)
                    {
                        Console.WriteLine(value.FxValue.ToString() + " -> " + value.FxRate.ToString());
                    }
                    Console.WriteLine();

                    FxObjectComparerByFxRate fxObjectComparer = new FxObjectComparerByFxRate();
                    fxValuesList.Sort(fxObjectComparer);

                    Console.WriteLine("Populacja posortowana wg szans: ");
                    foreach (FxObject value in fxValuesList)
                    {
                        Console.WriteLine(value.FxValue.ToString() + " -> " + value.FxRate.ToString());
                    }
                    Console.WriteLine();

                    //Ruletka
                    Roulette roulette = new Roulette();
                    List<RatingObject> ratingObjectsList = roulette.CreateFxRatingList(fxValuesList);

                    RatingObjectComparerByRating ratingObjectComparer = new RatingObjectComparerByRating();
                    ratingObjectsList.Sort(ratingObjectComparer);

                    Console.WriteLine("Populacja posortowana wg wkładu: ");
                    foreach (RatingObject rating in ratingObjectsList)
                    {
                        Console.WriteLine(rating.FxValue.ToString() + " -> " + rating.FxRate.ToString() + " -> " + rating.SubjectRating.ToString());
                    }
                    Console.WriteLine();

                    List<FxObject> finalSubjects = roulette.GetRandomSubjectsList(ratingObjectsList);
                    finalSubjects.Sort(fxObjectComparer);

                    Console.WriteLine("Końcowa populacja: ");
                    
                    foreach (FxObject subject in finalSubjects)
                    {
                        Console.WriteLine(subject.FxValue.ToString() + " -> " + subject.FxRate.ToString());
                    }
                    Console.WriteLine();

                    int finalListLength = finalSubjects.Count;
                    maxFxValue = finalSubjects[finalListLength - 1].FxRate;
                    maxValue = finalSubjects[finalListLength - 1].FxValue;

                    Console.WriteLine("Wartości końcowe populacji:");
                    Console.WriteLine("Wartość najwyższa funkcji przystosowania " + maxFxValue);
                    Console.WriteLine("Osobnik o najwyższej funkcji przystosowania to: " + maxValue);
                    Console.WriteLine();

                }
                Console.WriteLine("Koniec iteracji nr " + iterationNumber);
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine();
                streamWriter.WriteLine(maxValue + " -> " + maxFxValue);

            }
            streamWriter.WriteLine();
            streamWriter.WriteLine("-------------------------------------------------------");
            streamWriter.Close();
            Console.ReadKey();
        }
    }
}
