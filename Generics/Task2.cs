using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;

class Dictionary
{
    public List<Dictionary<string, List<string>>> listOfDictionaries = new List<Dictionary<string, List<string>>>();

    public Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>
    {
         {"Hello", new List<string> {"Bonjour"}},
         {"World", new List<string> {"Monde"}}
    };

    public void AddWord(string word, string translation)
    {
        if (dictionary.ContainsKey(word))
        {
            dictionary[word].Add(translation);
        }
        else
        {
            dictionary[word] = new List<string> { translation };
        }
    }
    public void ReplaceWord(string oldWord, string newWord)
    {
        if (dictionary.ContainsKey(oldWord))
        {
            var translations = dictionary[oldWord];
            dictionary.Remove(oldWord);
            dictionary[newWord] = translations;
            Console.WriteLine($"Слово '{oldWord}' заменено на '{newWord}'");
        }
    }
    public void ReplaceTranslation(string word, string newTranslation)
    {
            if (dictionary.ContainsKey(word))
            {
                dictionary[word] = new List<string> { newTranslation };
                Console.WriteLine($"Перевод для '{word}' изменен на '{newTranslation}'");
        }
    }
    public void RemoveWord(string word, string translation)
    {
        if (dictionary.ContainsKey(word))
        {
            dictionary[word].Remove(translation);
            dictionary.Remove(word); 
        }
    }
    public void RemoveTranslation(string word, string translation)
    {
        if (dictionary.ContainsKey(word))
        {
            dictionary[word].Remove(translation);
        }
    }
    public void SearchTranslation(string word)
    {
        if (dictionary.ContainsKey(word))
        {
            foreach (var translation in dictionary[word])
            {
                Console.WriteLine(translation);
            }
        }
        else
        {
                Console.WriteLine("Перевод не найден.");
        }
    }

    public void PrintAll()
    {
        foreach (var entry in dictionary)
        {
            Console.WriteLine($"{entry.Key}: {string.Join(", ", entry.Value)}");
        }
    }
}

class Task2
{
    public void Task()
    {
        Dictionary dictionary = new Dictionary();
        dictionary.SearchTranslation("Hello");
        dictionary.AddWord("Work", "Travail");
        dictionary.ReplaceWord("Work", "Profession");
        dictionary.RemoveTranslation("Profession", "Travail");
        dictionary.SearchTranslation("Hello");
        dictionary.PrintAll();
        dictionary.RemoveWord("Profession", "Travail");
        dictionary.PrintAll();
    }
}
