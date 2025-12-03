#pragma once

#include "ListNode.h"

class ReverseList_206 {
public:
    inline ListNode* reverseList(ListNode* head) 
    {
        if (head == nullptr || head->next == nullptr) return head;

        ListNode* first = nullptr;
        ListNode* second = head;

        while (second != nullptr)
        {
            ListNode* secondNext = second->next;
            second->next = first;

            first = second;
            second = secondNext;
        }

        return first;
    }

};