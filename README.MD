# Readme

The purpose of this project is to allow me to explore, understand and implement
some of the famous sorting algorithms in C#. By implementing the algorithms
myself, I aim to better understand the benefits and drawbacks of different
solutions whilst also improving my knowledge of the C# language. Development
follows a test-driven approach and each algorithm will be benchmarked against
one another to check performance.

## Implemented Algorithms

### Insertion Method

- Insertion Sort
- Tree Sort

### Selection Method

- Selection Sort
- Heap Sort

### Merging Method

- Merge Sort

### Partitioning Method

- Quick Sort

### Exchanging Method

- Bubble Sort

### Insertion and Merging

### Insertion and Selection

### Partitioning and Selection

---

## Benchmarks

Each algorithm is benchmarked against list of integers of a given length.

The first benchmark runs the algorithm against a randomised set of digits.

The second benchmark is against an already sorted list.

The third is ran with a list in reverse order.

These combinations can help highlight worst case performance in some cases.

Benchmarks are performed with the following configuration:

> `BenchmarkDotNet=v0.12.0, OS=Windows 10.0.19041`  
> `Intel Core i7-6700K CPU 4.00GHz (Skylake), 1 CPU, 8 logical > and 4 physical cores`  
> `.NET Core SDK=3.1.200`  
> `[Host] : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.> 700.20.6702), X64 RyuJIT`  
> `DefaultJob : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX > 4.700.20.6702), X64 RyuJIT`  

The following listed results are based on an array with 250,000 items.

### Random Array Benchmarks

|         Method |          Mean |        Error |       StdDev |   Allocated |
|--------------- |--------------:|-------------:|-------------:|------------:|
|     Quick Sort |      28.18 ms |     0.512 ms |     0.479 ms |   976.58 KB |
|     Merge Sort |      33.63 ms |     0.650 ms |     0.749 ms | 54947.18 KB |
|      Heap Sort |      35.62 ms |     0.657 ms |     0.645 ms |   976.58 KB |
| Insertion Sort |  11,467.45 ms |   142.509 ms |   111.261 ms |   976.59 KB |
| Selection Sort |  31,260.25 ms |   316.243 ms |   264.077 ms |   976.59 KB |
|    Bubble Sort | 109,446.11 ms | 1,299.074 ms | 1,215.155 ms |   976.59 KB |

### Sorted Array Benchmarks

|         Method |            Mean |         Error |        StdDev |  Allocated |
|--------------- |----------------:|--------------:|--------------:|-----------:|
|    Bubble Sort |        207.5 us |       4.02 us |       5.36 us |          - |
| Insertion Sort |        266.0 us |       5.17 us |       6.16 us |          - |
|     Quick Sort |      5,512.3 us |     107.67 us |     157.82 us |        2 B |
|     Merge Sort |     19,358.0 us |     448.90 us |     460.99 us | 55266252 B |
|      Heap Sort |     21,566.3 us |     414.00 us |     367.00 us |      154 B |
| Selection Sort | 26,641,740.3 us | 134,370.39 us | 112,205.36 us |          - |

### Reverse Sorted Array Benchmarks

|         Method |          Mean |         Error |        StdDev |  Allocated |
|--------------- |--------------:|--------------:|--------------:|-----------:|
|     Quick Sort |      7.458 ms |     0.1076 ms |     0.1007 ms |  976.59 KB |
|     Merge Sort |     20.035 ms |     0.4241 ms |     0.4714 ms | 54947.4 KB |
|      Heap Sort |     21.631 ms |     0.4173 ms |     0.5278 ms |  976.58 KB |
| Selection Sort | 22,684.722 ms |   183.1704 ms |   162.3758 ms |  977.89 KB |
| Insertion Sort | 25,531.095 ms |   172.1545 ms |   161.0335 ms |  977.89 KB |
|    Bubble Sort | 69,317.167 ms | 1,171.3136 ms | 1,038.3390 ms |  976.59 KB |
