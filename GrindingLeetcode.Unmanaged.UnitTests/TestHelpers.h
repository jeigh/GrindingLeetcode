#pragma once

#include <vector>
#include <initializer_list>


namespace LeetCodeTests {

    /// <summary>
    /// Creates a linked list from an initializer list of values
    /// </summary>
    inline ListNode* CreateLinkedList(std::initializer_list<int> values) {
        if (values.size() == 0) return nullptr;

        ListNode* head = nullptr;
        ListNode* current = nullptr;

        for (int val : values) {
            ListNode* newNode = new ListNode(val);

            if (head == nullptr) {
                head = newNode;
                current = head;
            }
            else {
                current->next = newNode;
                current = newNode;
            }
        }

        return head;
    }

    /// <summary>
    /// Converts a linked list to a vector for easy comparison
    /// </summary>
    inline std::vector<int> LinkedListToVector(ListNode* head) {
        std::vector<int> result;
        ListNode* current = head;

        while (current != nullptr) {
            result.push_back(current->val);
            current = current->next;
        }

        return result;
    }

    /// <summary>
    /// Frees all nodes in a linked list
    /// </summary>
    inline void FreeLinkedList(ListNode* head) {
        while (head != nullptr) {
            ListNode* temp = head;
            head = head->next;
            delete temp;
        }
    }

    /// <summary>
    /// Asserts that a linked list matches expected values
    /// </summary>
    inline void AssertLinkedListEquals(std::initializer_list<int> expected, ListNode* actual) {
        std::vector<int> expectedVec(expected);
        std::vector<int> actualVec = LinkedListToVector(actual);
        ASSERT_EQ(expectedVec, actualVec);
    }

    /// <summary>
    /// Creates a deep copy of a linked list (for verifying original unchanged)
    /// </summary>
    inline ListNode* CloneLinkedList(ListNode* head) {
        if (head == nullptr) return nullptr;

        ListNode* newHead = new ListNode(head->val);
        ListNode* current = head->next;
        ListNode* newCurrent = newHead;

        while (current != nullptr) {
            newCurrent->next = new ListNode(current->val);
            newCurrent = newCurrent->next;
            current = current->next;
        }

        return newHead;
    }
}