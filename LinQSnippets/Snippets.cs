using System.Security.Cryptography.X509Certificates;

namespace LinQSnippets
{
    public class Snippets
    {
        static public void BasicLinQ()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5",
                "Seat Leon"
            };

            // 1. SELECT * from cars (SELECT ALL CARS)
            var carList = from car in cars select car;

            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }

            // 2. SELECT WHERE car is audi (SELECT AUDI)

            var audiList = from car in cars where car.Contains("Audi") select car;

            foreach (var audi in audiList)
            {
                Console.WriteLine(audi);
            }
        }

        // Number Example

        static public void LinQNumbers()
        {

            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 8 };

            //Each Number multiplied by 3
            // tale alla numbers , but 9
            // order numbers ny ascendig value

            var processedNumberList = numbers.Select(num => num * 3) // {3,6,9,etc}
                .Where(num => num != 9) //{all but the 9)
                .OrderBy(num => num); //at the end, we order ascending
        }

        static public void SearchExample()
        {
            List<string> textList = new List<string>
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c"
            };

            // 1. First of all elements
            var first = textList.First();

            // 2. Firs Element that is "c"
            var Ctext = textList.First(text => text == "c");

            // 3. First element contains "j"
            var jText = textList.First(text => text.Contains("j"));

            // 4. First element that contains Z or default
            var FirsOrDefault = textList.FirstOrDefault(text => text.Contains("z"));

            // 5 Last Element that contains Z or default
            var LastOrDefault = textList.LastOrDefault(text => text.Contains("z"));

            // 6. Single Values
            var UniqueTexts = textList.Single();
            var UniqueOrDefault = textList.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] OtherNumbers = { 0, 2, 6, 7 };

            // Obtain{ 4,8}

            var numb = evenNumbers.Except(OtherNumbers);

        }

        static public void MultipleSelects()
        {
            //SELECT MANY
            string[] myOpinio =
            {
                "Opinion 1", "text 1",
                "Opinion 2", "text 2",
                "Opinion 3", "text 3",
            };

            var myOpinionSelection = myOpinio.SelectMany(opinion => opinion.Split(","));

            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new[]
                    {
                        new Employee()
                        {
                            Id = 1,
                            Name = "Martin",
                            Email = "marting@gmail.com",
                            Salary = 1000
                        },
                        new Employee()
                        {
                            Id = 1,
                            Name = "Juan",
                            Email = "juan@gmail.com",
                            Salary = 2000
                        },
                        new Employee()
                        {
                            Id = 1,
                            Name = "Pedro",
                            Email = "pedro@gmail.com",
                            Salary = 3000
                        },
                    }
                },

                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 2",
                    Employees = new[]
                    {
                        new Employee()
                        {
                            Id = 1,
                            Name = "Ana",
                            Email = "ana@gmail.com",
                            Salary = 1000
                        },
                        new Employee()
                        {
                            Id = 1,
                            Name = "Maria",
                            Email = "maria@gmail.com",
                            Salary = 2000
                        },
                        new Employee()
                        {
                            Id = 1,
                            Name = "Marta",
                            Email = "marta@gmail.com",
                            Salary = 3000
                        },
                    }
                }
            };

            // Obtain all employes of all enterprises
            var employeeList = enterprises.SelectMany(enterprise => enterprise.Employees);

            //Know if a list is empty

            bool hasEnterprise = enterprises.Any();

            bool hasEmployee = enterprises.Any(enterprise => enterprise.Employees.Any());

            //all enterprises at least has an employee with more than 1000

            bool Has1000 = enterprises.Any(enterprise =>
            enterprise.Employees.Any(employee =>
            employee.Salary > 1000));
        }

        static public void linqCollections()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "b", "d" };

            // INNERJOIN

            var commondResult = from element in firstList
                                join element2 in secondList
                                on element equals element2
                                select new { element, element2 };

            var commondResult2 = firstList.Join(
                secondList,
                element => element,
                secondElement => secondElement,
                (element, secondElement) => new { element, secondElement }
                );

            // OUTER JOIN - LEFT
            var leftOuterJoin = from element in firstList
                                join secondElement in secondList
                                on element equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element = element };

            var leftOuterJoin2 = from element in firstList
                                 from secondElement in secondList.Where(s => s == element).DefaultIfEmpty()
                                 select new { Element = element, SecondElement = secondElement };
            // OUTER JOIN- RIGHT
            var RightOuterJoin = from secondElement in secondList
                                 join element in firstList
                                 on secondElement equals element
                                 into temporalList
                                 from temporalElement in temporalList.DefaultIfEmpty()
                                 where secondElement != temporalElement
                                 select new { Element = secondElement };

            // Union

            var union = leftOuterJoin.Union(RightOuterJoin);

        }

        static public void SkipTakeLinQ()
        {
            var myList = new[]
            {
                1,2,3,4,5,6,7,8,9,10
            };

            var skipTwoFirstValues = myList.Skip(2); //{3,4,5,6,7,8,9}

            var skipLastTwo = myList.SkipLast(2); //  {1,2,3,4,5,6,7,8}

            var skipWhile = myList.SkipWhile(num => num < 4); //{4,5,6,7,8}

            // TAKE

            var takeFirstTwo = myList.Take(2); //{1,2}

            var takeLastTwo = myList.TakeLast(2); //  {9,10}

            var takeWhile = myList.TakeWhile(num => num < 4); //{1,2,3}
        }

        //Paging with skip and take 

        static public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultPerPage)
        {
            int startIndex = (pageNumber - 1) * resultPerPage;
            return collection.Skip(startIndex).Take(resultPerPage);
        }

        //Variables
        static public void LinqVariables()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var aboveAverage = from number in numbers
                               let average = numbers.Average() //media de datos
                               let nSquare = Math.Pow(number, 2)
                               where nSquare > average
                               select number;

            Console.WriteLine("Average: {0}", numbers.Average());

            foreach (int number in aboveAverage)
            {
                Console.WriteLine("Number: {0} Square {1}", number, Math.Pow(number, 2));
            }
        }
        //ZIP

        static public void ZipLinQ()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] stringNumbers = { "one", "two", "three", "four", "five" };

            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word) => number + "=" + word); // {"1="one", 2="two",...}
        }

        //repeat & range

        static public void repeatRangeLinq()
        {
            //Generate collection from 1 -1000 --> range
            var first1000 = Enumerable.Range(0, 1000);

            // Repeat a value N times 

            IEnumerable<string> fiveXs = Enumerable.Repeat("X", 5); // {"X","X","X","X","X"}
        }

        static public void studentLinQ()
        {
            var classRoom = new[]
            {
                new Student
                {
                    Name= "Martin",
                    Id= 1,
                    Grade= 90,
                    Certifcated= true,
                },
                new Student
                {
                    Name= "Juan",
                    Id= 2,
                    Grade= 50,
                    Certifcated= false,
                },
                new Student
                {
                    Name= "ana",
                    Id= 3,
                    Grade= 95,
                    Certifcated= true,
                },
                new Student
                {
                    Name= "Pedro",
                    Id= 4,
                    Grade= 92,
                    Certifcated= false,
                }
            };

            var certifiedStudent = from student in classRoom
                                   where student.Certifcated
                                   select student;

            var notCertifed = from student in classRoom
                              where student.Certifcated == false
                              select student;

            var aproveStudentName = from student in classRoom
                                where student.Grade >= 50 & student.Certifcated == true
                                select student.Name;
        }
        //All

        static public void AllLinQ()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5 };
            

            bool allAreSamllerThan10 = numbers.All(x => x <10); //true

            bool AllAreBiggerOrEqualThan2 = numbers.All(x => x >=2); //false

            var emptyList= new List<int>();

            bool allNumbersAreGreaterThan0 = numbers.All(x => x >=0); //true
        }

        //Aggregate 

        static public void aggregateQueries()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //sum all numbers

            int sum = numbers.Aggregate((prevSum, current) => prevSum + current);

            string[] words = { "hello", "my", "name", "is", "juan" };
            string greeting = words.Aggregate((prevGreeting, current) => prevGreeting + current);
        }

        // Disctint

        static public void distintValues()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 };

            IEnumerable<int> notRepeated = numbers.Distinct();
        }

        //GroupBy

        static public void groupByExample()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //Obtain even numbers and generate groups

            var group = numbers.GroupBy(x => x % 2 == 0);

            foreach (var groups in group)
            {
                foreach (var value in group)
                {
                    Console.WriteLine(value); //1,3,5,7,9... 2,4,6,8 (First the odds and then the even)
                }
            }

        }

    }

}