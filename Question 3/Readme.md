Solution Abstract: I think the most difficult part of this problem was scouring stack overflow figuring out 
how to read from a csv in C#. lol The solution is pretty simple, I make use of two caches (Dictionaries). The
logic is this: If I have already seen a number(in "seen cache"), check if it's in my "duplicated cache" if not, put it in, else move 
on, and if I've never seen it, put it in my "seen cache". Then return my "duplicated cache" as an array. 
Runtime Complexity: Time - O(n), Space - O(n).

Extra: I supposed if we didn't want to use additional space we could rewrite the algorithm to make use of two loops,
checking every number with every other number (affectively a bubblesort without the sort). 
However, the trade off would be increased time complexity. Time - O(n^2), Space - O(1). Not worth it in my opinion.