
package main

import (
    "slices"
    "strings"
    "unicode"
)

func reorderLogFiles(logs []string) []string {
    slices.SortStableFunc(logs, compareLogs)
    return logs
}

func compareLogs(first string, second string) int {
    iFirst := strings.Index(first, " ")
    iSecond := strings.Index(second, " ")

    if unicode.IsLetter(rune(first[iFirst + 1])) && unicode.IsDigit(rune(second[iSecond + 1])) {
        return -1
    }
    if unicode.IsDigit(rune(first[iFirst + 1])) && unicode.IsLetter(rune(second[iSecond + 1])) {
        return 1
    }
    if unicode.IsDigit(rune(first[iFirst + 1])) && unicode.IsDigit(rune(second[iSecond + 1])) {
        return 0
    }

    compareLogContent := strings.Compare(first[iFirst + 1:], second[iSecond + 1:])
    if compareLogContent != 0 {
        return compareLogContent
    }

    compareLogIdentifiers := strings.Compare(first[:iFirst], second[:iSecond])
    return compareLogIdentifiers
}
