using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringsLib
{
    public class ParseString
    {
        public string Desc { get; set; }
        public string UserString { get; set; }
        private int _grandTotal;




        public int CountTotal(string phrase)
        {
            MatchCollection collection = Regex.Matches(phrase, @"[\S]+");
            return collection.Count;
        }



        public int WordsUnique(string phrase)
        {
            //split the phrase and break up each unique store into object result
            var result = phrase.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .GroupBy(r => r)
                .Select(grp => new
                {
                    Word = grp.Key,
                    Count = grp.Count()
                });

            //get total count of unique words
            foreach (var c in result)
            {
                int current = 1;
                _grandTotal += current;
            }
           //onsole.WriteLine("Unique Total Words:" + _grandTotal);
            return _grandTotal;
        }


        public Dictionary<string, int> CountUnique(string phrase)
        {
            //split the phrase and break up each unique store into ienumerable 
            var result = phrase.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .GroupBy(r => r)
                .Select(grp => new
                {
                    Word = grp.Key,
                    Count = grp.Count()
                });

            //Sort ienumerable of result Words
            var sortedWords = result.OrderBy(a => a.Word);
            var uniqueDict = new Dictionary<string, int>();

            //output unique word and count
            foreach (var item in sortedWords)
            {
//                Console.WriteLine("{0} {1}", item.Word, item.Count);
                //use dictionary like an associative array to store ints and strings for output
                uniqueDict.Add(item.Word, item.Count);
            }
            //return dictionary of item.word & item.count
            return uniqueDict;
        }



    }
}