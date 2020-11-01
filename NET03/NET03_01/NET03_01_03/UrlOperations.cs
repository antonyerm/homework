using System;
using System.Collections.Generic;
using System.Text;

namespace NET03_01_03
{
    internal class UrlOperations
    {
        internal string AddOrChangeUrlParameter(string url, string key)
        {
            if (String.IsNullOrEmpty(url))
            {
                throw new Exception("Not a valid input URL.");
            }

            // get parts of url - pure url and variable part "www.example.com" and "key=value"
            var originalUrlArray = url.Split('?', StringSplitOptions.None);
            if (originalUrlArray.Length > 2)
            {
                throw new Exception("Not a valid input URL.");
            }

            string originalVariablePart = null;
            if (originalUrlArray.Length == 2)
            {
                originalVariablePart = originalUrlArray[1];
            }

            // get variable definitions in tuples (key,value)
            var originalVariables = this.GetVariables(originalVariablePart);
            var newVariables = this.GetVariables(key);

            var newKeyString = this.MergeVariables(originalVariables, newVariables);
            var newFinalUrl = this.CollectPieces(originalUrlArray[0], newKeyString);

            return newFinalUrl;

        }

        /// <summary>
        /// Analyses input string and gets instances of URL Variables (key and value) into the List.
        /// </summary>
        /// <param name="variablePart">Part of URL string containing variables definitions.</param>
        /// <returns>List of URL Variables.</returns>
        private List<UrlVariable> GetVariables(string variablePart)
        {
            var Variables = new List<UrlVariable>();
            if (String.IsNullOrEmpty(variablePart))
            {
                return Variables;
            }
            
            // get array of string definitions "key=value"
            var VariablesArray = variablePart.Split('&', StringSplitOptions.None);

            // get List of tuples (key, value)
            foreach (var variable in VariablesArray)
            {
                var oneVariableArray = variable.Split('=', StringSplitOptions.None);
                if (oneVariableArray.Length > 2)
                {
                    throw new Exception("Not a valid input URL.");
                }

                if (oneVariableArray.Length == 2)
                {
                    Variables.Add(new UrlVariable(oneVariableArray[0], oneVariableArray[1]));
                }
            }

            return Variables;
        }

        /// <summary>
        /// Adds new variables to the list of original ones, modifies values of originals with new ones.
        /// </summary>
        /// <param name="originalVariables">List of original variables.</param>
        /// <param name="newVariables">List of new variables.</param>
        /// <returns>List of merged variables.</returns>
        /// <remarks>The order of arguments is important.</remarks>
        private List<UrlVariable> MergeVariables(List<UrlVariable> originalVariables, List<UrlVariable> newVariables)
        {
            foreach (var newVariable in newVariables)
            {
                var update = false;
                for (int i = 0; i < originalVariables.Count; i++)
                {
                    if (newVariable.Name == originalVariables[i].Name)
                    {
                        originalVariables[i].Value = newVariable.Value;
                        update = true;
                    }
                }
                if (update == false)
                {
                    originalVariables.Add(newVariable);
                }
            }

            return originalVariables;
        }

        /// <summary>
        /// Converts pieces into a new URL string.
        /// </summary>
        /// <param name="originalUrlArray">Pure URL obtained in input string.</param>
        /// <param name="newKeyString">List of new variables merged to old variables.</param>
        /// <returns>Final URL with added new variables.</returns>
        private string CollectPieces(string originalUrlArray, List<UrlVariable> newKeyString)
        {
            var resultingUrl = new StringBuilder(originalUrlArray);
            resultingUrl.Append("?");
            foreach (var variable in newKeyString)
            {
                resultingUrl.Append(variable.Name);
                resultingUrl.Append('=');
                resultingUrl.Append(variable.Value);
                resultingUrl.Append('&');
            }

            resultingUrl.Remove(resultingUrl.Length - 1, 1);
            return resultingUrl.ToString();
        }
    }
}