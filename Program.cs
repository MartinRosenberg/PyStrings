using System;
using String;

namespace pystrings_sharp {
    class Program {
        static void Main(string[] args) {

            PyString s;

            // Test 1
            // "words"[0] = "w"
            s = "words";
            Console.WriteLine(s[0]);

            // Test 2
            // "words"[1:3] = "or"
            s = "words";
            Console.WriteLine(s[1,3]);

            // Test 2
            // "whatever"[-4:] = "ever"
            s = "whatever";
            Console.WriteLine(s[-4, null]);

            // Test 3
            // "whatever"[-4] = "e"
            s = "whatever";
            Console.WriteLine(s[-4]);

            // Test 4
            // "stramp"[1::2] = "tap"
            s = "stramp";
            Console.WriteLine(s[1, null, 2]);

            // Test 5
            // "burger"[3::-1] = "grub"
            s = "burger";
            Console.WriteLine(s[-3, null, -1]);

            // Test 6
            // "123456"[4:1:-2] = "53"
            s = "123456";
            Console.WriteLine(s[4, 1, -2]);

            // Done!
            Console.ReadLine();
        }
    }
}
