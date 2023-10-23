using System;

namespace ChaeminAssignment1
{
    class ChaeminShin
    {
        static void Main(string[] args)
        {
            int n, orgN;
            double a, b, c;

            double discriminant;

            double root1, root2;

            Nullable <double> minimum = null, maximum = null;

            int countTwoRoots = 0, countOneRoot = 0, countNoRoots = 0;

            Console.WriteLine("Insert n: ");

            n = Int32.Parse(Console.ReadLine());
            orgN = n; 

            //Console.WriteLine("min {0}, max {1}", minimum, maximum);

            while (n-- > 0)
            {
                Console.Write("Input a: ");
                a = double.Parse(Console.ReadLine());

                Console.Write("Input b: ");
                b = double.Parse(Console.ReadLine());

                Console.Write("Input c: ");
                c = double.Parse(Console.ReadLine());

                if(a != 0)
                {
                    discriminant = Math.Pow(b, 2) - 4 * a * c;

                    if (discriminant > 0)
                    {
                        countTwoRoots++;

                        root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                        root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                    }
                    else if (discriminant == 0)
                    {
                        countOneRoot++;

                        root1 = root2 = (-b) / (2 * a);
                    }
                    else
                    {
                        countNoRoots++;

                        root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                        root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                    }

                    //Console.WriteLine("====== root1: {1}, root2: {2} ======", n, root1, root2);

                    if (!double.IsNaN(root1) && !double.IsNaN(root2))
                    {
                        double tempMin, tempMax;
                        if(root1 <= root2)
                        {
                            tempMin = root1;
                            tempMax = root2;
                        }
                        else
                        {
                            tempMin = root2;
                            tempMax = root1;
                        }
                        if (minimum != null && maximum != null)
                        {
                            if(tempMin < minimum)
                            {
                                minimum = tempMin;
                            }
                            if(tempMax > maximum)
                            {
                                maximum = tempMax;
                            }
                        }
                        else 
                        {
                            minimum = tempMin;
                            maximum = tempMax;
                        }
                    }
                    else
                    {
                        if (orgN == countNoRoots) //if all calculated root is no real root
                        {
                            minimum = Double.NaN;
                            maximum = Double.NaN;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Not a quadratic equation");
                    orgN--;
                }
                
                //Console.WriteLine("====== minimum: {0}, maximum: {1} ======", minimum, maximum);

            }//end of while

            Console.WriteLine("Minimum: {0}, Maximum: {1}", minimum, maximum);
            Console.Write("Number of the equations with ");
            Console.WriteLine("two real roots: {0}, one real root: {1}, no real roots: {2}", countTwoRoots, countOneRoot, countNoRoots);
        }
    }
}
