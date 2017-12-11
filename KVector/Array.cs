using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

// ReSharper disable once CheckNamespace
namespace KVector.Array
{
   public class Array:BaseVector, IEquatable<Array>, IFormattable
   {
        public int Count => Coordinates.Length;

        public int Step { get; }

        private int _element;

        public Array(int count) : this(0,count)
        {
        }

        public Array(int step, int count) : base(count)
        {
            Step = step;
            _element = 0;
        }

        public void Add(int values)
        {
            if (_element <= Count-1)
            {
                Coordinates[_element] = values;
                _element++;
            }
            else
            {
                ArgumentException argEx = new ArgumentException("Index is out of range", "index");
                throw argEx;
            }
        }

        public int GetValue(int index)
       {
           try
           {
               ArgumentException argEx = new ArgumentException("Index is out of range", "index");
                if (index>Step*Count)
                    throw argEx;
                if(index==0)
                    return Coordinates[0];
                for (int i=0;i<Coordinates.Length;++i)
                    if (i * Step == index)
                    {
                        return Coordinates[i];
                    }
               throw argEx;
            }
            catch (IndexOutOfRangeException)
           {
               ArgumentException argEx = new ArgumentException("Index is out of range", "index");
               throw argEx;
           }
       }

        public bool Equals(Array other)
        {
            if (other != null && (Count!= other.Count||Step!=other.Step))
            {
                return false;
            }
            for(int i=0;i<Count;++i)
                if (other != null && Coordinates[i] != other.Coordinates[i])
                    return false;
            return true;
        }

        public override string ToString()
        {
            return ToString("", CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            StringBuilder arryaBuilder = new StringBuilder();
            arryaBuilder.Append($"[{0}]={Coordinates[0]}\n");
            for (int i = 1; i < Coordinates.Length; ++i)
                arryaBuilder.Append($"[{i * Step}]={Coordinates[i]} \n");
            return arryaBuilder.ToString();
        }

        public static Array operator +(Array firstArray, Array secondArray)
       {
           if(firstArray.Count != secondArray.Count || firstArray.Step != secondArray.Step)
           {
               ArgumentException argEx = new ArgumentException("Indices are not equal at intervals", "index");
               throw argEx;
           }
            Array resultArray= new Array( firstArray.Step, firstArray.Count);
               var result = Addition(new List<BaseVector>() { firstArray, secondArray }, secondArray.Count);
            for (int i = 0; i < result.Coordinates.Length; i++)
            {
               resultArray.Coordinates[i] = result.Coordinates[i];
            }
               return resultArray;
       }

        public static Array operator -(Array firstArray, Array secondArray)
       {
           if (firstArray.Count != secondArray.Count || firstArray.Step != secondArray.Step)
           {
               ArgumentException argEx = new ArgumentException("Indices are not equal at intervals", "index");
               throw argEx;
           }
           Array resultArray = new Array( firstArray.Step, firstArray.Count);
           var result = Subtraction(new List<BaseVector>() { firstArray, secondArray }, secondArray.Count);
           for (int i = 0; i < result.Coordinates.Length; i++)
           {
               resultArray.Coordinates[i] = result.Coordinates[i];
           }
           return resultArray;
        }

        public static Array operator *(Array array, int values)
       {
           Array resultArray = new Array(array.Step,array.Count);
           var result = Multiply(array, values);
            for (int i = 0; i < result.Coordinates.Length; i++)
           {
               resultArray.Coordinates[i] = result.Coordinates[i];
           }
           return resultArray;
        }

    }
}
