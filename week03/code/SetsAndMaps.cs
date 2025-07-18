using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // Create a list to store the final symmetric pairs
        List<string> result = [];

        // Store the words in a set
        HashSet<string> wordsHolder = [.. words];

        foreach (string word in wordsHolder)
        {
            // Reverse the two-letter word
            string reversedWord = $"{word[1]}{word[0]}";

            // Check if it's not a palindrome and its reverse exists in the set
            if (word != reversedWord && wordsHolder.Contains(reversedWord))
            {
                // Add the pair to the result
                result.Add($"{word} & {reversedWord}");
                // Remove both to avoid duplicates
                wordsHolder.Remove(word);
                wordsHolder.Remove(reversedWord);
            }
        }

        // Convert result list to array and return it
        return [.. result];
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // Get degree from 4th column
            string degree = fields[3].Trim();

            // If degree already exists, increment its count
            if (degrees.TryGetValue(degree, out int value))
            {
                degrees[degree] = ++value;
            }
            // If not, initialize it with 1
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Remove spaces and convert to lowercase
        var word1Array = word1.Replace(" ", "").ToLower().ToCharArray();
        var word2Array = word2.Replace(" ", "").ToLower().ToCharArray();

        // Create dictionaries to store every character
        var word1Dictionary = new Dictionary<char, int>();
        var word2Dictionary = new Dictionary<char, int>();

        // Count letter frequencies for word1
        foreach (char letter in word1Array)
        {
            // If letter already exists, increment its count
            if (word1Dictionary.TryGetValue(letter, out int value))
            {
                word1Dictionary[letter] = ++value;
            }
            // If not, initialize it with 1
            else
            {
                word1Dictionary[letter] = 1;
            }
        }

        // Count letter frequencies for word2
        foreach (char letter in word2Array)
        {
            // If letter already exists, increment its count
            if (word2Dictionary.TryGetValue(letter, out int value))
            {
                word2Dictionary[letter] = ++value;
            }
            // If not, initialize it with 1
            else
            {
                word2Dictionary[letter] = 1;
            }
        }

        // Compare dictionaries to check if both words are anagrams
        return word1Dictionary.Count == word2Dictionary.Count && !word1Dictionary.Except(word2Dictionary).Any();
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // Create a list to store earthquake descriptions
        List<string> earthquakes = [];

        foreach (var feature in featureCollection.Features)
        {
            // Get magnitude and place from current earthquake
            double? mag = feature.Properties.Mag;
            string place = feature.Properties.Place;

            // Add formatted string to earthquakes list
            earthquakes.Add($"{place} - Mag {mag}");
        }
        // Return the result as an array
        return [.. earthquakes];
    }
}