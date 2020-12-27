using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using LiteDB;

namespace SalaryCalc
{
    internal static class LiteDbTest
    {
        private class BumpData
        {
            public int Id { get; set; }
        
            public int BumpId { get; set; }

            public int Col { get; set; }

            public int Row { get; set; }

            public int Height { get; set; }
        }

        public static void Test()
        {
            using LiteDatabase db = new LiteDatabase(@"c:\temp\MyData.db");
            
            ILiteCollection<BumpData> collection = db.GetCollection<BumpData>("BumpData");

            Stopwatch stopwatch = new Stopwatch();

            //stopwatch.Start();

            //CollectionFilling(collection);

            //stopwatch.Stop();
            //Console.WriteLine($"TotalSeconds : {stopwatch.Elapsed.TotalSeconds}");

            //// Index document using document Name property
            //stopwatch.Start();

            //collection.EnsureIndex("BumpKey", "[$.Col, $.Row]");

            //stopwatch.Stop();
            //Console.WriteLine($"TotalSeconds : {stopwatch.Elapsed.TotalSeconds}");

            var count = collection.Count();

            Console.WriteLine("Start");
            stopwatch.Start();

            var array = collection.Query().GroupBy("[$.Col, $.Row]").Select("@key").ToArray();

            var array1 = array.Select(selector: d =>
            {
                var v2 = (BsonArray)d["expr"];
                return new { Col = v2[0], Row = v2[1] };
            }).ToArray();

            stopwatch.Stop();
            Console.WriteLine($"TotalSeconds : {stopwatch.Elapsed.TotalSeconds}");

            Console.WriteLine("Start");
            stopwatch.Start();

            {
                int i = 0;
                int allCount = array1.Length;
                int percent = -1;

                foreach (var key in array1)
                {
                    var queryable = collection.Query().Where($"$.Col = {key.Col} and $.Row = {key.Row}").ToArray();

                    i++;

                    int currentPercent = (int) ((double) i / allCount * 100);
                    if (currentPercent != percent)
                    {
                        percent = currentPercent;
                        Console.WriteLine($"{percent}%");
                    }
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"TotalSeconds : {stopwatch.Elapsed.TotalSeconds}");
        }

        private static void CollectionFilling(ILiteCollection<BumpData> collection)
        {
            int colCount = 25;
            int rowCount = 25;
            int bumpCount = 2500;

            IEnumerable<BumpData> GetBumpData()
            {
                PercentCounter percentCounter = new PercentCounter(colCount * rowCount * bumpCount);

                int i = 0;
                for (int bumpId = 0; bumpId < bumpCount; bumpId++)
                {
                    for (int col = 0; col < colCount; col++)
                    {
                        for (int row = 0; row < rowCount; row++)
                        {
                            var bumpData = new BumpData()
                            {
                                Id = ++i,
                                BumpId = bumpId,
                                Col = col,
                                Row = row,
                                Height = col * row * bumpId,
                            };

                            yield return bumpData;

                            percentCounter.IncResult(percent => Console.WriteLine($"{percent}%"));
                        }
                    }
                }
            }

            collection.InsertBulk(GetBumpData());
        }
    }
}
