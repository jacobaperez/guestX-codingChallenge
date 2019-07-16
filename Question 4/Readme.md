Question 4
Develop a javascript / browser application that will count the number of words & lines that have
more than X vowels for Y words in every Z line.
Language: Code this using Javascript and build a quick UI with a text box.
Example:
Example Parameter: Words: count every [ 3 ] words, Count words with: [2] or more vowels ,
every [2] lines
1. I pledge allegiance to the Flag of the United States of America,
2. and to the Republic for which it stands, one Nation under God,
3. indivisible, with liberty and justice for all, should be rendered
4. by standing at attention facing the flag with the right hand over
5. the heart. When not in uniform men should remove any non-religious
6. headdress with their right hand and hold it at the left shoulder,
7. the hand being over the heart. Persons in uniform should remain
8. silent, face the flag, and render the military salute.
Result: Red is a non-match
Bold is a match
Grey are non-considered lines)

Screen Output:
Results: Lines: 4, words: 6

Solution Abstract: I believe the majority of the solution is pretty straightforward and doesn't require much explanation.
However, I would like to elaborate on filterByVowelCount function.  At this point in the solution we basically have all of the words 
that we need to check.  I made use of two sets "goodWords" and "badWords", first I check if the word is even long enough, if so, 
then I check if it's in the "badWords" set, if not then check if it's in the "goodWords" set, if not, only then do I process the word and check, 
afterwords I place it into it's respective set. At first glance it may look like extra work, but I believe that given very large inputs, 
it would save us a lot of time.

i.e. Let's assume we have the word "alphabetical" a 1000 times, and our vowelCount is 6. That word contains 12 letters, we would have to
check the word 1000 times => 12000 checks.  Opposed to checkings it once 12 checks, then checking if we have that word 999 times => 1,011 checks.
This was my thought process in creating this solutions and making use of the sets. 