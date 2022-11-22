/*
The key operation of the merge sort algorithm is the merging of two sorted
sequences in the “combine” step. We merge by calling an auxiliary procedure
MERGE(A, p, q, r), where A is an array and p, q, and r are indices into the array
such that p <= q < r. The procedure assumes that the subarrays a[p..q] and
A[q+1..r] are in sorted order. It merges them to form a single sorted subarray
that replaces the current subarray A[p..r].

Since we perform at most n basic steps, merging takes O(n) time
where n = r - p + 1 is the total number of elements being merged
*/

