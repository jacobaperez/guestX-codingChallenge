using System;


// Todo: Write test cases for instruments.
namespace Question_2
{
  class Program
  {
    // Todo: Write more in-depth tests, possibly abstract out a testing function.
    static void Main(string[] args)
    {
      StringedInstrument guitar = new StringedInstrument("guitar", 6, 22, new string[] { "E", "A", "D", "G", "B", "E" });
      StringedInstrument bass = new StringedInstrument("bass", 4, 22, new string[] { "E", "A", "D", "G" });
      StringedInstrument ukulele = new StringedInstrument("ukulele", 4, 20, new string[] { "C", "G", "E", "A" });
      Console.WriteLine("Tests:");
  
      // Basic Testing.
      Console.WriteLine(guitar.name == "guitar");
      Console.WriteLine(guitar.stringCount == 6);
      Console.WriteLine(guitar.tuning[0] == "E");
      Console.WriteLine(guitar.playNote(0, 0) == "E");
      guitar.changeStringTuning(0, "F");
      Console.WriteLine(guitar.playNote(0, 0) == "F");

      Console.WriteLine(ukulele.name == "ukulele");
      Console.WriteLine(ukulele.stringCount == 4);
      Console.WriteLine(ukulele.tuning[1] == "G");
      Console.WriteLine(ukulele.playNote(1, 4) == "B");
      ukulele.changeStringTuning(2, "F");
      Console.WriteLine(ukulele.playNote(2, 0) == "F");

      Console.WriteLine(bass.name == "bass");
      Console.WriteLine(bass.stringCount == 4);
      Console.WriteLine(bass.tuning[3] == "G");
      Console.WriteLine(bass.playNote(3, 13) == "G#");
      bass.changeStringTuning(0, "D");
      Console.WriteLine(bass.playNote(0, 1) == "D#");

      // Verify all strings changed.
      guitar.changeAllTuning(new string[] { "D", "A", "D#", "B", "G", "F#" });
      Console.WriteLine(guitar.tuning[0] == "D");
      Console.WriteLine(guitar.tuning[1] == "A");
      Console.WriteLine(guitar.tuning[2] == "D#");
      Console.WriteLine(guitar.tuning[3] == "B");
      Console.WriteLine(guitar.tuning[4] == "G");
      Console.WriteLine(guitar.tuning[5] == "F#");

      // Reset all tunings to standard.
      guitar.changeAllTuning(new string[] { "E", "A", "D", "G", "B", "E" });
      bass.changeAllTuning(new string[] { "E", "A", "D", "G" });
      ukulele.changeAllTuning(new string[] { "C", "G", "E", "A" });  

      // Basic note/octave testing.
      Console.WriteLine(guitar.playNote(2, 2) == bass.playNote(0, 0));
      Console.WriteLine(guitar.playNote(3, 1) == bass.playNote(3, 13));
      Console.WriteLine(guitar.playNote(5, 17) == ukulele.playNote(3, 0));
      Console.WriteLine(bass.playNote(1, 9) == ukulele.playNote(2, 2));
      Console.WriteLine(bass.playNote(2, 5) == ukulele.playNote(1, 0));

    }
  }
}
