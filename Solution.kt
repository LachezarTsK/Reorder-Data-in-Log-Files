
class Solution {

    fun reorderLogFiles(logs: Array<String>): Array<String> {
        logs.sortWith() { first, second -> compareLogs(first, second) }
        return logs;
    }

    private fun compareLogs(first: String, second: String): Int {
        val iFirst = first.indexOf(' ')
        val iSecond = second.indexOf(' ')

        if (first[iFirst + 1].isLetter() && second[iSecond + 1].isDigit()) {
            return -1
        }
        if (first[iFirst + 1].isDigit() && second[iSecond + 1].isLetter()) {
            return 1
        }
        if (first[iFirst + 1].isDigit() && second[iSecond + 1].isDigit()) {
            return 0
        }

        val compareLogContent = first.substring(iFirst + 1).compareTo(second.substring(iSecond + 1))
        if (compareLogContent != 0) {
            return compareLogContent
        }

        val compareLogIdentifiers = first.substring(0, iFirst).compareTo(second.substring(0, iSecond))
        return compareLogIdentifiers
    }
}
