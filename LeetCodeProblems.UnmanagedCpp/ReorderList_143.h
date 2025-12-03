#pragma once
#include "ListNode.h"

class ReorderList_143
{
public:
    inline void reorderList(ListNode* head)
    {
        auto head2 = splitList(head);
        head2 = reverseList(head2);
        return zipperMerge(head, head2);
    }

private:
    static inline ListNode* reverseList(ListNode* head)
    {
        if (head == nullptr) return nullptr;
        if (head->next == nullptr) return head;

        ListNode* first = nullptr;
        ListNode* second = head;

        while (second != nullptr)
        {
            const auto secondNext = second->next;

            second->next = first;
            first = second;
            second = secondNext;
        }

        return first;
    }

    inline ListNode* splitList(ListNode* head)
    {
        if (head == nullptr) return nullptr;
        if (head->next == nullptr) return nullptr;

        auto fast = head;
        auto slow = head;

        while (fast->next != nullptr && fast->next->next != nullptr)
        {
            fast = fast->next->next;
            slow = slow->next;
        }

        auto returnable = slow->next;
        slow->next = nullptr;
        return returnable;
    }


    void inline zipperMerge(ListNode* first, ListNode* second)
    {
        auto current1 = first;
        auto current2 = second;

        while (current2 != nullptr)
        {
            const auto current2next = current2->next;
            const auto current1next = current1->next;

            current1->next = current2;
            current2->next = current1next;

            current1 = current1next;
            current2 = current2next;
        }
    }


};