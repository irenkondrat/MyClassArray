using System.Collections.Generic;

namespace KVector
{
    public class BaseVector
    {
        internal int[] Coordinates { get; set; }

        protected BaseVector(int[]coordinates)
        { 
            Coordinates = new int[coordinates.Length];
            Coordinates = coordinates;
        }

        protected BaseVector(int countCoordinate)
        {
            Coordinates = new int[countCoordinate];
        }

        protected static double Multiply(List<BaseVector> vectors, int countCoordinate)
        {
            double sum = 0;
        
            for (var i = 0; i < countCoordinate; ++i)
            {
                double mult = 1;
                foreach (var t in vectors)
                {
                    mult *=  t.Coordinates[i];
                }
                sum += mult;
            }
            return sum;
        }

        protected static BaseVector Multiply(BaseVector vectors, int values)
        {
            BaseVector resultVector = new BaseVector(vectors.Coordinates.Length);

            for (var i = 0; i < vectors.Coordinates.Length; ++i)
            {
                resultVector.Coordinates[i] = values * vectors.Coordinates[i];
            }
            return resultVector;
        }

        protected static BaseVector Subtraction(List<BaseVector> vectors, int countCoordinate)
        {
            BaseVector resultVector = new BaseVector(countCoordinate);
            for (var i = 0; i < countCoordinate; ++i)
            {
                    resultVector.Coordinates[i] = vectors[0].Coordinates[i]- vectors[1].Coordinates[i];
            }
            return resultVector;
        }

        protected static BaseVector Addition(List<BaseVector> vectors, int countCoordinate)
        {
            BaseVector resultVector= new BaseVector(countCoordinate);
            for (var i = 0; i < countCoordinate; ++i)
            {
                foreach (var t in vectors)
                {
                    resultVector.Coordinates[i] += t.Coordinates[i];
                }
            }
            return resultVector;
        }
        
    }
}

