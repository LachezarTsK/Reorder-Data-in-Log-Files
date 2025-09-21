
function reorderLogFiles(logs: string[]): string[] {
    logs.sort((first, second) => compareLogs(first, second));
    return logs;
};

function compareLogs(first: string, second: string): number {
    const iFirst = first.indexOf(' ');
    const iSecond = second.indexOf(' ');

    if (isLetter(first.charAt(iFirst + 1)) && isDigit(second.charAt(iSecond + 1))) {
        return -1;
    }
    if (isDigit(first.charAt(iFirst + 1)) && isLetter(second.charAt(iSecond + 1))) {
        return 1;
    }
    if (isDigit(first.charAt(iFirst + 1)) && isDigit(second.charAt(iSecond + 1))) {
        return 0;
    }

    const compareLogContent = first.substring(iFirst + 1).localeCompare(second.substring(iSecond + 1));
    if (compareLogContent !== 0) {
        return compareLogContent;
    }

    const compareLogIdentifiers = first.substring(0, iFirst).localeCompare(second.substring(0, iSecond));
    return compareLogIdentifiers;
}

function isDigit(character: string): boolean {
    return /\p{digit}/u.test(character);
}

function isLetter(character: string): boolean {
    return /\p{L}/u.test(character);
}
