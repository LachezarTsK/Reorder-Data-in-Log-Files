
#include <ranges>
#include <string>
#include <vector>
#include <algorithm>
using namespace std;

class Solution {

public:
    vector<string> reorderLogFiles(vector<string>& logs) const {
        ranges::stable_sort(logs, compareLogs);
        return logs;
    }

private:
    static bool compareLogs(const string& first, const string& second) const {
        int iFirst = first.find_first_of(' ');
        int iSecond = second.find_first_of(' ');

        if (isalpha(first[iFirst + 1]) && isdigit(second[iSecond + 1])) {
            return  first[iFirst + 1] > second[iSecond + 1];
        }

        if (isalpha(first[iFirst + 1]) && isalpha(second[iSecond + 1])) {
            string contentFirst = first.substr(iFirst + 1, first.size() - iFirst - 1);
            string contentSecond = second.substr(iSecond + 1, second.size() - iSecond - 1);
            if (contentFirst != contentSecond) {
                return contentFirst < contentSecond;
            }

            string identifierFirst = first.substr(0, iFirst);
            string identifierSecond = second.substr(0, iSecond);
            return identifierFirst < identifierSecond;
        }
        return false;
    };
};
