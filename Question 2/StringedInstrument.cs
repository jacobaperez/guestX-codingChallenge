using System;

public class StringedInstrument
{
  private string[] KEYS = { "A", "A#", "B", "C", "C#", "D",
                "D#", "E", "F", "F#", "G", "G#" };
  public string name;
  public int stringCount;
  public string[] tuning;
  public int fretBoardSize;

  /*
    @param {tuning} String[] - Every Value must be capitalized. Doesn't take into account
    flat tunings (i.e. "Ab") However, "Ab" == "G#" which is allowed, so I don't find it to 
    be a significant error. 
   */
  public StringedInstrument(string name, int stringCount, int fretBoardSize, string[] tuning)
  {
    this.name = name;
    this.stringCount = stringCount;
    this.tuning = tuning;
    this.fretBoardSize = fretBoardSize;

    if (stringCount != tuning.Length)
    {
      throw new System.ArgumentException("Must have equal tuning length and string count", "stringCount and tuning");
    }
    else if (fretBoardSize < 1)
    {
      throw new System.ArgumentException("Create an instrument with a reasonable fretboard size please", "fretBoardSize");
    }
    validTuning(tuning);
  }

  private void validTuning(string key)
  {
    if (!Array.Exists(KEYS, note => note == key))
    {
      throw new System.ArgumentException("Not a valid tuning", "tuning");
    }
  }

  private void validTuning(string[] tuning)
  {
    foreach (string key in tuning)
    {
      if (!Array.Exists(KEYS, note => note == key))
      {
        throw new System.ArgumentException("Not a valid tuning", "tuning");
      }
    }
  }

  public string playNote(int stringNumber, int fretNumber)
  {
    if (stringNumber < 0 || stringNumber >= stringCount)
    {
      throw new System.ArgumentException("String doesn't exist on this instrument", "stringNumber");
    }
    else if (fretNumber > fretBoardSize)
    {
      throw new System.ArgumentException("Fret exceeded the size of the fretboard on the instrument", "fretNumber");
    }

    //Use tuning to find correct note on scale.
    string currentStringNote = this.tuning[stringNumber];
    int keyIndex = Array.FindIndex(KEYS, i => i == currentStringNote);

    // Apply fretNumber to change key note appropriately, 
    // octaves occur every 12 so sum indices and mod 12 for corrent note.
    int newKeyIndex = (keyIndex + fretNumber) % 12;

    return KEYS[newKeyIndex];
  }

  public void changeAllTuning(string[] newTuning)
  {
    validTuning(newTuning);

    if (newTuning.Length != stringCount)
    {
      throw new System.ArgumentException("Must have equal tuning length and string count", "stringCount and tuning");
    }
    this.tuning = newTuning;
  }

  public void changeStringTuning(int stringNumber, string newTuning)
  {
    validTuning(newTuning);

    if (stringNumber < 0 || stringNumber >= stringCount)
    {
      throw new System.ArgumentException("Not a valid string on this instrument", "srtingNumber");
    }
    this.tuning[stringNumber] = newTuning;
  }

}
