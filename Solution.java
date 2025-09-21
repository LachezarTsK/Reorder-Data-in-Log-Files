
import java.util.Arrays;

public class Solution {

    public String[] reorderLogFiles(String[] logs) {
        Arrays.sort(logs, (first, second) -> compareLogs(first, second));
        return logs;
    }

    private int compareLogs(String first, String second) {
        int iFirst = first.indexOf(' ');
        int iSecond = second.indexOf(' ');

        if (Character.isLetter(first.charAt(iFirst + 1)) && Character.isDigit(second.charAt(iSecond + 1))) {
            return -1;
        }
        if (Character.isDigit(first.charAt(iFirst + 1)) && Character.isLetter(second.charAt(iSecond + 1))) {
            return 1;
        }
        if (Character.isDigit(first.charAt(iFirst + 1)) && Character.isDigit(second.charAt(iSecond + 1))) {
            return 0;
        }

        int compareLogContent = first.substring(iFirst + 1).compareTo(second.substring(iSecond + 1));
        if (compareLogContent != 0) {
            return compareLogContent;
        }

        int compareLogIdentifiers = first.substring(0, iFirst).compareTo(second.substring(0, iSecond));
        return compareLogIdentifiers;
    }
}
