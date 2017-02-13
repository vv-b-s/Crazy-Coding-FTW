using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_January_16_Problem_8
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            int counter = 0;
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            int maxSequenceOfNumbers = 0;
            for (int i = 0; i < n ; i++)
            {
                if (i>=1 && i<=n-2)//Logic for elements from 2-nd to before last.
                {
                    if (numbers[i] > numbers[i - 1] && numbers[i] < numbers[i + 1])
                    {
                        counter++;
                        if (counter > maxSequenceOfNumbers)
                        {
                            maxSequenceOfNumbers = counter;
                        }
                    }
                     else if (numbers[i] > numbers[i - 1] && numbers[i] >= numbers[i + 1])
                    {
                        counter++;
                        if (counter > maxSequenceOfNumbers)
                        {
                            maxSequenceOfNumbers = counter;
                        }
                        counter = 0;
                    }
                    else if (numbers[i] < numbers[i-1] && numbers[i] < numbers[i+1])
                    {
                        counter++;
                        if (counter > maxSequenceOfNumbers)
                        {
                            maxSequenceOfNumbers = counter;
                        }
                    }
                }

                if (i==0)//Logic for 1-st element
                {
                    if (numbers[i] < numbers[i+1])
                    {
                        counter++;
                        if (counter > maxSequenceOfNumbers)
                        {
                            maxSequenceOfNumbers = counter;
                        }
                        //counter = 0;
                    }
                    else
                    {
                        counter += 0;
                    }
                }

                if (i==n-1)//Logic for last element
                {
                    if (numbers[i] > numbers[i-1])
                    {
                        counter++;
                        if (counter > maxSequenceOfNumbers)
                        {
                            maxSequenceOfNumbers = counter;
                        }
                        //counter = 0;
                    }
                    else
                    {
                        counter += 0;
                    }
                }

            }
            Console.WriteLine(maxSequenceOfNumbers);//, counter);
        }
    
    }
}
