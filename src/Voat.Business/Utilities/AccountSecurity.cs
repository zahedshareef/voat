#region LICENSE

/*
    
    Copyright(c) Voat, Inc.

    This file is part of Voat.

    This source file is subject to version 3 of the GPL license,
    that is bundled with this package in the file LICENSE, and is
    available online at http://www.gnu.org/licenses/gpl-3.0.txt;
    you may not use this file except in compliance with the License.

    Software distributed under the License is distributed on an
    "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either express
    or implied. See the License for the specific language governing
    rights and limitations under the License.

    All Rights Reserved.

*/

#endregion LICENSE

using System.Text.RegularExpressions;

namespace Voat.Utilities
{
    public static class AccountSecurity
    {
        public static bool IsPasswordComplex(string passwordToCheck, string userName, bool enforceCharacterRequirements = true)
        {
            // mark password as insecure if it is the same as the username
            if (passwordToCheck == userName)
            {
                return false;
            }

            // setup parameters
            const int minLength = 6;

            const int numUpper = 1;
            const int numLower = 1;
            const int numNumbers = 1;
            const int numSpecial = 1;

            // setup checks
            Regex upper = new Regex("[A-Z]");
            Regex lower = new Regex("[a-z]");
            Regex number = new Regex("[0-9]");
            Regex special = new Regex("[^a-zA-Z0-9]");

            // always check the length
            if (passwordToCheck.Length < minLength)
                return false;

            if (enforceCharacterRequirements)
            {
                // check for minimum number of occurrences
                if (upper.Matches(passwordToCheck).Count < numUpper)
                    return false;
                if (lower.Matches(passwordToCheck).Count < numLower)
                    return false;
                if (number.Matches(passwordToCheck).Count < numNumbers)
                    return false;
                if (special.Matches(passwordToCheck).Count < numSpecial)
                    return false;
            }

            // all checks passed
            return true;
        }
    }
}
