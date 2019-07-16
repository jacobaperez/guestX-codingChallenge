const buttonSubmit = e => {
  e.preventDefault();

  // ensure that inputs are greater than or equal 1
  const [x, y, z] = [document.getElementById("x").value, document.getElementById("y").value,
  document.getElementById("z").value].map(v => parseInt(v, 10) >= 1 ? parseInt(v, 10) : false);

  let inputText = document.getElementById("textArea").value.split('\n');
  let inputs = [x, y, z];

  document.getElementById("answer").style = "visibility: hidden";
  if (validateInputs(inputs)) {
    let processedInput = filterByVowelCount(filterOutWords(filterOutLines(inputText, z), x), y);
    let elem = document.getElementById("answer");
    elem.style = "visibility: visible";
    elem.innerHTML = `Lines: ${processLines(processedInput[0])}, Words: ${processedInput[1]}`;
  }

}

/**
 * 
 * @param {Array} array - [x, y, z] inputs. 
 * @returns {Boolean}
 */
const validateInputs = array => {
  let ids = ["x", "y", "z"];
  document.getElementById("error").style = "visibility: hidden";
  for (let i = 0; i < array.length; i++) {
    if (!array[i]) {
      document.getElementById("error").style = "visibility: visible";
      document.getElementById(ids[i]).style = "border: solid 1px red";
      return false;
    }
    document.getElementById(ids[i]).value = array[i];
    document.getElementById(ids[i]).style = "";
  }
  return true;
}

/**
 * 
 * @param {Array} arr - array of entire lines 
 * @param {Integer} lines - amount of lines to skip by
 * @returns {Array}
 */
const filterOutLines = (arr, lines) => {
  if (lines === 1) return arr;

  return arr.filter((_line, index) => {
    return ((index + 1) % lines) === 0;
  });
}

/**
 * 
 * @param {Array} arr  - array of filtered lines
 * @param {Integer} words - amount words to skip by
 * @returns {Array}
 */
const filterOutWords = (arr, words) => {
  return arr.map(line => {
    return line.split(' ').filter((_, index) => ((index + 1) % words) === 0);
  });
}

/**
 * 
 * @param {Array} words - array of filtered lines and words 
 * @param {Integer} vowelCount - amount of vowels every word must have
 * @returns {Array}
 */
const filterByVowelCount = (words, vowelCount) => {
  const badWords = new Set();
  const goodWords = new Set();
  let count = 0;

  let validWords = words.map(wordsArr => {
    return wordsArr.filter(word => {
      if (word.length >= vowelCount) {
        if (!badWords.has(word)) {
          if (goodWords.has(word) || validWord(word, vowelCount)) {
            goodWords.add(word);
            count++;
            return true;
          }
          else {
            badWords.add(word);
            return false;
          }
        }
      }
      return false;
    })
  })
  return [validWords, count];
}

/**
 * 
 * @param {String} word - string to count chars 
 * @param {Integer} vowelCount - amount of vowels needed to be approved
 * @returns {Boolean}
 */
const validWord = (word, vowelCount) => {
  let count = 0;
  const vowels = new Set(['a', 'e', 'i', 'o', 'u'])
  word = word.toLowerCase();
  word.split('').forEach(letter => {
    if (count >= vowelCount) {
      return true;
    }
    if (vowels.has(letter)) {
      count++;
    }
  })
  return count >= vowelCount;
}

/**
 * 
 * @param {Array} array - filtered out array.
 * @returns {Integer}
 */
const processLines = array => {
  let count = 0;
  for (let i = 0; i < array.length; i++) {
    if (array[i].length != 0) {
      count++;
    }
  }
  return count;
}


/**
 * js text to test with.
 *
 *
I pledge allegiance to the Flag of the United States of America,
and to the Republic for which it stands, one Nation under God,
indivisible, with liberty and justice for all, should be rendered
by standing at attention facing the flag with the right hand over
the heart. When not in uniform men should remove any non-religious
headdress with their right hand and hold it at the left shoulder,
the hand being over the heart. Persons in uniform should remain
silent, face the flag, and render the military salute.
 */