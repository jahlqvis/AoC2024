﻿using System.Diagnostics;
var start = Stopwatch.StartNew();
var day = new Day1();
day.GetInput();
day.PutIntoLists();
day.SortLists();
day.GetDifferences();
var total = day.GetTotalDistance();
Console.WriteLine($"Day 01A: {total}");
Console.WriteLine($"Duration: {start.ElapsedMilliseconds} mS");
start = Stopwatch.StartNew();
var similarityScore = day.GetSimilarityScore();
Console.WriteLine($"Day 01B: {similarityScore}");
Console.WriteLine($"Duration: {start.ElapsedMilliseconds} mS");
start = null;