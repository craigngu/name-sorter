# name-sorter

Sorts persons name by last name then first name alphabetically.

Supports 2-4 letter names, seperated by whitespace.
The application will show an error if any of the names does not meet this criteria and stop working.

Needs exactly one argument which is the input file path to run.
Output path is set in appsettings.json, defaulted to "sorted-names-list.txt".
Results will also be shown in the console alongside the logs.

Currently using slightly modified version of Bubble Sort for sorting, this can be swapped out to use LINQ default sorting.

Travis Page : https://travis-ci.org/craigngu/name-sorter
![alt text](https://travis-ci.org/craigngu/name-sorter.svg?branch=master)
