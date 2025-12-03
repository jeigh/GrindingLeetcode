#pragma once

#include "ListNode.h"

class MiddleOfLinkedListCpp_876 {
public:
    inline ListNode* middleNode(ListNode* head) 
    {
        if (head == nullptr) return nullptr;
        if (head->next == nullptr) return head;

        ListNode* slow = head;
        ListNode* fast = head;

        while (fast != nullptr && fast->next != nullptr)
        {
            fast = fast->next->next;
            slow = slow->next;
        }

        return slow;
    }
};