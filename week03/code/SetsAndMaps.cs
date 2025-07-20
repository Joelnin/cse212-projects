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
        // TODO Problem 1 - ADD YOUR CODE HERE

        // Create a set for the words after seeing them the first time.
        var wordsSeen = new HashSet<string>();
        
        // Create a list for the pairs found.
        var pairs = new List<string>();
        
        // Go through each word in the array words.
        foreach (string word in words)
        {
            // First check if both letter in the word are the same. aa is not acceptable.
            if (word[0] != word[1])
            {
                // Get the palindrome of this word. Switch both letters.
                string reversedWord = String.Concat(word[1], word[0]);

                // Check if this reversed word is in the new set of words we've seen.
                if (wordsSeen.Contains(reversedWord))
                {
                    // If found, add it to the list of pairs.
                    pairs.Add($"{reversedWord} & {word}");
                }

                // If the reversed word is not in the new set. Add the original word (not reversed) so it can be compared again later.
                else
                {
                    wordsSeen.Add(word);
                }
            }
        }

        return pairs.ToArray(); // Return the list of pairs as an array of strings-.
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
            // TODO Problem 2 - ADD YOUR CODE HERE

            string degreeName = fields[3];

            // If the degree is not in our summary yet, add it
            if (!degrees.ContainsKey(degreeName))
            {
                // The key is the degree name since we want to summarize how many degrees are there. Since it's the first time this degree appears. Set the value to 1.
                degrees[degreeName] = 1;
            }

            // If the degree is in our sumary, then update the value
            else
            {
                // Add 1 for each duplicate
                degrees[degreeName] += 1;
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
        // TODO Problem 3 - ADD YOUR CODE HERE

        // Each pair of words is an anagram until proven otherwise.
        bool decision = true;

        // Remove spaces and convert the string to lowercase
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        // First: the lengths of the words 1 and 2 should match.
        if (word1.Length != word2.Length)
        {
            decision = false;
        }

        // Create a dictionary for letter's counts in word1
        var letterCount = new Dictionary<char, int>();

        foreach (char letter in word1)
        {
            if (letterCount.ContainsKey(letter))
            {
                // If the letter is in the dictionary, add 1.
                letterCount[letter] += 1;
            }

            else
            {
                // If the letter is not yet in the dictionary, set the value to 1.
                letterCount[letter] = 1;                
            }
        }

        // Start to count the letters in word2, to subtract them to the dictionary in word1
        foreach (char letter in word2)
        {
            if (letterCount.ContainsKey(letter))
            { 
                // If the word1 has the letter, then subtract 1 of the letters count.
                letterCount[letter] -= 1;

                // If that letter's count gets to less than zero, it means there's more of this letter in word2 than in word1. They're not anagrams.
                if (letterCount[letter] < 0)
                {
                    decision = false;
                }
            }

            // If this letter in word2 is not in word1. They're not anagrams.
            else
            {
                decision = false;
            }
        }

        return decision;
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

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.

        // Create a list to return it later with the earthquakes' info.
        var earthquakeDescrip = new List<string>();
        
        // Go through every feature in the features to find place (Place) and magnitud (Mag).
        foreach (var feature in featureCollection.Features)
        {
            string place;

            // Check if the place has a value different from null.
            if (feature.Properties.Place != null)
            {
                place = feature.Properties.Place;
            }

            // If the place is "null", then it is an Unknown location.
            else
            {
                place = "Unknown location";
            }

            string magnitude;
            
            // Check if magnitude (Mag) has a value.
            if (feature.Properties.Mag.HasValue)
            {

                // magnitude = feature.Properties.Mag.Value.ToString("0.00"); // Doesn't need formatting.
                magnitude = feature.Properties.Mag.Value.ToString(); // Use the value as a string.
            }

            // If it doesn't have a value, then set the magnitud to N/A.
            else
            {
                magnitude = "N/A";
            }

            earthquakeDescrip.Add($"{place} - Mag {magnitude}"); // Adding the earthquake description info to the list with the correct format.

            // Format: 1km NE of Pahala, Hawaii - Mag 2.36

        }

        return earthquakeDescrip.ToArray(); // Return the list as an array of strings.
    }
}